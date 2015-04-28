using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Timers;
using System.Windows.Forms;
using HIDIRT;

namespace HIDIRT
{
   /// <summary>
   /// Description of Presenter.
   /// </summary>
   public class Presenter
   {
      private readonly String CONFIG_FILE_NAME = "hidirt.xml";
      private readonly String ROOT_TAG = "HIDIRT";
      private readonly String MAPPING_TAG = "Mapping";
      private readonly String SETTING_TAG = "Settings";

      private HIDIRT.hidInterface device;
      private readonly IView view;
      private DataSet config;
      private ControlInvoker controlInvoker;
      private IrCode lastIrCode;

      private System.Timers.Timer refreshTimer = new System.Timers.Timer();

      public Presenter(HIDIRT.hidInterface device, IView view)
      {
         this.view = view;
         controlInvoker = this.view.ctrlInv;
         this.view.DisableControls();
         WireEvents();

         this.device = device;
         device.DeviceAttached += deviceAttached;
         device.DeviceRemoved += deviceRemoved;
         device.IrCodeReceive += deviceIrCodeReceived;
         lastIrCode = null;

         refreshTimer.Elapsed += new ElapsedEventHandler(RefreshStatus);

         LoadXmlConfig();
         SyncClocks();
         deviceAttached(null, null);
      }

      #region GUI event handlers

      public void WireEvents()
      {
         view.UpdateGeneralTab += UpdateGeneralTab;
         view.UpdateIrTab += UpdateIrTab;
         view.UpdateKeymapTab += UpdateKeymapTab;

         view.SaveSettings += SaveSettings;
         view.ReadTime += ReadDeviceTime;
         view.WriteTime += WriteDeviceTime;
         view.WriteTimeCorrection += WriteClockCorrection;
         view.ReadWakeupTime += ReadWakeupTime;
         view.WriteWakeupTime += WriteWakeupTime;
         view.WriteWakeupTimeSpan += WriteWakeupTimeSpan;
         view.WriteControlPcState += WriteControlPcState;
         view.UpdateFirmware += UpdateFirmware;

         view.ClearPowerOnCode += ClearPowerOnCode;
         view.WritePowerOnCode += WritePowerOnCode;
         view.ClearPowerOffCode += ClearPowerOffCode;
         view.WritePowerOffCode += WritePowerOffCode;
         view.ClearResetCode += ClearResetCode;
         view.WriteResetCode += WriteResetCode;
         view.WriteMinRepeats += WriteMinRepeats;
         view.WriteForwardIrState += WriteForwardIrState;
         view.HandleCustomIrCode += HandleCustomIrCode;

         view.SaveAssignment += SaveAssignment;
         view.SendSavedIrCode += SendSavedIrCode;
      }

      #endregion

      #region Device event handlers

      private void deviceAttached(object sender, EventArgs e)
      {
         if (UpdateStatus())
         {
           UpdateGeneralTab();
           UpdateIrTab();
           view.EnableControls();
         }
      }

      private void deviceRemoved(object sender, EventArgs e)
      {
         UpdateGeneralTab();
         UpdateIrTab();
         view.DisableControls();
      }

      private void deviceIrCodeReceived(HIDIRT.IrCode code)
      {
         String expression = String.Format("IrCommand={0} AND IrAddress={1} AND IrProtocol={2}",
                                           code.Command, code.Address, code.Protocol);
         DataRow[] results = config.Tables[MAPPING_TAG].Select(expression);

         if (Convert.ToBoolean(config.Tables[SETTING_TAG].Rows[0]["SendKeyEnabled"]) == true)
         {
            foreach (DataRow mapping in results)
            {
               SendKeys.SendWait(mapping["Key"].ToString());
            }
         }

         if (Convert.ToBoolean(config.Tables[SETTING_TAG].Rows[0]["StartAppEnabled"]) == true)
         {
            foreach (DataRow mapping in results)
            {
               String filename = mapping["Application"].ToString();
               if (filename != "")
               {
                  ProcessStartInfo psi = new ProcessStartInfo(filename, mapping["Parameter"].ToString());
                  if (Path.GetExtension(filename) == ".bat")
                  {
                     psi.WindowStyle = ProcessWindowStyle.Hidden;
                     psi.CreateNoWindow = true;
                  }
                  Process.Start(psi);
               }
            }
         }

         controlInvoker.InvokeControlPropertyWriter("lblLastProtocol", "Text", "0x" + code.Protocol.ToString("X2"));
         controlInvoker.InvokeControlPropertyWriter("lblLastAddress", "Text", "0x" + code.Address.ToString("X4"));
         controlInvoker.InvokeControlPropertyWriter("lblLastCommand", "Text", "0x" + code.Command.ToString("X4"));
         lastIrCode = code;
      }

