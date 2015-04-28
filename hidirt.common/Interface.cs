
///<summary>
///
/// Author:
/// Michael Kipp
///
/// Class:
/// hidInterface
///
/// Purpose:
/// Abstraction layer for HIDIRT hardware via GenericHid.
///
///</summary>

using System;
using System.Diagnostics;
using GenericHid;

namespace HIDIRT
{
    /// <summary>
    /// Manages one HIDIRT device.
    /// </summary>
    public class hidInterface //: IDisposable
    {
      #region Variables
      
      /// <summary>
      /// hidirtInterface single instance
      /// </summary>
      private static hidInterface _hidirtInterface;

      /// <summary>
      /// mutex lock object to ensure only one instance of the HIDIRT object
      /// is created.
      /// </summary>
      private static readonly object _mutex = new object();
      
      /// <summary>
      /// hidirtInterface VID & PID
      /// </summary>
      private readonly short VendorId = 0x0483;
      private readonly short ProductId = 0x5750;

      /// <summary>
      /// HidDevice for accessing hardware via HidLibrary
      /// </summary>
      private HidDevice myDev;
        
      // Retrieve singleton of trace listener
//      TextWriterTraceListenerWithTime listener = TextWriterTraceListenerWithTime.GetInstance;

      /// <summary>
      /// Occurs when a HIDIRT device is attached.
      /// </summary>
      public event EventHandler DeviceAttached;

      /// <summary>
      /// Occurs when a HIDIRT device is removed.
      /// </summary>
      public event EventHandler DeviceRemoved;

      /// <summary>
      /// Occurs on a HIDIRT code receive event.
      /// </summary>
      public delegate void IrCodeDelegate(IrCode code);
      public event IrCodeDelegate IrCodeReceive;
      
      #endregion

      #region Constructor & Open

      /// <summary>
      /// Initializes a new instance of the HIDIRT class.
      /// </summary>
      private hidInterface()
      {
        myDev = new HidDevice(VendorId, ProductId);
        myDev.ReadTimeout = 0;
        myDev.ReceivePermanently = true;
        myDev.TransferType = HidDevice.TransferTypes.Interrupt;
        myDev.Open();
        myDev.ReadInputReport();
        myDev.Inserted += DeviceAttachedHandler;
        myDev.Removed += DeviceRemovedHandler;
        myDev.AsynchDataReceived += AsyncDataHandler;
      }

      #endregion

      #region EventHandling
      
      private void DeviceAttachedHandler()
      {
        if (DeviceAttached != null)
            DeviceAttached.Invoke(this, EventArgs.Empty);

        Trace.WriteLine("HIDIRT hardware attached.");
      }

      private void DeviceRemovedHandler()
      {
        if (DeviceRemoved != null)
            DeviceRemoved.Invoke(this, EventArgs.Empty);

        Trace.WriteLine("HIDIRT hardware removed.");
      }
      
      private void AsyncDataHandler(HidReport report)
      {
        if (report.ReportId == (Byte)ReportID.IrCodeInterrupt)
        {
          if (IrCodeReceive != null)
          {
            IrCode code = new IrCode(report.Data);
            IrCodeReceive.Invoke(code);
            Trace.WriteLine(String.Format("Received IR code: Protocol=0x{0:X2}, Address=0x{1:X4}, Command=0x{2:X4}, Flags=0x{3:X2}",
                code.Protocol, code.Address, code.Command, code.Flags));
          }
        }
      }
      
      #endregion
        
      #region Getter/Setter

      /// <summary>
      /// Returns the instance of the manager singleton.
      /// </summary>
      public static hidInterface Instance
      {
        get
        {
          if (_hidirtInterface == null)
          {
            lock (_mutex)
            {
              if (_hidirtInterface == null)
              {
                _hidirtInterface = new hidInterface();
              }
            }
          }
          return _hidirtInterface;
        }
      }

//      public Boolean IsAttached
//      {
//        get { return myDev.IsAttached; }
//      }

      #endregion

      #region HIDIRT-specific
      
      ///  <summary>
      ///  
      ///  </summary>
      public enum ReportID
      {
        IrCodeInterrupt     = 1,
        ReadFirmwareVersion = 0x10,
        ControlPcEnable     = 0x11,
        ForwardIrEnable     = 0x12,
        PowerOnCode         = 0x13,
        PowerOffCode        = 0x14,
        ResetCode           = 0x15,
        MinRepeats          = 0x16,
        DeviceTime          = 0x17,
        ClockDeviation      = 0x18,
        WakeupTime          = 0x19,
        WakeupTimeSpan      = 0x1a,
        RequestBootloader   = 0x50,
        WatchdogEnable      = 0x51,
        WatchdogReset       = 0x52
      }
      
      public static DateTime defTime = new DateTime(2000, 01, 01, 0, 0, 0, DateTimeKind.Utc);
      public static TimeSpan defSpan = new TimeSpan(defTime.Ticks);
      
