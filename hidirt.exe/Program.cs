
///<summary>
///
/// Author:
/// Michael Kipp
///
/// Class:
/// Program
///
/// Purpose:
/// Contains the program entry point.
/// Creates a configuration GUI if it's called without arguments.
/// If an instance is already running it puts it to the foreground
/// and exits the seconds instance immediately after that.
/// Works as console application in the background if it's called
/// with arguments. Allows the user to update device's time and
/// wakeup-time and initiates transmission of IR codes.
///
/// The idea for the single instance handling comes from:
/// http://www.codeproject.com/Articles/96359/Mutex-Process-Identifier
///
///</summary>

using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using HIDIRT;

namespace hidirt.exe
{
  /// <summary>
  /// Class with program entry point.
  /// </summary>
  internal sealed class Program
  {
    // to attach a console to a forms application
    [DllImport( "kernel32.dll" )]
    static extern bool AttachConsole( int dwProcessId );
    private const int ATTACH_PARENT_PROCESS = -1;

    // to implement a single instance forms application
    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool SetForegroundWindow(IntPtr hWnd);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool IsIconic(IntPtr hWnd);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    static readonly String appGuid = "HIDIRT-{c0db6700-2918-49a9-aab8-2165f5a47bfc}-";

    /// <summary>
    /// Program entry point.
    /// </summary>
    [STAThread]
    private static int Main(string[] args)
    {
      int errorlevel;

      // if application was called without any argument
      if(args.Length == 0)
      {
        errorlevel = OpenGui();
      }
      // application was called with (at least one) argument(s)
      else
      {
        AttachConsole(ATTACH_PARENT_PROCESS);
        errorlevel = ParseArgs(args);
      }
      
      if (errorlevel == -1)
        Console.WriteLine("Unknown error.");
      else if (errorlevel == -2)
        Console.WriteLine("Invalid input value.");
      else if (errorlevel == -3)
        Console.WriteLine("Not able to read from device.");
      else if (errorlevel == -4)
        Console.WriteLine("Not able to write to device.");
      
      return errorlevel;
    }
    
    /// <summary>
    /// GUI part of the program.
    /// </summary>
    private static int OpenGui()
    {
      int errorlevel = -1;

      // here we hold the PID of the eventual running instance
      long runningId = 0;
      // this field will show us if an instance is already running
      bool instanceRunning = false;
      // get current running processes
      Process[] runningProcesses = Process.GetProcesses();
      
      foreach (Process p in runningProcesses)
      {
        try
        {
          // we check if a Mutex that respects our format is already created
          Mutex newinstanceMutex = Mutex.OpenExisting(appGuid + p.Id.ToString());
          try
          {
            newinstanceMutex.ReleaseMutex();
          }
          catch { }
          instanceRunning = true;
          // if the upper Mutex.OpenExisting succeeds, a mutex is already created, so
          // an instance signaling the searched mutex is already running
          runningId = p.Id;
          break;
        }
        catch { }
      }
      
      if (!instanceRunning)
      {
        // if no instance is running we create a new "signaling" Mutex
        Mutex currentMutex = new Mutex(true, appGuid + Process.GetCurrentProcess().Id.ToString());
        
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        
        HIDIRT.hidInterface device = HIDIRT.hidInterface.Instance;
        GuiControl gui = new GuiControl();
        Presenter presenter = new Presenter(device, gui);
        presenter.RefreshTime = 1000;
        
        Application.Run(new HIDIRT.GuiContainer(gui));
        
        currentMutex.ReleaseMutex();
      }
      else
      {
        // this code execution occurs if a running application instance was found
        IntPtr winHandle = Process.GetProcessById((int)runningId).MainWindowHandle;
        // we now bring the process with PID = runningID to front
        if (winHandle != IntPtr.Zero)
        {
          const int SW_RESTORE = 9;
          if(IsIconic(winHandle))
          {
            ShowWindow(winHandle, SW_RESTORE);
          }
          SetForegroundWindow(winHandle);
        }
        Environment.Exit(0);
      }
      
      return errorlevel;
    }
    