      #endregion

      #region Configuration

      private void LoadXmlConfig()
      {
         config = new DataSet(ROOT_TAG);
         config.Tables.Add(MAPPING_TAG);
         config.Tables[MAPPING_TAG].Columns.Add("Description", typeof(String));
         config.Tables[MAPPING_TAG].Columns.Add("IrProtocol", typeof(Byte));
         config.Tables[MAPPING_TAG].Columns.Add("IrAddress", typeof(UInt16));
         config.Tables[MAPPING_TAG].Columns.Add("IrCommand", typeof(UInt16));
         config.Tables[MAPPING_TAG].Columns.Add("Key", typeof(String));
         config.Tables[MAPPING_TAG].Columns.Add("Application", typeof(String));
         config.Tables[MAPPING_TAG].Columns.Add("Parameter", typeof(String));

         config.Tables.Add(SETTING_TAG);
         config.Tables[SETTING_TAG].Columns.Add("SendKeyEnabled", typeof(Boolean));
         config.Tables[SETTING_TAG].Columns.Add("StartAppEnabled", typeof(Boolean));
         config.Tables[SETTING_TAG].Columns.Add("SyncClockEnabled", typeof(Boolean));
         config.Tables[SETTING_TAG].Columns.Add("KeepPcClock", typeof(Boolean));

         if (File.Exists(CONFIG_FILE_NAME))
         {
            try
            {
               config.ReadXml(CONFIG_FILE_NAME);
            }
            catch (System.FormatException)
            {
               MessageBox.Show("Format error in config file. Configuration not loaded.",
                               "Config file error",
               MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
         }

         if (config.Tables[SETTING_TAG].Rows.Count == 0)
         {
            DataRow settings = config.Tables[SETTING_TAG].NewRow();
            settings["SendKeyEnabled"] = false;
            settings["StartAppEnabled"] = false;
            settings["SyncClockEnabled"] = false;
            settings["KeepPcClock"] = true;
            config.Tables[SETTING_TAG].Rows.Add(settings);
         }
      }

      private void SaveXmlConfig()
      {
         config.WriteXml(CONFIG_FILE_NAME);
      }

      private void SyncClocks()
      {
         if (Convert.ToBoolean(config.Tables[SETTING_TAG].Rows[0]["SyncClockEnabled"]) == true)
         {
            TimeSpan deviation = new TimeSpan(0, 0, 30);
            DateTime? readTime = device.ReadDeviceTime();
            DateTime devTime = readTime ?? default(DateTime);

            if (readTime != null)
            {
               // if read value is valid and deviation is bigger than 30 seconds
               if ((DateTime.Compare(devTime, DateTime.MaxValue) < 0)
               && ((DateTime.Compare(devTime.Add(deviation), DateTime.UtcNow) > 0) ||
                   (DateTime.Compare(devTime.Subtract(deviation), DateTime.UtcNow) < 0)))
               {
                  // if PC time shall be kept (that means device time shall be adjusted) or
                  // if the device time is more than ten days behind
                  if ((Convert.ToBoolean(config.Tables[SETTING_TAG].Rows[0]["KeepPcClock"]) == true)
                  || (DateTime.Now.Subtract(new TimeSpan(864000)) > readTime))
                  {
                     device.WriteDeviceTime(DateTime.UtcNow);
                  }
                  else
                  {
                     NativeW32Time.SetSystemTime(devTime);
                  }
               }
            }
         }
      }

      #endregion

      #region FormUpdate

      private Boolean UpdateStatus()
      {
         String firmware = device.ReadFirmwareVersion();
         if ((firmware != "none") && (firmware != "Connection failed.") && (firmware != ""))
         {
            controlInvoker.InvokeControlPropertyWriter("lblConnectionStatus", "Text", "Device connected");
            controlInvoker.InvokeControlPropertyWriter("lblConnectionStatus", "ForeColor", Color.Green);
            controlInvoker.InvokeControlPropertyWriter("lblFirmware", "Text", firmware);
            return true;
         }
         else
         {
            controlInvoker.InvokeControlPropertyWriter("lblConnectionStatus", "Text", "Device not found");
            controlInvoker.InvokeControlPropertyWriter("lblConnectionStatus", "ForeColor", Color.Red);
            controlInvoker.InvokeControlPropertyWriter("lblFirmware", "Text", "none");
            return false;
         }
      }

      public void UpdateGeneralTab()
      {
         UpdateStatus();
         ReadSendKeyState();
         ReadStartAppState();
         ReadSyncClockConfig();
         ReadDeviceTime();
         ReadClockCorrection();
         ReadWakeupTime();
         ReadWakeupTimeSpan();
         ReadControlPcState();
      }

      public void UpdateIrTab()
      {
         UpdateStatus();
         ReadPowerOnCode();
         ReadPowerOffCode();
         ReadResetCode();
         ReadForwardIrState();
         ReadMinRepeats();
      }

      public void UpdateKeymapTab()
      {
         UpdateStatus();
         LoadXmlConfig();
         view.assignment = config.Tables[MAPPING_TAG];
      }

      #endregion

      #region General tab

      public void ReadSendKeyState()
      {
         controlInvoker.InvokeControlPropertyWriter("chbEnableKeySend", "Checked",
         Convert.ToBoolean(config.Tables[SETTING_TAG].Rows[0]["SendKeyEnabled"]));
      }

      public void ReadStartAppState()
      {
         controlInvoker.InvokeControlPropertyWriter("chbEnableAppStart", "Checked",
         Convert.ToBoolean(config.Tables[SETTING_TAG].Rows[0]["StartAppEnabled"]));
      }

      public void ReadSyncClockConfig()
      {
         controlInvoker.InvokeControlPropertyWriter("chbEnableSyncClocks", "Checked",
         Convert.ToBoolean(config.Tables[SETTING_TAG].Rows[0]["SyncClockEnabled"]));
         controlInvoker.InvokeControlPropertyWriter("rdbKeepPcTime", "Enabled",
         Convert.ToBoolean(config.Tables[SETTING_TAG].Rows[0]["SyncClockEnabled"]));
         controlInvoker.InvokeControlPropertyWriter("rdbKeepDevTime", "Enabled",
         Convert.ToBoolean(config.Tables[SETTING_TAG].Rows[0]["SyncClockEnabled"]));

         controlInvoker.InvokeControlPropertyWriter("rdbKeepPcTime", "Checked",
         Convert.ToBoolean(config.Tables[SETTING_TAG].Rows[0]["KeepPcClock"]));
         controlInvoker.InvokeControlPropertyWriter("rdbKeepDevTime", "Checked",
         !Convert.ToBoolean(config.Tables[SETTING_TAG].Rows[0]["KeepPcClock"]));
      }

      public void SaveSettings()
      {
         Object state;
         state = controlInvoker.InvokeControlPropertyReader("chbEnableKeySend", "Checked");
         config.Tables[SETTING_TAG].Rows[0]["SendKeyEnabled"] = Convert.ToBoolean(state);
         state = controlInvoker.InvokeControlPropertyReader("chbEnableAppStart", "Checked");
         config.Tables[SETTING_TAG].Rows[0]["StartAppEnabled"] = Convert.ToBoolean(state);
         state = controlInvoker.InvokeControlPropertyReader("chbEnableSyncClocks", "Checked");
         config.Tables[SETTING_TAG].Rows[0]["SyncClockEnabled"] = Convert.ToBoolean(state);
         state = controlInvoker.InvokeControlPropertyReader("rdbKeepPcTime", "Checked");
         config.Tables[SETTING_TAG].Rows[0]["KeepPcClock"] = Convert.ToBoolean(state);

         while (config.Tables[SETTING_TAG].Rows.Count > 1)
         {
            config.Tables[SETTING_TAG].Rows[1].Delete();
         }

         SaveXmlConfig();
         ReadSendKeyState();
         ReadStartAppState();
         ReadSyncClockConfig();
      }

      public void ReadDeviceTime()
      {
         DateTime? readTime = device.ReadDeviceTime();
         DateTime devTime = readTime ?? hidInterface.defTime;

         if (readTime != null)
         {
           controlInvoker.InvokeControlPropertyWriter("dtpTime", "CustomFormat", "dd MMM yyyy     HH:mm:ss");
           controlInvoker.InvokeControlPropertyWriter("lblDeviceTime", "Text", devTime.ToString());
         }
         else
         {
           controlInvoker.InvokeControlPropertyWriter("dtpTime", "CustomFormat", " ");
           controlInvoker.InvokeControlPropertyWriter("lblDeviceTime", "Text", "");
         }
         controlInvoker.InvokeControlPropertyWriter("dtpTime", "Value", devTime);
      }

      public void WriteDeviceTime()
      {
         //Object time = controlInvoker.InvokeControlPropertyReader("dtpTime", "Value");
         //device.WriteDeviceTime(Convert.ToDateTime(time));
         device.WriteDeviceTime(DateTime.Now);
         ReadDeviceTime();
      }

      public void ReadClockCorrection()
      {
         controlInvoker.InvokeControlPropertyWriter("numClockDeviation", "Value", Convert.ToDecimal(device.ReadClockCorrection()));
      }

      public void WriteClockCorrection()
      {
         Object timeCorrection = controlInvoker.InvokeControlPropertyReader("numClockDeviation", "Value");
         device.WriteClockCorrection(Convert.ToInt32(timeCorrection));
         ReadClockCorrection();
      }

      public void ReadWakeupTime()
      {
         DateTime? readTime = device.ReadWakeupTime();
         DateTime wuTime = readTime ?? hidInterface.defTime;

         if (readTime != null)
         {
           controlInvoker.InvokeControlPropertyWriter("dtpWakeupTime", "CustomFormat", "dd MMM yyyy     HH:mm:ss");
           controlInvoker.InvokeControlPropertyWriter("lblWakeupTime", "Text", wuTime.ToString());
         }
         else
         {
           controlInvoker.InvokeControlPropertyWriter("dtpWakeupTime", "CustomFormat", " ");
           controlInvoker.InvokeControlPropertyWriter("lblWakeupTime", "Text", "");
         }
         controlInvoker.InvokeControlPropertyWriter("dtpWakeupTime", "Value", wuTime);
      }

      public void WriteWakeupTime()
      {
         Object wakeupTime = controlInvoker.InvokeControlPropertyReader("dtpWakeupTime", "Value");
         device.WriteWakeupTime(Convert.ToDateTime(wakeupTime));
         ReadWakeupTime();
      }

      public void ReadWakeupTimeSpan()
      {
         controlInvoker.InvokeControlPropertyWriter("numWakeupTimeSpan", "Value", Convert.ToDecimal(device.ReadWakeupTimeSpan()));
      }

      public void WriteWakeupTimeSpan()
      {
         Object wakeupTimeSpan = controlInvoker.InvokeControlPropertyReader("numWakeupTimeSpan", "Value");
         device.WriteWakeupTimeSpan(Convert.ToByte(wakeupTimeSpan));
         ReadWakeupTimeSpan();
      }

      public void ReadControlPcState()
      {
         Boolean? state = device.ReadControlPcState();
         if (state != null)
         {
           if (state == true)
           {
              controlInvoker.InvokeControlPropertyWriter("lblControlPcButtons", "Text", "Enabled");
              controlInvoker.InvokeControlPropertyWriter("lblControlPcButtons", "ForeColor", Color.Green);
              controlInvoker.InvokeControlPropertyWriter("btnControlPcButtons", "Text", "Disable");
           }
           else
           {
              controlInvoker.InvokeControlPropertyWriter("lblControlPcButtons", "Text", "Disabled");
              controlInvoker.InvokeControlPropertyWriter("lblControlPcButtons", "ForeColor", Color.Red);
              controlInvoker.InvokeControlPropertyWriter("btnControlPcButtons", "Text", "Enable");
           }
         }
         else
         {
           controlInvoker.InvokeControlPropertyWriter("lblControlPcButtons", "Text", "");
         }
      }

      public void WriteControlPcState()
      {
         Boolean state;
         Object controlPcButtons = controlInvoker.InvokeControlPropertyReader("btnControlPcButtons", "Text");
         if (Convert.ToString(controlPcButtons) == "Enable")
         {
            state = true;
         }
         else
         {
            state = false;
         }
         device.WriteControlPcState(state);
         ReadControlPcState();
      }

      public void UpdateFirmware()
      {
         #warning not implemented
      }

      #endregion

      #region IR tasks

      public void ReadPowerOnCode()
      {
         IrCode code = device.ReadIrCode(HIDIRT.hidInterface.ReportID.PowerOnCode);
         if (code != null)
         {
            controlInvoker.InvokeControlPropertyWriter("lblPowerOnProtocol", "Text", "0x" + code.Protocol.ToString("X2"));
            controlInvoker.InvokeControlPropertyWriter("lblPowerOnAddress", "Text", "0x" + code.Address.ToString("X4"));
            controlInvoker.InvokeControlPropertyWriter("lblPowerOnCommand", "Text", "0x" + code.Command.ToString("X4"));
         }
      }

      public void ClearPowerOnCode()
      {
         device.WriteIrCode(HIDIRT.hidInterface.ReportID.PowerOnCode, new IrCode(0, 0, 0));
         ReadPowerOnCode();
      }

      public void WritePowerOnCode()
      {
         if (lastIrCode != null)
         {
            device.WriteIrCode(HIDIRT.hidInterface.ReportID.PowerOnCode, lastIrCode);
            ReadPowerOnCode();
         }
      }

      public void ReadPowerOffCode()
      {
         IrCode code = device.ReadIrCode(HIDIRT.hidInterface.ReportID.PowerOffCode);
         if (code != null)
         {
            controlInvoker.InvokeControlPropertyWriter("lblPowerOffProtocol", "Text", "0x" + code.Protocol.ToString("X2"));
            controlInvoker.InvokeControlPropertyWriter("lblPowerOffAddress", "Text", "0x" + code.Address.ToString("X4"));
            controlInvoker.InvokeControlPropertyWriter("lblPowerOffCommand", "Text", "0x" + code.Command.ToString("X4"));
         }
      }

      public void ClearPowerOffCode()
      {
         device.WriteIrCode(HIDIRT.hidInterface.ReportID.PowerOffCode, new IrCode(0, 0, 0));
         ReadPowerOffCode();
      }

      public void WritePowerOffCode()
      {
         if (lastIrCode != null)
         {
            device.WriteIrCode(HIDIRT.hidInterface.ReportID.PowerOffCode, lastIrCode);
            ReadPowerOffCode();
         }
      }

      public void ReadResetCode()
      {
         IrCode code = device.ReadIrCode(HIDIRT.hidInterface.ReportID.ResetCode);
         if (code != null)
         {
            controlInvoker.InvokeControlPropertyWriter("lblResetProtocol", "Text", "0x" + code.Protocol.ToString("X2"));
            controlInvoker.InvokeControlPropertyWriter("lblResetAddress", "Text", "0x" + code.Address.ToString("X4"));
            controlInvoker.InvokeControlPropertyWriter("lblResetCommand", "Text", "0x" + code.Command.ToString("X4"));
         }
      }

      public void ClearResetCode()
      {
         device.WriteIrCode(HIDIRT.hidInterface.ReportID.ResetCode, new IrCode(0, 0, 0));
         ReadResetCode();
      }

      public void WriteResetCode()
      {
         if (lastIrCode != null)
         {
            device.WriteIrCode(HIDIRT.hidInterface.ReportID.ResetCode, lastIrCode);
            ReadResetCode();
         }
      }

      public void ReadMinRepeats()
      {
         controlInvoker.InvokeControlPropertyWriter("numMinRepeats", "Value", Convert.ToDecimal(device.ReadMinRepeats()));
      }

      public void WriteMinRepeats()
      {
         Object minRepeats = controlInvoker.InvokeControlPropertyReader("numMinRepeats", "Value");
         device.WriteMinRepeats(Convert.ToByte(minRepeats));
         ReadMinRepeats();
      }

      public void ReadForwardIrState()
      {
         Boolean? state = device.ReadForwardIrState();
         if (state != null)
         {
           if (state == true)
           {
              controlInvoker.InvokeControlPropertyWriter("lblForwardIrState", "Text", "Enabled");
              controlInvoker.InvokeControlPropertyWriter("lblForwardIrState", "ForeColor", Color.Green);
              controlInvoker.InvokeControlPropertyWriter("btnForwardIrState", "Text", "Disable");
           }
           else
           {
              controlInvoker.InvokeControlPropertyWriter("lblForwardIrState", "Text", "Disabled");
              controlInvoker.InvokeControlPropertyWriter("lblForwardIrState", "ForeColor", Color.Red);
              controlInvoker.InvokeControlPropertyWriter("btnForwardIrState", "Text", "Enable");
           }
         }
         else
         {
           controlInvoker.InvokeControlPropertyWriter("lblForwardIrState", "Text", "");
         }
      }

      public void WriteForwardIrState()
      {
         Boolean state;
         Object forwardIrState = controlInvoker.InvokeControlPropertyReader("btnForwardIrState", "Text");
         if (Convert.ToString(forwardIrState) == "Enable")
         {
            state = true;
         }
         else
         {
            state = false;
         }
         device.WriteForwardIrState(state);
         ReadForwardIrState();
      }

      public void HandleCustomIrCode()
      {
         Object protocol = controlInvoker.InvokeControlPropertyReader("numSendIrProtocol", "Value");
         Object address = controlInvoker.InvokeControlPropertyReader("numSendIrAddress", "Value");
         Object command = controlInvoker.InvokeControlPropertyReader("numSendIrCommand", "Value");

         Boolean powerOff = (Boolean)controlInvoker.InvokeControlPropertyReader("chbSetPowerOffCode", "Checked");
         Boolean powerOn = (Boolean)controlInvoker.InvokeControlPropertyReader("chbSetPowerOnCode", "Checked");
         Boolean reset = (Boolean)controlInvoker.InvokeControlPropertyReader("chbSetResetCode", "Checked");

         IrCode customCode = new IrCode(Convert.ToByte(protocol), Convert.ToUInt16(address), Convert.ToUInt16(command));

         if (powerOff)
         {
           device.WriteIrCode(HIDIRT.hidInterface.ReportID.PowerOffCode, customCode);
           ReadPowerOffCode();
         }

         if (powerOn)
         {
           device.WriteIrCode(HIDIRT.hidInterface.ReportID.PowerOnCode, customCode);
           ReadPowerOnCode();
         }

         if (reset)
         {
           device.WriteIrCode(HIDIRT.hidInterface.ReportID.ResetCode, customCode);
           ReadResetCode();
         }

         if (!powerOff && !powerOn && !reset)
         {
           device.SendIrCode(customCode);
         }
      }

      #endregion

      #region Keymap tasks

      public void SaveAssignment()
      {
         if (config.Tables.Contains(MAPPING_TAG))
         {
            config.Tables.Remove(MAPPING_TAG);
         }
         config.Tables.Add(view.assignment);
         SaveXmlConfig();
      }

      public void SendSavedIrCode(IrCode code)
      {
        device.SendIrCode(code);
      }

      #endregion

      /// <summary>
      /// Writing to RefreshTime loads a timer with that value and starts it.
      /// When the time expires the device time and the wakeup time will be
      /// read and the according controls will be updated.
      /// </summary>
      public Double RefreshTime
      {
         get {return refreshTimer.Interval;}
         set
         {
            refreshTimer.Stop();
            refreshTimer.Interval = value;
            refreshTimer.Start();
         }
      }

      private void RefreshStatus(object source, ElapsedEventArgs e)
      {
         ReadDeviceTime();
         ReadWakeupTime();
      }
   }
}