      public Boolean SendIrCode(IrCode code)
      {
        Boolean success = false;
        if (code.Protocol != 0)
        {
          HidReport report = new HidReport((Byte)ReportID.IrCodeInterrupt, code.GetBytes());
          success = myDev.WriteOutputReport(report);
          if (success)
          {
            Trace.WriteLine(String.Format("Sent IR code: Protocol=0x{0:X2}, Address=0x{1:X4}, Command=0x{2:X4}, Flags=0x{3:X2}",
                                          code.Protocol, code.Address, code.Command, code.Flags));
          }
        }
        return success;
      }

      public String ReadFirmwareVersion()
      {
        String firmware = "Connection failed.";
        HidReport report = myDev.ReadFeatureReport((Byte)ReportID.ReadFirmwareVersion);
        if (report != null)
        {
          firmware = System.Text.ASCIIEncoding.ASCII.GetString(report.Data, 0, report.Data.Length).TrimEnd('\0');
          Trace.WriteLine(String.Format("Get FirmwareVersion: {0}", firmware));
        }
        return firmware;
      }

      public Boolean? ReadControlPcState()
      {
        Boolean? state = null;
        HidReport report = myDev.ReadFeatureReport((Byte)ReportID.ControlPcEnable);
        if (report != null)
        {
          state = Convert.ToBoolean(report.Data[0]);
          Trace.WriteLine(String.Format("Get ControlPcState: {0}", state == true ? "enable" : "disable"));
        }
        return state;
      }
      
      public Boolean WriteControlPcState(Boolean state)
      {
        HidReport report = new HidReport((Byte)ReportID.ControlPcEnable, BitConverter.GetBytes(state));
        Boolean success = myDev.WriteFeatureReport(report);
        if (success)
        {
          Trace.WriteLine(String.Format("Set ControlPcState: {0}", state == true ? "enable" : "disable"));
        }
        return success;
      }

      public Boolean? ReadForwardIrState()
      {
        Boolean? state = null;
        HidReport report = myDev.ReadFeatureReport((Byte)ReportID.ForwardIrEnable);
        if (report != null)
        {
          state = Convert.ToBoolean(report.Data[0]);
          Trace.WriteLine(String.Format("Get ForwardIrState: {0}", state == true ? "enable" : "disable"));
        }
        return state;
      }

      public Boolean WriteForwardIrState(Boolean state)
      {
        HidReport report = new HidReport((Byte)ReportID.ForwardIrEnable, BitConverter.GetBytes(state));
        Boolean success = myDev.WriteFeatureReport(report);
        if (success)
        {
          Trace.WriteLine(String.Format("Set ForwardIrState: {0}", state == true ? "enable" : "disable"));
        }
        return success;
      }
        
      public IrCode ReadIrCode(ReportID repID)
      {
        IrCode code = null;
        String irCodeType = "";
        HidReport report;

        if ((repID != ReportID.PowerOnCode) && (repID != ReportID.PowerOffCode) && (repID != ReportID.ResetCode))
        {
          return code;
        }

        report = myDev.ReadFeatureReport((Byte)repID);
        if (report != null)
        {
          code = new IrCode();
          code.Protocol = report.Data[0];
          code.Address = BitConverter.ToUInt16(report.Data, 1);
          code.Command = BitConverter.ToUInt16(report.Data, 3);
          
          if (repID == ReportID.PowerOnCode)
            irCodeType = "PowerOn";
          else if (repID == ReportID.PowerOffCode)
            irCodeType = "PowerOff";
          else if (repID == ReportID.ResetCode)
            irCodeType = "Reset";
          Trace.WriteLine(String.Format("Get {0} code: Protocol {1:X2}, Address {2:X4}, Command {3:X4}",
                                        irCodeType, code.Protocol, code.Address, code.Command));
        }
        return code;
      }

      public Boolean WriteIrCode(ReportID repID, IrCode code)
      {
        Boolean success = false;
        String irCodeType = "";
        HidReport report;

        if ((repID != ReportID.PowerOnCode) && (repID != ReportID.PowerOffCode) && (repID != ReportID.ResetCode))
        {
          return success;
        }

        report = new HidReport((Byte)repID, code.GetBytes());
        success = myDev.WriteFeatureReport(report);
        if (success)
        {
          if (repID == ReportID.PowerOnCode)
            irCodeType = "PowerOn";
          else if (repID == ReportID.PowerOffCode)
            irCodeType = "PowerOff";
          else if (repID == ReportID.ResetCode)
            irCodeType = "Reset";
          Trace.WriteLine(String.Format("Set {0} code: Protocol {1:X2}, Address {2:X4}, Command {3:X4}",
                                        irCodeType, code.Protocol, code.Address, code.Command));
        }
        return success;
      }

      public Byte? ReadMinRepeats()
      {
        Byte? minRepeats = null;
        HidReport report = myDev.ReadFeatureReport((Byte)ReportID.MinRepeats);
        if (report != null)
        {
          minRepeats = report.Data[0];
          Trace.WriteLine(String.Format("Get MinRepeats: {0:D}", minRepeats));
        }
        return minRepeats;
      }

