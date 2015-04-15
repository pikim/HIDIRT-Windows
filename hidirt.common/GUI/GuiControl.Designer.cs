namespace HIDIRT
{
  partial class GuiControl
  {
//    private System.Windows.Forms.OpenFileDialog openFileDialog;
    private System.ComponentModel.IContainer components = null;
  
    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GuiControl));
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      this.btnReadTime = new System.Windows.Forms.Button();
      this.btnWriteTime = new System.Windows.Forms.Button();
      this.btnSetClockDeviation = new System.Windows.Forms.Button();
      this.btnReadWakeupTime = new System.Windows.Forms.Button();
      this.btnWriteWakeupTime = new System.Windows.Forms.Button();
      this.btnSetWakeupTimeSpan = new System.Windows.Forms.Button();
      this.btnClearResetCode = new System.Windows.Forms.Button();
      this.btnWriteResetCode = new System.Windows.Forms.Button();
      this.btnClearPowerOffCode = new System.Windows.Forms.Button();
      this.btnWritePowerOffCode = new System.Windows.Forms.Button();
      this.btnClearPowerOnCode = new System.Windows.Forms.Button();
      this.btnWritePowerOnCode = new System.Windows.Forms.Button();
      this.btnSetMinRepeats = new System.Windows.Forms.Button();
      this.btnForwardIrState = new System.Windows.Forms.Button();
      this.btnSendIrCode = new System.Windows.Forms.Button();
      this.btnAssignCode = new System.Windows.Forms.Button();
      this.btnSaveKeymap = new System.Windows.Forms.Button();
      this.groupBoxStatus = new System.Windows.Forms.GroupBox();
      this.lblLastCommand = new System.Windows.Forms.Label();
      this.lblLastAddress = new System.Windows.Forms.Label();
      this.lblLastProtocol = new System.Windows.Forms.Label();
      this.label53 = new System.Windows.Forms.Label();
      this.label52 = new System.Windows.Forms.Label();
      this.label51 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.lblConnectionStatus = new System.Windows.Forms.Label();
      this.lblDeviceTime = new System.Windows.Forms.Label();
      this.lblFirmware = new System.Windows.Forms.Label();
      this.lblWakeupTime = new System.Windows.Forms.Label();
      this.groupBoxClockSchedule = new System.Windows.Forms.GroupBox();
      this.groupBox15 = new System.Windows.Forms.GroupBox();
      this.btnControlPcButtons = new System.Windows.Forms.Button();
      this.lblControlPcButtons = new System.Windows.Forms.Label();
      this.btnUpdateFirmware = new System.Windows.Forms.Button();
      this.groupBox10 = new System.Windows.Forms.GroupBox();
      this.chbEnableSyncClocks = new System.Windows.Forms.CheckBox();
      this.rdbKeepPcTime = new System.Windows.Forms.RadioButton();
      this.rdbKeepDevTime = new System.Windows.Forms.RadioButton();
      this.chbEnableKeySend = new System.Windows.Forms.CheckBox();
      this.btnSaveSettings = new System.Windows.Forms.Button();
      this.chbEnableAppStart = new System.Windows.Forms.CheckBox();
      this.groupBox11 = new System.Windows.Forms.GroupBox();
      this.dtpTime = new System.Windows.Forms.DateTimePicker();
      this.label10 = new System.Windows.Forms.Label();
      this.groupBox12 = new System.Windows.Forms.GroupBox();
      this.numClockDeviation = new System.Windows.Forms.NumericUpDown();
      this.label11 = new System.Windows.Forms.Label();
      this.label12 = new System.Windows.Forms.Label();
      this.groupBox13 = new System.Windows.Forms.GroupBox();
      this.dtpWakeupTime = new System.Windows.Forms.DateTimePicker();
      this.groupBox14 = new System.Windows.Forms.GroupBox();
      this.numWakeupTimeSpan = new System.Windows.Forms.NumericUpDown();
      this.label13 = new System.Windows.Forms.Label();
      this.groupBoxInfrared = new System.Windows.Forms.GroupBox();
      this.groupBox20 = new System.Windows.Forms.GroupBox();
      this.lblPowerOnProtocol = new System.Windows.Forms.Label();
      this.lblPowerOnAddress = new System.Windows.Forms.Label();
      this.lblPowerOnCommand = new System.Windows.Forms.Label();
      this.label22 = new System.Windows.Forms.Label();
      this.label21 = new System.Windows.Forms.Label();
      this.label20 = new System.Windows.Forms.Label();
      this.groupBox21 = new System.Windows.Forms.GroupBox();
      this.lblPowerOffProtocol = new System.Windows.Forms.Label();
      this.lblPowerOffAddress = new System.Windows.Forms.Label();
      this.lblPowerOffCommand = new System.Windows.Forms.Label();
      this.label25 = new System.Windows.Forms.Label();
      this.label24 = new System.Windows.Forms.Label();
      this.label23 = new System.Windows.Forms.Label();
      this.groupBox22 = new System.Windows.Forms.GroupBox();
      this.lblResetProtocol = new System.Windows.Forms.Label();
      this.lblResetAddress = new System.Windows.Forms.Label();
      this.lblResetCommand = new System.Windows.Forms.Label();
      this.label26 = new System.Windows.Forms.Label();
      this.label27 = new System.Windows.Forms.Label();
      this.label28 = new System.Windows.Forms.Label();
      this.groupBox23 = new System.Windows.Forms.GroupBox();
      this.numMinRepeats = new System.Windows.Forms.NumericUpDown();
      this.label29 = new System.Windows.Forms.Label();
      this.groupBox24 = new System.Windows.Forms.GroupBox();
      this.lblForwardIrState = new System.Windows.Forms.Label();
      this.groupBox25 = new System.Windows.Forms.GroupBox();
      this.numSendIrProtocol = new System.Windows.Forms.NumericUpDown();
      this.numSendIrAddress = new System.Windows.Forms.NumericUpDown();
      this.numSendIrCommand = new System.Windows.Forms.NumericUpDown();
      this.label30 = new System.Windows.Forms.Label();
      this.label31 = new System.Windows.Forms.Label();
      this.label32 = new System.Windows.Forms.Label();
      this.label33 = new System.Windows.Forms.Label();
      this.label34 = new System.Windows.Forms.Label();
      this.label35 = new System.Windows.Forms.Label();
      this.groupBoxKeymap = new System.Windows.Forms.GroupBox();
      this.label6 = new System.Windows.Forms.Label();
      this.btnAssignApp = new System.Windows.Forms.Button();
      this.dgvKeymap = new System.Windows.Forms.DataGridView();
      this.tabControl = new System.Windows.Forms.TabControl();
      this.tabPageGeneral = new System.Windows.Forms.TabPage();
      this.tabPageInfrared = new System.Windows.Forms.TabPage();
      this.tabPageKeymap = new System.Windows.Forms.TabPage();
      this.toolTip = new System.Windows.Forms.ToolTip(this.components);
      this.groupBoxStatus.SuspendLayout();
      this.groupBoxClockSchedule.SuspendLayout();
      this.groupBox15.SuspendLayout();
      this.groupBox10.SuspendLayout();
      this.groupBox11.SuspendLayout();
      this.groupBox12.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numClockDeviation)).BeginInit();
      this.groupBox13.SuspendLayout();
      this.groupBox14.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numWakeupTimeSpan)).BeginInit();
      this.groupBoxInfrared.SuspendLayout();
      this.groupBox20.SuspendLayout();
      this.groupBox21.SuspendLayout();
      this.groupBox22.SuspendLayout();
      this.groupBox23.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numMinRepeats)).BeginInit();
      this.groupBox24.SuspendLayout();
      this.groupBox25.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numSendIrProtocol)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numSendIrAddress)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numSendIrCommand)).BeginInit();
      this.groupBoxKeymap.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvKeymap)).BeginInit();
      this.tabControl.SuspendLayout();
      this.tabPageGeneral.SuspendLayout();
      this.tabPageInfrared.SuspendLayout();
      this.tabPageKeymap.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnReadTime
      // 
      this.btnReadTime.Location = new System.Drawing.Point(6, 45);
      this.btnReadTime.Name = "btnReadTime";
      this.btnReadTime.Size = new System.Drawing.Size(87, 23);
      this.btnReadTime.TabIndex = 1;
      this.btnReadTime.Text = "Read";
      this.toolTip.SetToolTip(this.btnReadTime, "Read the time from the device.");
      this.btnReadTime.UseVisualStyleBackColor = true;
      this.btnReadTime.Click += new System.EventHandler(this.BtnReadTimeClick);
      // 
      // btnWriteTime
      // 
      this.btnWriteTime.Location = new System.Drawing.Point(99, 45);
      this.btnWriteTime.Name = "btnWriteTime";
      this.btnWriteTime.Size = new System.Drawing.Size(87, 23);
      this.btnWriteTime.TabIndex = 2;
      this.btnWriteTime.Text = "Write";
      this.toolTip.SetToolTip(this.btnWriteTime, "Write above time to device. Overwrites currently stored time.");
      this.btnWriteTime.UseVisualStyleBackColor = true;
      this.btnWriteTime.Click += new System.EventHandler(this.BtnWriteTimeClick);
      // 
      // btnSetClockDeviation
      // 
      this.btnSetClockDeviation.Location = new System.Drawing.Point(122, 16);
      this.btnSetClockDeviation.Name = "btnSetClockDeviation";
      this.btnSetClockDeviation.Size = new System.Drawing.Size(64, 23);
      this.btnSetClockDeviation.TabIndex = 2;
      this.btnSetClockDeviation.Text = "Set";
      this.toolTip.SetToolTip(this.btnSetClockDeviation, "Set compensation value if the device clock is running\r\ntoo fast or too slow (expe" +
            "rimental feature).");
      this.btnSetClockDeviation.UseVisualStyleBackColor = true;
      this.btnSetClockDeviation.Click += new System.EventHandler(this.BtnSetClockCorrectionClick);
      // 
      // btnReadWakeupTime
      // 
      this.btnReadWakeupTime.Location = new System.Drawing.Point(6, 45);
      this.btnReadWakeupTime.Name = "btnReadWakeupTime";
      this.btnReadWakeupTime.Size = new System.Drawing.Size(87, 23);
      this.btnReadWakeupTime.TabIndex = 1;
      this.btnReadWakeupTime.Text = "Read";
      this.toolTip.SetToolTip(this.btnReadWakeupTime, "Read programmed wake-up time from the device.");
      this.btnReadWakeupTime.UseVisualStyleBackColor = true;
      this.btnReadWakeupTime.Click += new System.EventHandler(this.BtnReadWakeupTimeClick);
      // 
      // btnWriteWakeupTime
      // 
      this.btnWriteWakeupTime.Location = new System.Drawing.Point(99, 45);
      this.btnWriteWakeupTime.Name = "btnWriteWakeupTime";
      this.btnWriteWakeupTime.Size = new System.Drawing.Size(87, 23);
      this.btnWriteWakeupTime.TabIndex = 2;
      this.btnWriteWakeupTime.Text = "Write";
      this.toolTip.SetToolTip(this.btnWriteWakeupTime, "Write above wakeup-time to device. Overwrites currently stored time.");
      this.btnWriteWakeupTime.UseVisualStyleBackColor = true;
      this.btnWriteWakeupTime.Click += new System.EventHandler(this.BtnWriteWakeupTimeClick);
      // 
      // btnSetWakeupTimeSpan
      // 
      this.btnSetWakeupTimeSpan.Location = new System.Drawing.Point(122, 16);
      this.btnSetWakeupTimeSpan.Name = "btnSetWakeupTimeSpan";
      this.btnSetWakeupTimeSpan.Size = new System.Drawing.Size(64, 23);
      this.btnSetWakeupTimeSpan.TabIndex = 2;
      this.btnSetWakeupTimeSpan.Text = "Set";
      this.toolTip.SetToolTip(this.btnSetWakeupTimeSpan, "Wake the PC between wakeup time and wakeup\r\ntime plus time span in case of an AC " +
            "power loss.");
      this.btnSetWakeupTimeSpan.UseVisualStyleBackColor = true;
      this.btnSetWakeupTimeSpan.Click += new System.EventHandler(this.BtnSetWakeupTimeSpanClick);
      // 
      // btnClearResetCode
      // 
      this.btnClearResetCode.Location = new System.Drawing.Point(6, 58);
      this.btnClearResetCode.Name = "btnClearResetCode";
      this.btnClearResetCode.Size = new System.Drawing.Size(87, 23);
      this.btnClearResetCode.TabIndex = 6;
      this.btnClearResetCode.Text = "Clear";
      this.toolTip.SetToolTip(this.btnClearResetCode, "Clear the stored code that resets the host.");
      this.btnClearResetCode.UseVisualStyleBackColor = true;
      this.btnClearResetCode.Click += new System.EventHandler(this.BtnClearResetClick);
      // 
      // btnWriteResetCode
      // 
      this.btnWriteResetCode.Location = new System.Drawing.Point(99, 58);
      this.btnWriteResetCode.Name = "btnWriteResetCode";
      this.btnWriteResetCode.Size = new System.Drawing.Size(87, 23);
      this.btnWriteResetCode.TabIndex = 7;
      this.btnWriteResetCode.Text = "Write";
      this.toolTip.SetToolTip(this.btnWriteResetCode, "Store the last received code as code that resets the host (when pressed 3 times w" +
            "ithout interrupt).");
      this.btnWriteResetCode.UseVisualStyleBackColor = true;
      this.btnWriteResetCode.Click += new System.EventHandler(this.BtnWriteResetClick);
      // 
      // btnClearPowerOffCode
      // 
      this.btnClearPowerOffCode.Location = new System.Drawing.Point(6, 58);
      this.btnClearPowerOffCode.Name = "btnClearPowerOffCode";
      this.btnClearPowerOffCode.Size = new System.Drawing.Size(87, 23);
      this.btnClearPowerOffCode.TabIndex = 6;
      this.btnClearPowerOffCode.Text = "Clear";
      this.toolTip.SetToolTip(this.btnClearPowerOffCode, "Clear the stored code that shuts the host down.");
      this.btnClearPowerOffCode.UseVisualStyleBackColor = true;
      this.btnClearPowerOffCode.Click += new System.EventHandler(this.BtnClearPowerOffClick);
      // 
      // btnWritePowerOffCode
      // 
      this.btnWritePowerOffCode.Location = new System.Drawing.Point(99, 58);
      this.btnWritePowerOffCode.Name = "btnWritePowerOffCode";
      this.btnWritePowerOffCode.Size = new System.Drawing.Size(87, 23);
      this.btnWritePowerOffCode.TabIndex = 7;
      this.btnWritePowerOffCode.Text = "Write";
      this.toolTip.SetToolTip(this.btnWritePowerOffCode, "Store the last received code as code that shuts the host down.");
      this.btnWritePowerOffCode.UseVisualStyleBackColor = true;
      this.btnWritePowerOffCode.Click += new System.EventHandler(this.BtnWritePowerOffClick);
      // 
      // btnClearPowerOnCode
      // 
      this.btnClearPowerOnCode.Location = new System.Drawing.Point(6, 58);
      this.btnClearPowerOnCode.Name = "btnClearPowerOnCode";
      this.btnClearPowerOnCode.Size = new System.Drawing.Size(87, 23);
      this.btnClearPowerOnCode.TabIndex = 6;
      this.btnClearPowerOnCode.Text = "Clear";
      this.toolTip.SetToolTip(this.btnClearPowerOnCode, "Clear the stored code that wakes up the host.");
      this.btnClearPowerOnCode.UseVisualStyleBackColor = true;
      this.btnClearPowerOnCode.Click += new System.EventHandler(this.BtnClearPowerOnClick);
      // 
      // btnWritePowerOnCode
      // 
      this.btnWritePowerOnCode.Location = new System.Drawing.Point(99, 58);
      this.btnWritePowerOnCode.Name = "btnWritePowerOnCode";
      this.btnWritePowerOnCode.Size = new System.Drawing.Size(87, 23);
      this.btnWritePowerOnCode.TabIndex = 7;
      this.btnWritePowerOnCode.Text = "Write";
      this.toolTip.SetToolTip(this.btnWritePowerOnCode, "Store the last received code as code that wakes up the host.");
      this.btnWritePowerOnCode.UseVisualStyleBackColor = true;
      this.btnWritePowerOnCode.Click += new System.EventHandler(this.BtnWritePowerOnClick);
      // 
      // btnSetMinRepeats
      // 
      this.btnSetMinRepeats.Location = new System.Drawing.Point(122, 16);
      this.btnSetMinRepeats.Name = "btnSetMinRepeats";
      this.btnSetMinRepeats.Size = new System.Drawing.Size(64, 23);
      this.btnSetMinRepeats.TabIndex = 2;
      this.btnSetMinRepeats.Text = "Set";
      this.toolTip.SetToolTip(this.btnSetMinRepeats, resources.GetString("btnSetMinRepeats.ToolTip"));
      this.btnSetMinRepeats.UseVisualStyleBackColor = true;
      this.btnSetMinRepeats.Click += new System.EventHandler(this.BtnSetMinRepeatsClick);
      // 
      // btnForwardIrState
      // 
      this.btnForwardIrState.Location = new System.Drawing.Point(122, 16);
      this.btnForwardIrState.Name = "btnForwardIrState";
      this.btnForwardIrState.Size = new System.Drawing.Size(64, 23);
      this.btnForwardIrState.TabIndex = 1;
      this.btnForwardIrState.Text = "Enable";
      this.toolTip.SetToolTip(this.btnForwardIrState, "Enable/Disable forwarding of received IR codes to other devices.");
      this.btnForwardIrState.UseVisualStyleBackColor = true;
      this.btnForwardIrState.Click += new System.EventHandler(this.BtnForwardIrCodesClick);
      // 
      // btnSendIrCode
      // 
      this.btnSendIrCode.Location = new System.Drawing.Point(122, 92);
      this.btnSendIrCode.Name = "btnSendIrCode";
      this.btnSendIrCode.Size = new System.Drawing.Size(64, 23);
      this.btnSendIrCode.TabIndex = 9;
      this.btnSendIrCode.Text = "Send";
      this.toolTip.SetToolTip(this.btnSendIrCode, "Send IR code specified above. Can be used to teach a code to an infrared remote.");
      this.btnSendIrCode.UseVisualStyleBackColor = true;
      this.btnSendIrCode.Click += new System.EventHandler(this.BtnSendIrCodeClick);
      // 
      // btnAssignCode
      // 
      this.btnAssignCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnAssignCode.AutoSize = true;
      this.btnAssignCode.Location = new System.Drawing.Point(6, 282);
      this.btnAssignCode.Name = "btnAssignCode";
      this.btnAssignCode.Size = new System.Drawing.Size(105, 23);
      this.btnAssignCode.TabIndex = 1;
      this.btnAssignCode.Text = "Assign IR code";
      this.toolTip.SetToolTip(this.btnAssignCode, "Assign last received IR code to selection.");
      this.btnAssignCode.UseVisualStyleBackColor = true;
      this.btnAssignCode.Click += new System.EventHandler(this.BtnAssignCodeClick);
      // 
      // btnSaveKeymap
      // 
      this.btnSaveKeymap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnSaveKeymap.AutoSize = true;
      this.btnSaveKeymap.Location = new System.Drawing.Point(394, 282);
      this.btnSaveKeymap.Name = "btnSaveKeymap";
      this.btnSaveKeymap.Size = new System.Drawing.Size(64, 23);
      this.btnSaveKeymap.TabIndex = 3;
      this.btnSaveKeymap.Text = "Save";
      this.toolTip.SetToolTip(this.btnSaveKeymap, "Save assignment table.");
      this.btnSaveKeymap.UseVisualStyleBackColor = true;
      this.btnSaveKeymap.Click += new System.EventHandler(this.BtnSaveAssignmentClick);
      // 
      // groupBoxStatus
      // 
      this.groupBoxStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBoxStatus.BackColor = System.Drawing.SystemColors.Control;
      this.groupBoxStatus.Controls.Add(this.lblLastCommand);
      this.groupBoxStatus.Controls.Add(this.lblLastAddress);
      this.groupBoxStatus.Controls.Add(this.lblLastProtocol);
      this.groupBoxStatus.Controls.Add(this.label53);
      this.groupBoxStatus.Controls.Add(this.label52);
      this.groupBoxStatus.Controls.Add(this.label51);
      this.groupBoxStatus.Controls.Add(this.label1);
      this.groupBoxStatus.Controls.Add(this.label2);
      this.groupBoxStatus.Controls.Add(this.label3);
      this.groupBoxStatus.Controls.Add(this.label4);
      this.groupBoxStatus.Controls.Add(this.label5);
      this.groupBoxStatus.Controls.Add(this.lblConnectionStatus);
      this.groupBoxStatus.Controls.Add(this.lblDeviceTime);
      this.groupBoxStatus.Controls.Add(this.lblFirmware);
      this.groupBoxStatus.Controls.Add(this.lblWakeupTime);
      this.groupBoxStatus.Location = new System.Drawing.Point(0, 355);
      this.groupBoxStatus.Name = "groupBoxStatus";
      this.groupBoxStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.groupBoxStatus.Size = new System.Drawing.Size(484, 70);
      this.groupBoxStatus.TabIndex = 0;
      this.groupBoxStatus.TabStop = false;
      this.groupBoxStatus.Text = "Device Status";
      // 
      // lblLastCommand
      // 
      this.lblLastCommand.AutoSize = true;
      this.lblLastCommand.Location = new System.Drawing.Point(359, 54);
      this.lblLastCommand.Name = "lblLastCommand";
      this.lblLastCommand.Size = new System.Drawing.Size(31, 13);
      this.lblLastCommand.TabIndex = 14;
      this.lblLastCommand.Text = "none";
      // 
      // lblLastAddress
      // 
      this.lblLastAddress.AutoSize = true;
      this.lblLastAddress.Location = new System.Drawing.Point(256, 54);
      this.lblLastAddress.Name = "lblLastAddress";
      this.lblLastAddress.Size = new System.Drawing.Size(31, 13);
      this.lblLastAddress.TabIndex = 13;
      this.lblLastAddress.Text = "none";
      // 
      // lblLastProtocol
      // 
      this.lblLastProtocol.AutoSize = true;
      this.lblLastProtocol.Location = new System.Drawing.Point(174, 54);
      this.lblLastProtocol.Name = "lblLastProtocol";
      this.lblLastProtocol.Size = new System.Drawing.Size(31, 13);
      this.lblLastProtocol.TabIndex = 12;
      this.lblLastProtocol.Text = "none";
      // 
      // label53
      // 
      this.label53.AutoSize = true;
      this.label53.Location = new System.Drawing.Point(304, 54);
      this.label53.Name = "label53";
      this.label53.Size = new System.Drawing.Size(60, 13);
      this.label53.TabIndex = 11;
      this.label53.Text = "Command=";
      // 
      // label52
      // 
      this.label52.AutoSize = true;
      this.label52.Location = new System.Drawing.Point(210, 54);
      this.label52.Name = "label52";
      this.label52.Size = new System.Drawing.Size(51, 13);
      this.label52.TabIndex = 10;
      this.label52.Text = "Address=";
      // 
      // label51
      // 
      this.label51.AutoSize = true;
      this.label51.Location = new System.Drawing.Point(127, 54);
      this.label51.Name = "label51";
      this.label51.Size = new System.Drawing.Size(52, 13);
      this.label51.TabIndex = 9;
      this.label51.Text = "Protocol=";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(6, 16);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(64, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Connection:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(248, 16);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(89, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "Firmware version:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(6, 35);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(33, 13);
      this.label3.TabIndex = 4;
      this.label3.Text = "Time:";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(248, 35);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(95, 13);
      this.label4.TabIndex = 6;
      this.label4.Text = "Next wakeup time:";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(6, 54);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(115, 13);
      this.label5.TabIndex = 8;
      this.label5.Text = "Last received IR code:";
      // 
      // lblConnectionStatus
      // 
      this.lblConnectionStatus.AutoSize = true;
      this.lblConnectionStatus.Location = new System.Drawing.Point(127, 16);
      this.lblConnectionStatus.Name = "lblConnectionStatus";
      this.lblConnectionStatus.Size = new System.Drawing.Size(31, 13);
      this.lblConnectionStatus.TabIndex = 1;
      this.lblConnectionStatus.Text = "none";
      // 
      // lblDeviceTime
      // 
      this.lblDeviceTime.AutoSize = true;
      this.lblDeviceTime.Location = new System.Drawing.Point(127, 35);
      this.lblDeviceTime.Name = "lblDeviceTime";
      this.lblDeviceTime.Size = new System.Drawing.Size(31, 13);
      this.lblDeviceTime.TabIndex = 5;
      this.lblDeviceTime.Text = "none";
      // 
      // lblFirmware
      // 
      this.lblFirmware.AutoSize = true;
      this.lblFirmware.Location = new System.Drawing.Point(369, 16);
      this.lblFirmware.Name = "lblFirmware";
      this.lblFirmware.Size = new System.Drawing.Size(31, 13);
      this.lblFirmware.TabIndex = 3;
      this.lblFirmware.Text = "none";
      // 
      // lblWakeupTime
      // 
      this.lblWakeupTime.AutoSize = true;
      this.lblWakeupTime.Location = new System.Drawing.Point(369, 35);
      this.lblWakeupTime.Name = "lblWakeupTime";
      this.lblWakeupTime.Size = new System.Drawing.Size(31, 13);
      this.lblWakeupTime.TabIndex = 7;
      this.lblWakeupTime.Text = "none";
      // 
      // groupBoxClockSchedule
      // 
      this.groupBoxClockSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                  | System.Windows.Forms.AnchorStyles.Left) 
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBoxClockSchedule.Controls.Add(this.groupBox15);
      this.groupBoxClockSchedule.Controls.Add(this.btnUpdateFirmware);
      this.groupBoxClockSchedule.Controls.Add(this.groupBox10);
      this.groupBoxClockSchedule.Controls.Add(this.groupBox11);
      this.groupBoxClockSchedule.Controls.Add(this.groupBox12);
      this.groupBoxClockSchedule.Controls.Add(this.groupBox13);
      this.groupBoxClockSchedule.Controls.Add(this.groupBox14);
      this.groupBoxClockSchedule.Location = new System.Drawing.Point(6, 6);
      this.groupBoxClockSchedule.Name = "groupBoxClockSchedule";
      this.groupBoxClockSchedule.Size = new System.Drawing.Size(464, 311);
      this.groupBoxClockSchedule.TabIndex = 0;
      this.groupBoxClockSchedule.TabStop = false;
      this.groupBoxClockSchedule.Text = "Settings";
      // 
      // groupBox15
      // 
      this.groupBox15.Controls.Add(this.btnControlPcButtons);
      this.groupBox15.Controls.Add(this.lblControlPcButtons);
      this.groupBox15.Location = new System.Drawing.Point(204, 230);
      this.groupBox15.Name = "groupBox15";
      this.groupBox15.Size = new System.Drawing.Size(192, 45);
      this.groupBox15.TabIndex = 6;
      this.groupBox15.TabStop = false;
      this.groupBox15.Text = "Control PC buttons";
      // 
      // btnControlPcButtons
      // 
      this.btnControlPcButtons.Location = new System.Drawing.Point(122, 16);
      this.btnControlPcButtons.Name = "btnControlPcButtons";
      this.btnControlPcButtons.Size = new System.Drawing.Size(64, 23);
      this.btnControlPcButtons.TabIndex = 1;
      this.btnControlPcButtons.Text = "Enable";
      this.toolTip.SetToolTip(this.btnControlPcButtons, "Enable/Disable control of the PCs power and reset button.");
      this.btnControlPcButtons.UseVisualStyleBackColor = true;
      this.btnControlPcButtons.Click += new System.EventHandler(this.BtnControlPcButtonsClick);
      // 
      // lblControlPcButtons
      // 
      this.lblControlPcButtons.AutoSize = true;
      this.lblControlPcButtons.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.78182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblControlPcButtons.ForeColor = System.Drawing.Color.Red;
      this.lblControlPcButtons.Location = new System.Drawing.Point(6, 16);
      this.lblControlPcButtons.Name = "lblControlPcButtons";
      this.lblControlPcButtons.Size = new System.Drawing.Size(0, 24);
      this.lblControlPcButtons.TabIndex = 0;
      // 
      // btnUpdateFirmware
      // 
      this.btnUpdateFirmware.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnUpdateFirmware.AutoSize = true;
      this.btnUpdateFirmware.Enabled = false;
      this.btnUpdateFirmware.Location = new System.Drawing.Point(361, 282);
      this.btnUpdateFirmware.Name = "btnUpdateFirmware";
      this.btnUpdateFirmware.Size = new System.Drawing.Size(97, 23);
      this.btnUpdateFirmware.TabIndex = 5;
      this.btnUpdateFirmware.Text = "Update Firmware";
      this.toolTip.SetToolTip(this.btnUpdateFirmware, "Update the device firmware.");
      this.btnUpdateFirmware.UseVisualStyleBackColor = true;
      this.btnUpdateFirmware.Click += new System.EventHandler(this.BtnUpdateFirmwareClick);
      // 
      // groupBox10
      // 
      this.groupBox10.Controls.Add(this.chbEnableSyncClocks);
      this.groupBox10.Controls.Add(this.rdbKeepPcTime);
      this.groupBox10.Controls.Add(this.rdbKeepDevTime);
      this.groupBox10.Controls.Add(this.chbEnableKeySend);
      this.groupBox10.Controls.Add(this.btnSaveSettings);
      this.groupBox10.Controls.Add(this.chbEnableAppStart);
      this.groupBox10.Location = new System.Drawing.Point(6, 19);
      this.groupBox10.Name = "groupBox10";
      this.groupBox10.Size = new System.Drawing.Size(192, 163);
      this.groupBox10.TabIndex = 0;
      this.groupBox10.TabStop = false;
      this.groupBox10.Text = "General";
      // 
      // chbEnableSyncClocks
      // 
      this.chbEnableSyncClocks.AutoSize = true;
      this.chbEnableSyncClocks.Location = new System.Drawing.Point(6, 65);
      this.chbEnableSyncClocks.Name = "chbEnableSyncClocks";
      this.chbEnableSyncClocks.Size = new System.Drawing.Size(118, 17);
      this.chbEnableSyncClocks.TabIndex = 7;
      this.chbEnableSyncClocks.Text = "Synchronize clocks";
      this.toolTip.SetToolTip(this.chbEnableSyncClocks, "Enable/Disable clock synchronization.");
      this.chbEnableSyncClocks.UseVisualStyleBackColor = true;
      this.chbEnableSyncClocks.CheckedChanged += new System.EventHandler(this.ChbSyncClocksCheckedChanged);
      // 
      // rdbKeepPcTime
      // 
      this.rdbKeepPcTime.AutoSize = true;
      this.rdbKeepPcTime.Location = new System.Drawing.Point(16, 88);
      this.rdbKeepPcTime.Name = "rdbKeepPcTime";
      this.rdbKeepPcTime.Size = new System.Drawing.Size(135, 17);
      this.rdbKeepPcTime.TabIndex = 8;
      this.rdbKeepPcTime.TabStop = true;
      this.rdbKeepPcTime.Text = "Copy PC time to device";
      this.toolTip.SetToolTip(this.rdbKeepPcTime, "Overwrite device time with PC time.");
      this.rdbKeepPcTime.UseVisualStyleBackColor = true;
      // 
      // rdbKeepDevTime
      // 
      this.rdbKeepDevTime.AutoSize = true;
      this.rdbKeepDevTime.Location = new System.Drawing.Point(16, 111);
      this.rdbKeepDevTime.Name = "rdbKeepDevTime";
      this.rdbKeepDevTime.Size = new System.Drawing.Size(135, 17);
      this.rdbKeepDevTime.TabIndex = 9;
      this.rdbKeepDevTime.TabStop = true;
      this.rdbKeepDevTime.Text = "Copy device time to PC";
      this.toolTip.SetToolTip(this.rdbKeepDevTime, "Overwrite PC time with device time.");
      this.rdbKeepDevTime.UseVisualStyleBackColor = true;
      // 
      // chbEnableKeySend
      // 
      this.chbEnableKeySend.AutoSize = true;
      this.chbEnableKeySend.Location = new System.Drawing.Point(6, 19);
      this.chbEnableKeySend.Name = "chbEnableKeySend";
      this.chbEnableKeySend.Size = new System.Drawing.Size(159, 17);
      this.chbEnableKeySend.TabIndex = 0;
      this.chbEnableKeySend.Text = "Send key (or key sequence)";
      this.toolTip.SetToolTip(this.chbEnableKeySend, "Enable/Disable generation of key (sequence) on IR code.");
      this.chbEnableKeySend.UseVisualStyleBackColor = true;
      // 
      // btnSaveSettings
      // 
      this.btnSaveSettings.AutoSize = true;
      this.btnSaveSettings.Location = new System.Drawing.Point(125, 134);
      this.btnSaveSettings.Name = "btnSaveSettings";
      this.btnSaveSettings.Size = new System.Drawing.Size(64, 23);
      this.btnSaveSettings.TabIndex = 2;
      this.btnSaveSettings.Text = "Save";
      this.toolTip.SetToolTip(this.btnSaveSettings, "Save settings in config file.");
      this.btnSaveSettings.UseVisualStyleBackColor = true;
      this.btnSaveSettings.Click += new System.EventHandler(this.BtnSaveSettingsClick);
      // 
      // chbEnableAppStart
      // 
      this.chbEnableAppStart.AutoSize = true;
      this.chbEnableAppStart.Location = new System.Drawing.Point(6, 42);
      this.chbEnableAppStart.Name = "chbEnableAppStart";
      this.chbEnableAppStart.Size = new System.Drawing.Size(102, 17);
      this.chbEnableAppStart.TabIndex = 1;
      this.chbEnableAppStart.Text = "Start application";
      this.toolTip.SetToolTip(this.chbEnableAppStart, "Enable/Disable application start (with parameters) on IR code.");
      this.chbEnableAppStart.UseVisualStyleBackColor = true;
      // 
      // groupBox11
      // 
      this.groupBox11.Controls.Add(this.dtpTime);
      this.groupBox11.Controls.Add(this.btnReadTime);
      this.groupBox11.Controls.Add(this.btnWriteTime);
      this.groupBox11.Controls.Add(this.label10);
      this.groupBox11.Location = new System.Drawing.Point(6, 188);
      this.groupBox11.Name = "groupBox11";
      this.groupBox11.Size = new System.Drawing.Size(192, 103);
      this.groupBox11.TabIndex = 1;
      this.groupBox11.TabStop = false;
      this.groupBox11.Text = "Clock";
      // 
      // dtpTime
      // 
      this.dtpTime.CustomFormat = "dd MMM yyyy     HH:mm:ss";
      this.dtpTime.Enabled = false;
      this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.dtpTime.Location = new System.Drawing.Point(6, 19);
      this.dtpTime.Name = "dtpTime";
      this.dtpTime.ShowUpDown = true;
      this.dtpTime.Size = new System.Drawing.Size(180, 20);
      this.dtpTime.TabIndex = 0;
      this.dtpTime.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(6, 71);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(181, 26);
      this.label10.TabIndex = 3;
      this.label10.Text = "It will take some time until new time\r\ncan be read. Simply click read again.";
      // 
      // groupBox12
      // 
      this.groupBox12.Controls.Add(this.numClockDeviation);
      this.groupBox12.Controls.Add(this.btnSetClockDeviation);
      this.groupBox12.Controls.Add(this.label11);
      this.groupBox12.Controls.Add(this.label12);
      this.groupBox12.Location = new System.Drawing.Point(204, 19);
      this.groupBox12.Name = "groupBox12";
      this.groupBox12.Size = new System.Drawing.Size(192, 74);
      this.groupBox12.TabIndex = 2;
      this.groupBox12.TabStop = false;
      this.groupBox12.Text = "Clock correction";
      // 
      // numClockDeviation
      // 
      this.numClockDeviation.Location = new System.Drawing.Point(6, 19);
      this.numClockDeviation.Maximum = new decimal(new int[] {
                  2147483647,
                  0,
                  0,
                  0});
      this.numClockDeviation.Minimum = new decimal(new int[] {
                  -2147483648,
                  0,
                  0,
                  -2147483648});
      this.numClockDeviation.Name = "numClockDeviation";
      this.numClockDeviation.Size = new System.Drawing.Size(84, 20);
      this.numClockDeviation.TabIndex = 0;
      this.numClockDeviation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.numClockDeviation.ThousandsSeparator = true;
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(90, 21);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(20, 13);
      this.label11.TabIndex = 1;
      this.label11.Text = "Hz";
      this.label11.Visible = false;
      // 
      // label12
      // 
      this.label12.AutoSize = true;
      this.label12.Location = new System.Drawing.Point(6, 42);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(141, 26);
      this.label12.TabIndex = 3;
      this.label12.Text = "Increase if clock is too slow.\r\nDecrease if clock is too fast.";
      // 
      // groupBox13
      // 
      this.groupBox13.Controls.Add(this.dtpWakeupTime);
      this.groupBox13.Controls.Add(this.btnReadWakeupTime);
      this.groupBox13.Controls.Add(this.btnWriteWakeupTime);
      this.groupBox13.Location = new System.Drawing.Point(204, 99);
      this.groupBox13.Name = "groupBox13";
      this.groupBox13.Size = new System.Drawing.Size(192, 74);
      this.groupBox13.TabIndex = 3;
      this.groupBox13.TabStop = false;
      this.groupBox13.Text = "Wakeup time";
      // 
      // dtpWakeupTime
      // 
      this.dtpWakeupTime.CustomFormat = "dd MMM yyyy     HH:mm";
      this.dtpWakeupTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.dtpWakeupTime.Location = new System.Drawing.Point(6, 19);
      this.dtpWakeupTime.Name = "dtpWakeupTime";
      this.dtpWakeupTime.ShowUpDown = true;
      this.dtpWakeupTime.Size = new System.Drawing.Size(180, 20);
      this.dtpWakeupTime.TabIndex = 0;
      this.dtpWakeupTime.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
      // 
      // groupBox14
      // 
      this.groupBox14.Controls.Add(this.numWakeupTimeSpan);
      this.groupBox14.Controls.Add(this.btnSetWakeupTimeSpan);
      this.groupBox14.Controls.Add(this.label13);
      this.groupBox14.Location = new System.Drawing.Point(204, 179);
      this.groupBox14.Name = "groupBox14";
      this.groupBox14.Size = new System.Drawing.Size(192, 45);
      this.groupBox14.TabIndex = 4;
      this.groupBox14.TabStop = false;
      this.groupBox14.Text = "Wakeup time span";
      // 
      // numWakeupTimeSpan
      // 
      this.numWakeupTimeSpan.Location = new System.Drawing.Point(6, 19);
      this.numWakeupTimeSpan.Maximum = new decimal(new int[] {
                  60,
                  0,
                  0,
                  0});
      this.numWakeupTimeSpan.Name = "numWakeupTimeSpan";
      this.numWakeupTimeSpan.Size = new System.Drawing.Size(60, 20);
      this.numWakeupTimeSpan.TabIndex = 0;
      this.numWakeupTimeSpan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.numWakeupTimeSpan.Value = new decimal(new int[] {
                  5,
                  0,
                  0,
                  0});
      // 
      // label13
      // 
      this.label13.AutoSize = true;
      this.label13.Location = new System.Drawing.Point(66, 21);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(43, 13);
      this.label13.TabIndex = 1;
      this.label13.Text = "minutes";
      // 
      // groupBoxInfrared
      // 
      this.groupBoxInfrared.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                  | System.Windows.Forms.AnchorStyles.Left) 
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBoxInfrared.Controls.Add(this.groupBox20);
      this.groupBoxInfrared.Controls.Add(this.groupBox21);
      this.groupBoxInfrared.Controls.Add(this.groupBox22);
      this.groupBoxInfrared.Controls.Add(this.groupBox23);
      this.groupBoxInfrared.Controls.Add(this.groupBox24);
      this.groupBoxInfrared.Controls.Add(this.groupBox25);
      this.groupBoxInfrared.Location = new System.Drawing.Point(6, 6);
      this.groupBoxInfrared.Name = "groupBoxInfrared";
      this.groupBoxInfrared.Size = new System.Drawing.Size(464, 311);
      this.groupBoxInfrared.TabIndex = 0;
      this.groupBoxInfrared.TabStop = false;
      this.groupBoxInfrared.Text = "Settings";
      // 
      // groupBox20
      // 
      this.groupBox20.Controls.Add(this.btnClearPowerOnCode);
      this.groupBox20.Controls.Add(this.btnWritePowerOnCode);
      this.groupBox20.Controls.Add(this.lblPowerOnProtocol);
      this.groupBox20.Controls.Add(this.lblPowerOnAddress);
      this.groupBox20.Controls.Add(this.lblPowerOnCommand);
      this.groupBox20.Controls.Add(this.label22);
      this.groupBox20.Controls.Add(this.label21);
      this.groupBox20.Controls.Add(this.label20);
      this.groupBox20.Location = new System.Drawing.Point(6, 19);
      this.groupBox20.Name = "groupBox20";
      this.groupBox20.Size = new System.Drawing.Size(192, 87);
      this.groupBox20.TabIndex = 0;
      this.groupBox20.TabStop = false;
      this.groupBox20.Text = "Power-On IR code";
      // 
      // lblPowerOnProtocol
      // 
      this.lblPowerOnProtocol.AutoSize = true;
      this.lblPowerOnProtocol.Location = new System.Drawing.Point(99, 16);
      this.lblPowerOnProtocol.Name = "lblPowerOnProtocol";
      this.lblPowerOnProtocol.Size = new System.Drawing.Size(31, 13);
      this.lblPowerOnProtocol.TabIndex = 1;
      this.lblPowerOnProtocol.Text = "none";
      // 
      // lblPowerOnAddress
      // 
      this.lblPowerOnAddress.AutoSize = true;
      this.lblPowerOnAddress.Location = new System.Drawing.Point(99, 29);
      this.lblPowerOnAddress.Name = "lblPowerOnAddress";
      this.lblPowerOnAddress.Size = new System.Drawing.Size(31, 13);
      this.lblPowerOnAddress.TabIndex = 3;
      this.lblPowerOnAddress.Text = "none";
      // 
      // lblPowerOnCommand
      // 
      this.lblPowerOnCommand.AutoSize = true;
      this.lblPowerOnCommand.Location = new System.Drawing.Point(99, 42);
      this.lblPowerOnCommand.Name = "lblPowerOnCommand";
      this.lblPowerOnCommand.Size = new System.Drawing.Size(31, 13);
      this.lblPowerOnCommand.TabIndex = 5;
      this.lblPowerOnCommand.Text = "none";
      // 
      // label22
      // 
      this.label22.AutoSize = true;
      this.label22.Location = new System.Drawing.Point(6, 42);
      this.label22.Name = "label22";
      this.label22.Size = new System.Drawing.Size(57, 13);
      this.label22.TabIndex = 4;
      this.label22.Text = "Command:";
      // 
      // label21
      // 
      this.label21.AutoSize = true;
      this.label21.Location = new System.Drawing.Point(6, 29);
      this.label21.Name = "label21";
      this.label21.Size = new System.Drawing.Size(48, 13);
      this.label21.TabIndex = 2;
      this.label21.Text = "Address:";
      // 
      // label20
      // 
      this.label20.AutoSize = true;
      this.label20.Location = new System.Drawing.Point(6, 16);
      this.label20.Name = "label20";
      this.label20.Size = new System.Drawing.Size(49, 13);
      this.label20.TabIndex = 0;
      this.label20.Text = "Protocol:";
      // 
      // groupBox21
      // 
      this.groupBox21.Controls.Add(this.btnClearPowerOffCode);
      this.groupBox21.Controls.Add(this.btnWritePowerOffCode);
      this.groupBox21.Controls.Add(this.lblPowerOffProtocol);
      this.groupBox21.Controls.Add(this.lblPowerOffAddress);
      this.groupBox21.Controls.Add(this.lblPowerOffCommand);
      this.groupBox21.Controls.Add(this.label25);
      this.groupBox21.Controls.Add(this.label24);
      this.groupBox21.Controls.Add(this.label23);
      this.groupBox21.Location = new System.Drawing.Point(6, 112);
      this.groupBox21.Name = "groupBox21";
      this.groupBox21.Size = new System.Drawing.Size(192, 87);
      this.groupBox21.TabIndex = 1;
      this.groupBox21.TabStop = false;
      this.groupBox21.Text = "Power-Off IR code";
      // 
      // lblPowerOffProtocol
      // 
      this.lblPowerOffProtocol.AutoSize = true;
      this.lblPowerOffProtocol.Location = new System.Drawing.Point(99, 16);
      this.lblPowerOffProtocol.Name = "lblPowerOffProtocol";
      this.lblPowerOffProtocol.Size = new System.Drawing.Size(31, 13);
      this.lblPowerOffProtocol.TabIndex = 1;
      this.lblPowerOffProtocol.Text = "none";
      // 
      // lblPowerOffAddress
      // 
      this.lblPowerOffAddress.AutoSize = true;
      this.lblPowerOffAddress.Location = new System.Drawing.Point(99, 29);
      this.lblPowerOffAddress.Name = "lblPowerOffAddress";
      this.lblPowerOffAddress.Size = new System.Drawing.Size(31, 13);
      this.lblPowerOffAddress.TabIndex = 3;
      this.lblPowerOffAddress.Text = "none";
      // 
      // lblPowerOffCommand
      // 
      this.lblPowerOffCommand.AutoSize = true;
      this.lblPowerOffCommand.Location = new System.Drawing.Point(99, 42);
      this.lblPowerOffCommand.Name = "lblPowerOffCommand";
      this.lblPowerOffCommand.Size = new System.Drawing.Size(31, 13);
      this.lblPowerOffCommand.TabIndex = 5;
      this.lblPowerOffCommand.Text = "none";
      // 
      // label25
      // 
      this.label25.AutoSize = true;
      this.label25.Location = new System.Drawing.Point(6, 42);
      this.label25.Name = "label25";
      this.label25.Size = new System.Drawing.Size(57, 13);
      this.label25.TabIndex = 4;
      this.label25.Text = "Command:";
      // 
      // label24
      // 
      this.label24.AutoSize = true;
      this.label24.Location = new System.Drawing.Point(6, 29);
      this.label24.Name = "label24";
      this.label24.Size = new System.Drawing.Size(48, 13);
      this.label24.TabIndex = 2;
      this.label24.Text = "Address:";
      // 
      // label23
      // 
      this.label23.AutoSize = true;
      this.label23.Location = new System.Drawing.Point(6, 16);
      this.label23.Name = "label23";
      this.label23.Size = new System.Drawing.Size(49, 13);
      this.label23.TabIndex = 0;
      this.label23.Text = "Protocol:";
      // 
      // groupBox22
      // 
      this.groupBox22.Controls.Add(this.btnClearResetCode);
      this.groupBox22.Controls.Add(this.btnWriteResetCode);
      this.groupBox22.Controls.Add(this.lblResetProtocol);
      this.groupBox22.Controls.Add(this.lblResetAddress);
      this.groupBox22.Controls.Add(this.lblResetCommand);
      this.groupBox22.Controls.Add(this.label26);
      this.groupBox22.Controls.Add(this.label27);
      this.groupBox22.Controls.Add(this.label28);
      this.groupBox22.Location = new System.Drawing.Point(6, 205);
      this.groupBox22.Name = "groupBox22";
      this.groupBox22.Size = new System.Drawing.Size(192, 87);
      this.groupBox22.TabIndex = 2;
      this.groupBox22.TabStop = false;
      this.groupBox22.Text = "Reset IR code";
      // 
      // lblResetProtocol
      // 
      this.lblResetProtocol.AutoSize = true;
      this.lblResetProtocol.Location = new System.Drawing.Point(99, 16);
      this.lblResetProtocol.Name = "lblResetProtocol";
      this.lblResetProtocol.Size = new System.Drawing.Size(31, 13);
      this.lblResetProtocol.TabIndex = 1;
      this.lblResetProtocol.Text = "none";
      // 
      // lblResetAddress
      // 
      this.lblResetAddress.AutoSize = true;
      this.lblResetAddress.Location = new System.Drawing.Point(99, 29);
      this.lblResetAddress.Name = "lblResetAddress";
      this.lblResetAddress.Size = new System.Drawing.Size(31, 13);
      this.lblResetAddress.TabIndex = 3;
      this.lblResetAddress.Text = "none";
      // 
      // lblResetCommand
      // 
      this.lblResetCommand.AutoSize = true;
      this.lblResetCommand.Location = new System.Drawing.Point(99, 42);
      this.lblResetCommand.Name = "lblResetCommand";
      this.lblResetCommand.Size = new System.Drawing.Size(31, 13);
      this.lblResetCommand.TabIndex = 5;
      this.lblResetCommand.Text = "none";
      // 
      // label26
      // 
      this.label26.AutoSize = true;
      this.label26.Location = new System.Drawing.Point(6, 16);
      this.label26.Name = "label26";
      this.label26.Size = new System.Drawing.Size(49, 13);
      this.label26.TabIndex = 0;
      this.label26.Text = "Protocol:";
      // 
      // label27
      // 
      this.label27.AutoSize = true;
      this.label27.Location = new System.Drawing.Point(6, 29);
      this.label27.Name = "label27";
      this.label27.Size = new System.Drawing.Size(48, 13);
      this.label27.TabIndex = 2;
      this.label27.Text = "Address:";
      // 
      // label28
      // 
      this.label28.AutoSize = true;
      this.label28.Location = new System.Drawing.Point(6, 42);
      this.label28.Name = "label28";
      this.label28.Size = new System.Drawing.Size(57, 13);
      this.label28.TabIndex = 4;
      this.label28.Text = "Command:";
      // 
      // groupBox23
      // 
      this.groupBox23.Controls.Add(this.numMinRepeats);
      this.groupBox23.Controls.Add(this.btnSetMinRepeats);
      this.groupBox23.Controls.Add(this.label29);
      this.groupBox23.Location = new System.Drawing.Point(204, 19);
      this.groupBox23.Name = "groupBox23";
      this.groupBox23.Size = new System.Drawing.Size(192, 45);
      this.groupBox23.TabIndex = 3;
      this.groupBox23.TabStop = false;
      this.groupBox23.Text = "Minimum repeats";
      // 
      // numMinRepeats
      // 
      this.numMinRepeats.Location = new System.Drawing.Point(6, 19);
      this.numMinRepeats.Maximum = new decimal(new int[] {
                  20,
                  0,
                  0,
                  0});
      this.numMinRepeats.Name = "numMinRepeats";
      this.numMinRepeats.Size = new System.Drawing.Size(60, 20);
      this.numMinRepeats.TabIndex = 0;
      this.numMinRepeats.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.numMinRepeats.Value = new decimal(new int[] {
                  5,
                  0,
                  0,
                  0});
      // 
      // label29
      // 
      this.label29.AutoSize = true;
      this.label29.Location = new System.Drawing.Point(66, 21);
      this.label29.Name = "label29";
      this.label29.Size = new System.Drawing.Size(42, 13);
      this.label29.TabIndex = 1;
      this.label29.Text = "repeats";
      // 
      // groupBox24
      // 
      this.groupBox24.Controls.Add(this.btnForwardIrState);
      this.groupBox24.Controls.Add(this.lblForwardIrState);
      this.groupBox24.Location = new System.Drawing.Point(204, 72);
      this.groupBox24.Name = "groupBox24";
      this.groupBox24.Size = new System.Drawing.Size(192, 45);
      this.groupBox24.TabIndex = 4;
      this.groupBox24.TabStop = false;
      this.groupBox24.Text = "Forward IR codes";
      // 
      // lblForwardIrState
      // 
      this.lblForwardIrState.AutoSize = true;
      this.lblForwardIrState.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.78182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblForwardIrState.ForeColor = System.Drawing.Color.Red;
      this.lblForwardIrState.Location = new System.Drawing.Point(6, 16);
      this.lblForwardIrState.Name = "lblForwardIrState";
      this.lblForwardIrState.Size = new System.Drawing.Size(0, 24);
      this.lblForwardIrState.TabIndex = 0;
      // 
      // groupBox25
      // 
      this.groupBox25.Controls.Add(this.numSendIrProtocol);
      this.groupBox25.Controls.Add(this.numSendIrAddress);
      this.groupBox25.Controls.Add(this.numSendIrCommand);
      this.groupBox25.Controls.Add(this.btnSendIrCode);
      this.groupBox25.Controls.Add(this.label30);
      this.groupBox25.Controls.Add(this.label31);
      this.groupBox25.Controls.Add(this.label32);
      this.groupBox25.Controls.Add(this.label33);
      this.groupBox25.Controls.Add(this.label34);
      this.groupBox25.Controls.Add(this.label35);
      this.groupBox25.Location = new System.Drawing.Point(204, 123);
      this.groupBox25.Name = "groupBox25";
      this.groupBox25.Size = new System.Drawing.Size(192, 121);
      this.groupBox25.TabIndex = 5;
      this.groupBox25.TabStop = false;
      this.groupBox25.Text = "Send IR code";
      // 
      // numSendIrProtocol
      // 
      this.numSendIrProtocol.Hexadecimal = true;
      this.numSendIrProtocol.Location = new System.Drawing.Point(114, 14);
      this.numSendIrProtocol.Maximum = new decimal(new int[] {
                  255,
                  0,
                  0,
                  0});
      this.numSendIrProtocol.Name = "numSendIrProtocol";
      this.numSendIrProtocol.Size = new System.Drawing.Size(60, 20);
      this.numSendIrProtocol.TabIndex = 2;
      // 
      // numSendIrAddress
      // 
      this.numSendIrAddress.Hexadecimal = true;
      this.numSendIrAddress.Location = new System.Drawing.Point(114, 40);
      this.numSendIrAddress.Maximum = new decimal(new int[] {
                  65535,
                  0,
                  0,
                  0});
      this.numSendIrAddress.Name = "numSendIrAddress";
      this.numSendIrAddress.Size = new System.Drawing.Size(60, 20);
      this.numSendIrAddress.TabIndex = 5;
      // 
      // numSendIrCommand
      // 
      this.numSendIrCommand.Hexadecimal = true;
      this.numSendIrCommand.Location = new System.Drawing.Point(114, 66);
      this.numSendIrCommand.Maximum = new decimal(new int[] {
                  65535,
                  0,
                  0,
                  0});
      this.numSendIrCommand.Name = "numSendIrCommand";
      this.numSendIrCommand.Size = new System.Drawing.Size(60, 20);
      this.numSendIrCommand.TabIndex = 8;
      // 
      // label30
      // 
      this.label30.AutoSize = true;
      this.label30.Location = new System.Drawing.Point(6, 16);
      this.label30.Name = "label30";
      this.label30.Size = new System.Drawing.Size(49, 13);
      this.label30.TabIndex = 0;
      this.label30.Text = "Protocol:";
      // 
      // label31
      // 
      this.label31.AutoSize = true;
      this.label31.Location = new System.Drawing.Point(6, 42);
      this.label31.Name = "label31";
      this.label31.Size = new System.Drawing.Size(48, 13);
      this.label31.TabIndex = 3;
      this.label31.Text = "Address:";
      // 
      // label32
      // 
      this.label32.AutoSize = true;
      this.label32.Location = new System.Drawing.Point(6, 68);
      this.label32.Name = "label32";
      this.label32.Size = new System.Drawing.Size(57, 13);
      this.label32.TabIndex = 6;
      this.label32.Text = "Command:";
      // 
      // label33
      // 
      this.label33.AutoSize = true;
      this.label33.Location = new System.Drawing.Point(99, 16);
      this.label33.Name = "label33";
      this.label33.Size = new System.Drawing.Size(18, 13);
      this.label33.TabIndex = 1;
      this.label33.Text = "0x";
      // 
      // label34
      // 
      this.label34.AutoSize = true;
      this.label34.Location = new System.Drawing.Point(99, 42);
      this.label34.Name = "label34";
      this.label34.Size = new System.Drawing.Size(18, 13);
      this.label34.TabIndex = 4;
      this.label34.Text = "0x";
      // 
      // label35
      // 
      this.label35.AutoSize = true;
      this.label35.Location = new System.Drawing.Point(99, 68);
      this.label35.Name = "label35";
      this.label35.Size = new System.Drawing.Size(18, 13);
      this.label35.TabIndex = 7;
      this.label35.Text = "0x";
      // 
      // groupBoxKeymap
      // 
      this.groupBoxKeymap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                  | System.Windows.Forms.AnchorStyles.Left) 
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBoxKeymap.Controls.Add(this.label6);
      this.groupBoxKeymap.Controls.Add(this.btnAssignApp);
      this.groupBoxKeymap.Controls.Add(this.dgvKeymap);
      this.groupBoxKeymap.Controls.Add(this.btnAssignCode);
      this.groupBoxKeymap.Controls.Add(this.btnSaveKeymap);
      this.groupBoxKeymap.Location = new System.Drawing.Point(6, 6);
      this.groupBoxKeymap.Name = "groupBoxKeymap";
      this.groupBoxKeymap.Size = new System.Drawing.Size(464, 311);
      this.groupBoxKeymap.TabIndex = 0;
      this.groupBoxKeymap.TabStop = false;
      this.groupBoxKeymap.Text = "Settings";
      // 
      // label6
      // 
      this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(228, 279);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(139, 26);
      this.label6.TabIndex = 4;
      this.label6.Text = "IR values are shown in\r\nhexadecimal representation.";
      // 
      // btnAssignApp
      // 
      this.btnAssignApp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnAssignApp.AutoSize = true;
      this.btnAssignApp.Location = new System.Drawing.Point(117, 282);
      this.btnAssignApp.Name = "btnAssignApp";
      this.btnAssignApp.Size = new System.Drawing.Size(105, 23);
      this.btnAssignApp.TabIndex = 2;
      this.btnAssignApp.Text = "Assign application";
      this.toolTip.SetToolTip(this.btnAssignApp, "Assign an application with optional arguments to selection.");
      this.btnAssignApp.UseVisualStyleBackColor = true;
      this.btnAssignApp.Click += new System.EventHandler(this.BtnAssignAppClick);
      // 
      // dgvKeymap
      // 
      this.dgvKeymap.AllowUserToOrderColumns = true;
      this.dgvKeymap.AllowUserToResizeRows = false;
      dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
      this.dgvKeymap.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
      this.dgvKeymap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                  | System.Windows.Forms.AnchorStyles.Left) 
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.dgvKeymap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvKeymap.Location = new System.Drawing.Point(6, 19);
      this.dgvKeymap.MultiSelect = false;
      this.dgvKeymap.Name = "dgvKeymap";
      this.dgvKeymap.Size = new System.Drawing.Size(452, 257);
      this.dgvKeymap.TabIndex = 0;
      this.dgvKeymap.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.DgvKeymapCellParsing);
      this.dgvKeymap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgvKeymapKeyDown);
      // 
      // tabControl
      // 
      this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                  | System.Windows.Forms.AnchorStyles.Left) 
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.tabControl.Controls.Add(this.tabPageGeneral);
      this.tabControl.Controls.Add(this.tabPageInfrared);
      this.tabControl.Controls.Add(this.tabPageKeymap);
      this.tabControl.Location = new System.Drawing.Point(0, 0);
      this.tabControl.Name = "tabControl";
      this.tabControl.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.tabControl.SelectedIndex = 0;
      this.tabControl.ShowToolTips = true;
      this.tabControl.Size = new System.Drawing.Size(484, 349);
      this.tabControl.TabIndex = 0;
      this.tabControl.Tag = "";
      this.tabControl.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.TabControlSelecting);
      // 
      // tabPageGeneral
      // 
      this.tabPageGeneral.Controls.Add(this.groupBoxClockSchedule);
      this.tabPageGeneral.Location = new System.Drawing.Point(4, 22);
      this.tabPageGeneral.Name = "tabPageGeneral";
      this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageGeneral.Size = new System.Drawing.Size(476, 323);
      this.tabPageGeneral.TabIndex = 0;
      this.tabPageGeneral.Text = "General, Clock & Schedule";
      this.tabPageGeneral.UseVisualStyleBackColor = true;
      // 
      // tabPageInfrared
      // 
      this.tabPageInfrared.Controls.Add(this.groupBoxInfrared);
      this.tabPageInfrared.Location = new System.Drawing.Point(4, 22);
      this.tabPageInfrared.Name = "tabPageInfrared";
      this.tabPageInfrared.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageInfrared.Size = new System.Drawing.Size(476, 323);
      this.tabPageInfrared.TabIndex = 1;
      this.tabPageInfrared.Text = "Infrared";
      this.tabPageInfrared.UseVisualStyleBackColor = true;
      // 
      // tabPageKeymap
      // 
      this.tabPageKeymap.Controls.Add(this.groupBoxKeymap);
      this.tabPageKeymap.Location = new System.Drawing.Point(4, 22);
      this.tabPageKeymap.Name = "tabPageKeymap";
      this.tabPageKeymap.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageKeymap.Size = new System.Drawing.Size(476, 323);
      this.tabPageKeymap.TabIndex = 2;
      this.tabPageKeymap.Text = "Key mapping";
      this.tabPageKeymap.UseVisualStyleBackColor = true;
      // 
      // GuiControl
      // 
      this.Controls.Add(this.groupBoxStatus);
      this.Controls.Add(this.tabControl);
      this.Name = "GuiControl";
      this.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.Size = new System.Drawing.Size(484, 426);
      this.groupBoxStatus.ResumeLayout(false);
      this.groupBoxStatus.PerformLayout();
      this.groupBoxClockSchedule.ResumeLayout(false);
      this.groupBoxClockSchedule.PerformLayout();
      this.groupBox15.ResumeLayout(false);
      this.groupBox15.PerformLayout();
      this.groupBox10.ResumeLayout(false);
      this.groupBox10.PerformLayout();
      this.groupBox11.ResumeLayout(false);
      this.groupBox11.PerformLayout();
      this.groupBox12.ResumeLayout(false);
      this.groupBox12.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numClockDeviation)).EndInit();
      this.groupBox13.ResumeLayout(false);
      this.groupBox14.ResumeLayout(false);
      this.groupBox14.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numWakeupTimeSpan)).EndInit();
      this.groupBoxInfrared.ResumeLayout(false);
      this.groupBox20.ResumeLayout(false);
      this.groupBox20.PerformLayout();
      this.groupBox21.ResumeLayout(false);
      this.groupBox21.PerformLayout();
      this.groupBox22.ResumeLayout(false);
      this.groupBox22.PerformLayout();
      this.groupBox23.ResumeLayout(false);
      this.groupBox23.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numMinRepeats)).EndInit();
      this.groupBox24.ResumeLayout(false);
      this.groupBox24.PerformLayout();
      this.groupBox25.ResumeLayout(false);
      this.groupBox25.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numSendIrProtocol)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numSendIrAddress)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numSendIrCommand)).EndInit();
      this.groupBoxKeymap.ResumeLayout(false);
      this.groupBoxKeymap.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvKeymap)).EndInit();
      this.tabControl.ResumeLayout(false);
      this.tabPageGeneral.ResumeLayout(false);
      this.tabPageInfrared.ResumeLayout(false);
      this.tabPageKeymap.ResumeLayout(false);
      this.ResumeLayout(false);
    }
    private System.Windows.Forms.ToolTip toolTip;
    private System.Windows.Forms.Label lblControlPcButtons;
    private System.Windows.Forms.Button btnControlPcButtons;
    private System.Windows.Forms.GroupBox groupBox15;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label51;
    private System.Windows.Forms.Label label52;
    private System.Windows.Forms.Label label53;
    private System.Windows.Forms.Label lblLastProtocol;
    private System.Windows.Forms.Label lblLastAddress;
    private System.Windows.Forms.Label lblLastCommand;
    private System.Windows.Forms.Button btnSaveSettings;
    private System.Windows.Forms.Button btnUpdateFirmware;
    private System.Windows.Forms.GroupBox groupBox10;
    private System.Windows.Forms.Button btnAssignCode;
    private System.Windows.Forms.Button btnClearPowerOffCode;
    private System.Windows.Forms.Button btnClearPowerOnCode;
    private System.Windows.Forms.Button btnClearResetCode;
    private System.Windows.Forms.Button btnForwardIrState;
    private System.Windows.Forms.Button btnReadWakeupTime;
    private System.Windows.Forms.Button btnReadTime;
    private System.Windows.Forms.Button btnSaveKeymap;
    private System.Windows.Forms.Button btnSendIrCode;
    private System.Windows.Forms.Button btnSetMinRepeats;
    private System.Windows.Forms.Button btnSetWakeupTimeSpan;
    private System.Windows.Forms.Button btnSetClockDeviation;
    private System.Windows.Forms.Button btnWritePowerOffCode;
    private System.Windows.Forms.Button btnWritePowerOnCode;
    private System.Windows.Forms.Button btnWriteResetCode;
    private System.Windows.Forms.Button btnWriteWakeupTime;
    private System.Windows.Forms.Button btnWriteTime;
    private System.Windows.Forms.CheckBox chbEnableKeySend;
    private System.Windows.Forms.CheckBox chbEnableSyncClocks;
    private System.Windows.Forms.DataGridView dgvKeymap;
    private System.Windows.Forms.DateTimePicker dtpWakeupTime;
    private System.Windows.Forms.DateTimePicker dtpTime;
    private System.Windows.Forms.GroupBox groupBox25;
    private System.Windows.Forms.GroupBox groupBox11;
    private System.Windows.Forms.GroupBox groupBox12;
    private System.Windows.Forms.GroupBox groupBox13;
    private System.Windows.Forms.GroupBox groupBox14;
    private System.Windows.Forms.GroupBox groupBox20;
    private System.Windows.Forms.GroupBox groupBox21;
    private System.Windows.Forms.GroupBox groupBox22;
    private System.Windows.Forms.GroupBox groupBox23;
    private System.Windows.Forms.GroupBox groupBox24;
    private System.Windows.Forms.GroupBox groupBoxClockSchedule;
    private System.Windows.Forms.GroupBox groupBoxInfrared;
    private System.Windows.Forms.GroupBox groupBoxKeymap;
    private System.Windows.Forms.GroupBox groupBoxStatus;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label20;
    private System.Windows.Forms.Label label21;
    private System.Windows.Forms.Label label22;
    private System.Windows.Forms.Label label23;
    private System.Windows.Forms.Label label24;
    private System.Windows.Forms.Label label25;
    private System.Windows.Forms.Label label26;
    private System.Windows.Forms.Label label27;
    private System.Windows.Forms.Label label28;
    private System.Windows.Forms.Label label29;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label30;
    private System.Windows.Forms.Label label31;
    private System.Windows.Forms.Label label32;
    private System.Windows.Forms.Label label33;
    private System.Windows.Forms.Label label34;
    private System.Windows.Forms.Label label35;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label lblConnectionStatus;
    private System.Windows.Forms.Label lblDeviceTime;
    private System.Windows.Forms.Label lblFirmware;
    private System.Windows.Forms.Label lblForwardIrState;
    private System.Windows.Forms.Label lblPowerOffAddress;
    private System.Windows.Forms.Label lblPowerOffCommand;
    private System.Windows.Forms.Label lblPowerOffProtocol;
    private System.Windows.Forms.Label lblPowerOnAddress;
    private System.Windows.Forms.Label lblPowerOnCommand;
    private System.Windows.Forms.Label lblPowerOnProtocol;
    private System.Windows.Forms.Label lblResetAddress;
    private System.Windows.Forms.Label lblResetCommand;
    private System.Windows.Forms.Label lblResetProtocol;
    private System.Windows.Forms.Label lblWakeupTime;
    private System.Windows.Forms.NumericUpDown numMinRepeats;
    private System.Windows.Forms.NumericUpDown numSendIrAddress;
    private System.Windows.Forms.NumericUpDown numSendIrCommand;
    private System.Windows.Forms.NumericUpDown numSendIrProtocol;
    private System.Windows.Forms.NumericUpDown numWakeupTimeSpan;
    private System.Windows.Forms.NumericUpDown numClockDeviation;
    private System.Windows.Forms.RadioButton rdbKeepDevTime;
    private System.Windows.Forms.RadioButton rdbKeepPcTime;
    private System.Windows.Forms.TabControl tabControl;
    private System.Windows.Forms.TabPage tabPageGeneral;
    private System.Windows.Forms.TabPage tabPageInfrared;
    private System.Windows.Forms.TabPage tabPageKeymap;
    private System.Windows.Forms.Button btnAssignApp;
    private System.Windows.Forms.CheckBox chbEnableAppStart;
    
    #endregion
  }
}