    /// <summary>
    /// Console part of the program.
    /// </summary>
    private static int ParseArgs(string[] args)
    {
      int errorlevel = -1;
      HIDIRT.hidInterface device = HIDIRT.hidInterface.Instance;;
      
      switch (args[0])
      {
        case "-t":
        case "/t":
          if (args.Length == 3)
          {
            String[] date = args[1].Split('-', '.');
            String[] time = args[2].Split(':', '-');
            try
            {
              DateTime dt = new DateTime(Convert.ToInt16(date[0]),
                                         Convert.ToInt16(date[1]),
                                         Convert.ToInt16(date[2]),
                                         Convert.ToInt16(time[0]),
                                         Convert.ToInt16(time[1]),
                                         Convert.ToInt16(time[2]),
                                         DateTimeKind.Local);
              if (device.WriteDeviceTime(dt))
              {
                errorlevel = 0;
              }
              else
              {
                errorlevel = -4;
              }
            }
            catch {errorlevel = -2;}
          }
          else
          {
            DateTime? rt = device.ReadDeviceTime();
            if (rt != null)
            {
              DateTime dt = rt ?? hidInterface.defTime;
              Console.WriteLine(dt.ToString());
              errorlevel = 0;
            }
            else
            {
              errorlevel = -3;
            }
          }
          break;
          
        case "-w":
        case "/w":
          if (args.Length == 3)
          {
            String[] date = args[1].Split('-', '.');
            String[] time = args[2].Split(':', '-');
            try
            {
              DateTime dt = new DateTime(Convert.ToInt16(date[0]),
                                         Convert.ToInt16(date[1]),
                                         Convert.ToInt16(date[2]),
                                         Convert.ToInt16(time[0]),
                                         Convert.ToInt16(time[1]),
                                         Convert.ToInt16(time[2]),
                                         DateTimeKind.Local);
              if (device.WriteWakeupTime(dt))
              {
                errorlevel = 0;
              }
              else
              {
                errorlevel = -4;
              }
            }
            catch {errorlevel = -2;}
          }
          else
          {
            DateTime? rt = device.ReadWakeupTime();
            if (rt != null)
            {
              DateTime dt = rt ?? hidInterface.defTime;
              Console.WriteLine(dt.ToString());
              errorlevel = 0;
            }
            else
            {
              errorlevel = -3;
            }
          }
          break;
          
        case "-i":
        case "/i":
          if (args.Length == 2)
          {
            IrCode ir = null;
            Byte protocol;
            UInt16 address;
            UInt16 command;
            Byte flags = 0;
            
            String[] code = args[1].Split('-');
            
            if ((code.Length == 3) || (code.Length == 4))
            {
              try
              {
                if (code[0].Contains("x"))
                  protocol = Byte.Parse(code[0].TrimStart('0', 'x'), NumberStyles.AllowHexSpecifier);
                else
                  protocol = Convert.ToByte(code[0]);
                
                if (code[1].Contains("x"))
                  address = UInt16.Parse(code[1].TrimStart('0', 'x'), NumberStyles.AllowHexSpecifier);
                else
                  address = Convert.ToUInt16(code[1]);
                
                if (code[2].Contains("x"))
                  command = UInt16.Parse(code[2].TrimStart('0', 'x'), NumberStyles.AllowHexSpecifier);
                else
                  command = Convert.ToUInt16(code[2]);
                
                if (code.Length == 4)
                {
                  if (code[3].Contains("x"))
                    flags = Byte.Parse(code[3].TrimStart('0', 'x'), NumberStyles.AllowHexSpecifier);
                  else
                    flags = Convert.ToByte(code[3]);
                }
                
                ir = new IrCode(protocol, address, command, flags);
              }
              catch {errorlevel = -2;}
            }
            
            if (errorlevel == -1)
            {
              if (device.SendIrCode(ir))
              {
                errorlevel = 0;
              }
              else
              {
                errorlevel = -4;
              }
            }
          }
          break;
          
        case "-h":
        case "/h":
        case "-?":
        case "/?":
          Console.WriteLine();
          Console.WriteLine();
          Console.WriteLine("Valid arguments:");
          Console.WriteLine();
          Console.WriteLine(" '-t' for reading the device clock.");
          Console.WriteLine(" '-t 2014-01-18 22:15:30' to set the device clock to the given date and time.");
          Console.WriteLine();
          Console.WriteLine(" '-w' for reading the wakeup time.");
          Console.WriteLine(" '-w 2014-01-18 22:15:30' to set the wakeup time to the given date and time.");
          Console.WriteLine("     NOTE: will likely be overwritten if the MediaPortal plugin is also used.");
          Console.WriteLine();
          Console.WriteLine(" '-i 1-33400-42000' to send the given decimal IR code.");
          Console.WriteLine(" '-i 0x1-0x8278-0xA410' to send the given hex IR code.");
          Console.WriteLine(" '-i x1-33400-0xA410' to send the given mixed IR code.");
          Console.WriteLine("     NOTE: you can mix decimal and hex numbers and remove leading zeros.");
          errorlevel = 0;
          break;
      }
      
      return errorlevel;
    }
  }
}