      public Boolean WriteMinRepeats(Byte minRepeats)
      {
        HidReport report = new HidReport((Byte)ReportID.MinRepeats, minRepeats);
        Boolean success = myDev.WriteFeatureReport(report);
        if (success)
        {
          Trace.WriteLine(String.Format("Set MinRepeats: {0:D}", minRepeats));
        }
        return success;
      }

      public DateTime? ReadDeviceTime()
      {
        Int32 msecs;
        Int64 secs;
        DateTime? dt = null;
        HidReport report = myDev.ReadFeatureReport((Byte)ReportID.DeviceTime);
        if (report != null)
        {
          secs = BitConverter.ToInt32(report.Data, 0);
          msecs = BitConverter.ToInt16(report.Data, 4);
          dt = new DateTime(secs*10000000 + msecs*1000, DateTimeKind.Utc);
          dt = dt.Value.AddTicks(defTime.Ticks);
          dt = dt.Value.ToLocalTime();
          Trace.WriteLine(String.Format("Get DeviceTime: {0}", dt));
        }
        return dt;
      }

      public Boolean WriteDeviceTime(DateTime dt)
      {
        Int16 msecs;
        Int32 secs;
        Int64 ticks;
        Boolean success = false;
        Byte[] buffer = new Byte[sizeof(Int32)+sizeof(Int16)];
        dt = dt.ToUniversalTime();
        if(dt > defTime)
        {
          dt = dt.Subtract(defSpan);
          ticks = (dt.Ticks / 1000) % 1000;
          msecs = (Int16)ticks;
          ticks = dt.Ticks / 10000000;
          secs = (Int32)ticks;
          Buffer.BlockCopy(BitConverter.GetBytes(secs), 0, buffer, 0, 4);
          Buffer.BlockCopy(BitConverter.GetBytes(msecs), 0, buffer, 4, 2);
          HidReport report = new HidReport((Byte)ReportID.DeviceTime, buffer);
          success = myDev.WriteFeatureReport(report);
          if (success)
          {
            Trace.WriteLine(String.Format("Set DeviceTime: {0}", dt));
          }
        }
        return success;
      }

      public Int32? ReadClockCorrection()
      {
        Int32? deviation = null;
        HidReport report = myDev.ReadFeatureReport((Byte)ReportID.ClockDeviation);
        if (report != null)
        {
          deviation = BitConverter.ToInt32(report.Data, 0);
          Trace.WriteLine(String.Format("Get ClockDeviation: {0}", deviation));
        }
        return deviation;
      }

      public Boolean WriteClockCorrection(Int32 deviation)
      {
        HidReport report = new HidReport((Byte)ReportID.ClockDeviation, BitConverter.GetBytes(deviation));
        Boolean success = myDev.WriteFeatureReport(report);
        if (success)
        {
          Trace.WriteLine(String.Format("Set ClockDeviation: {0}", deviation));
        }
        return success;
      }

      public DateTime? ReadWakeupTime()
      {
        Int64 secs;
        DateTime? wut = null;
        HidReport report = myDev.ReadFeatureReport((Byte)ReportID.WakeupTime);
        if (report != null)
        {
          secs = BitConverter.ToInt32(report.Data, 0);
          wut = new DateTime(secs*10000000, DateTimeKind.Utc);
          wut = wut.Value.AddTicks(defTime.Ticks);
          wut = wut.Value.ToLocalTime();
          Trace.WriteLine(String.Format("Get WakeupTime: {0}", wut));
        }
        return wut;
      }

      public Boolean WriteWakeupTime(DateTime wut)
      {
        Int32 secs;
        Int64 ticks;
        Boolean success = false;
        Byte[] buffer = new Byte[sizeof(Int32)];
        wut = wut.ToUniversalTime();
        if(wut > defTime)
        {
          wut = wut.Subtract(defSpan);
          ticks = wut.Ticks / 10000000;
          secs = (Int32)ticks;
          Buffer.BlockCopy(BitConverter.GetBytes(secs), 0, buffer, 0, 4);
          HidReport report = new HidReport((Byte)ReportID.WakeupTime, buffer);
          success = myDev.WriteFeatureReport(report);
          if (success)
          {
            Trace.WriteLine(String.Format("Set WakeupTime: {0}", wut));
          }
        }
        return success;
      }

      public Byte? ReadWakeupTimeSpan()
      {
        Byte? span = null;
        HidReport report = myDev.ReadFeatureReport((Byte)ReportID.WakeupTimeSpan);
        if (report != null)
        {
          span = report.Data[0];
          Trace.WriteLine(String.Format("Get WakeupTimeSpan: {0}", span));
        }
        return span;
      }

      public Boolean WriteWakeupTimeSpan(Byte span)
      {
        HidReport report = new HidReport((Byte)ReportID.WakeupTimeSpan, span);
        Boolean success = myDev.WriteFeatureReport(report);
        if (success)
        {
          Trace.WriteLine(String.Format("Set WakeupTimeSpan: {0}", span));
        }
        return success;
      }

      #endregion
    }
}
