
///<summary>
///
/// Author:
/// Michael Kipp
///
/// Class:
/// GuiControl
///
/// Purpose:
/// Represents the Windows Forms GUI for the HIDIRT standalone application and
/// the corresponding MediaPortal plugin. Can be used for both without any
/// modifications. Therefore only the controls themselves are included without
/// any container. Contains only a minimum of application logic.
///
/// </summary>

using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using HIDIRT;

namespace HIDIRT
{
  /// <summary>
  /// Gui for the HIDIRT executable/plugin.
  /// </summary>
  public partial class GuiControl : UserControl, IView
  {
    private DataTable dataTable;
    private ControlInvoker controlInvoker;

    #region Methods

    public GuiControl()
    {
      InitializeComponent();
      controlInvoker = new ControlInvoker(this);
      // Following leads to graphical issues in #develop when set as default in designer
      dgvKeymap.RowHeadersWidth = 24;
//      numSendIrProtocol = new NumericUpDown2DigitHex();
//      numSendIrAddress = new NumericUpDown4DigitHex();
//      numSendIrCommand = new NumericUpDown4DigitHex();
    }
    
    private void TabControlSelecting(object sender, TabControlCancelEventArgs e)
    {
      if (tabControl.SelectedIndex == 0)
      {
        if (this.UpdateGeneralTab != null)
          this.UpdateGeneralTab();
      }
      else if (tabControl.SelectedIndex == 1)
      {
        if (this.UpdateIrTab != null)
          this.UpdateIrTab();
      }
      else if (tabControl.SelectedIndex == 2)
      {
        if (this.UpdateKeymapTab != null)
          this.UpdateKeymapTab();
      }
    }
    
    #endregion

    #region Form Control

    #region Enable & Disable controls

    public void DisableControls()
    {
      if (InvokeRequired)
      {
        Invoke((MethodInvoker)DisableControls);
      }
      else
      {
        btnClearPowerOffCode.Enabled = false;
        btnClearPowerOnCode.Enabled = false;
        btnClearResetCode.Enabled = false;
        btnControlPcButtons.Enabled = false;
        btnForwardIrState.Enabled = false;
        btnReadTime.Enabled = false;
        btnReadWakeupTime.Enabled = false;
        btnSendIrCode.Enabled = false;
        btnSetClockDeviation.Enabled = false;
        btnSetMinRepeats.Enabled = false;
        btnSetWakeupTimeSpan.Enabled = false;
        btnUpdateFirmware.Enabled = false;
        btnWritePowerOffCode.Enabled = false;
        btnWritePowerOnCode.Enabled = false;
        btnWriteResetCode.Enabled = false;
        btnWriteTime.Enabled = false;
        btnWriteWakeupTime.Enabled = false;
        dtpTime.Enabled = false;
        dtpWakeupTime.Enabled = false;
        numMinRepeats.Enabled = false;
        numClockDeviation.Enabled = false;
        numSendIrAddress.Enabled = false;
        numSendIrCommand.Enabled = false;
        numSendIrProtocol.Enabled = false;
        numWakeupTimeSpan.Enabled = false;
      }
    }

    public void EnableControls()
    {
      if (InvokeRequired)
      {
        Invoke((MethodInvoker)EnableControls);
      }
      else
      {
        btnClearPowerOffCode.Enabled = true;
        btnClearPowerOnCode.Enabled = true;
        btnClearResetCode.Enabled = true;
        btnControlPcButtons.Enabled = true;
        btnForwardIrState.Enabled = true;
        btnReadTime.Enabled = true;
        btnReadWakeupTime.Enabled = true;
        btnSendIrCode.Enabled = true;
        btnSetClockDeviation.Enabled = true;
        btnSetMinRepeats.Enabled = true;
        btnSetWakeupTimeSpan.Enabled = true;
//        btnUpdateFirmware.Enabled = true;
        btnWritePowerOffCode.Enabled = true;
        btnWritePowerOnCode.Enabled = true;
        btnWriteResetCode.Enabled = true;
        btnWriteTime.Enabled = true;
        btnWriteWakeupTime.Enabled = true;
        dtpTime.Enabled = true;
        dtpWakeupTime.Enabled = true;
        numMinRepeats.Enabled = true;
        numClockDeviation.Enabled = true;
        numSendIrAddress.Enabled = true;
        numSendIrCommand.Enabled = true;
        numSendIrProtocol.Enabled = true;
        numWakeupTimeSpan.Enabled = true;
      }
    }

    #endregion

    #region General, Clock & Schedule
    
    void ChbSyncClocksCheckedChanged(object sender, EventArgs e)
    {
        rdbKeepDevTime.Enabled = chbEnableSyncClocks.Checked;
        rdbKeepPcTime.Enabled = chbEnableSyncClocks.Checked;
    }
    
    void BtnSaveSettingsClick(object sender, EventArgs e)
    {
      if (this.SaveSettings != null)
        this.SaveSettings();
    }

    void BtnReadTimeClick(object sender, EventArgs e)
    {
      if (this.ReadTime != null)
        this.ReadTime();
    }
    
    void BtnWriteTimeClick(object sender, EventArgs e)
    {
      if (this.WriteTime != null)
        this.WriteTime();
    }
    
    void BtnSetClockCorrectionClick(object sender, EventArgs e)
    {
      if (this.WriteTimeCorrection != null)
        this.WriteTimeCorrection();
    }
    
    void BtnReadWakeupTimeClick(object sender, EventArgs e)
    {
      if (this.ReadWakeupTime != null)
        this.ReadWakeupTime();
    }
    
    void BtnWriteWakeupTimeClick(object sender, EventArgs e)
    {
      if (this.WriteWakeupTime != null)
        this.WriteWakeupTime();
    }
    
    void BtnSetWakeupTimeSpanClick(object sender, EventArgs e)
    {
      if (this.WriteWakeupTimeSpan != null)
        this.WriteWakeupTimeSpan();
    }
    
    void BtnControlPcButtonsClick(object sender, EventArgs e)
    {
      if (this.WriteControlPcState != null)
        this.WriteControlPcState();
    }
    
    void BtnUpdateFirmwareClick(object sender, EventArgs e)
    {
      if (this.UpdateFirmware != null)
        this.UpdateFirmware();
    }
    
    #endregion

    #region Infrared
    
    void BtnClearPowerOnClick(object sender, EventArgs e)
    {
      if (this.ClearPowerOnCode != null)
        this.ClearPowerOnCode();
    }
    
    void BtnWritePowerOnClick(object sender, EventArgs e)
    {
      if (this.WritePowerOnCode != null)
        this.WritePowerOnCode();
    }
    
    void BtnClearPowerOffClick(object sender, EventArgs e)
    {
      if (this.ClearPowerOffCode != null)
        this.ClearPowerOffCode();
    }
    
    void BtnWritePowerOffClick(object sender, EventArgs e)
    {
      if (this.WritePowerOffCode != null)
        this.WritePowerOffCode();
    }
    
    void BtnClearResetClick(object sender, EventArgs e)
    {
      if (this.ClearResetCode != null)
        this.ClearResetCode();
    }
    
    void BtnWriteResetClick(object sender, EventArgs e)
    {
      if (this.WriteResetCode != null)
        this.WriteResetCode();
    }
    
    void BtnSetMinRepeatsClick(object sender, EventArgs e)
    {
      if (this.WriteMinRepeats != null)
        this.WriteMinRepeats();
    }
    
    void BtnForwardIrCodesClick(object sender, EventArgs e)
    {
      if (this.WriteForwardIrState != null)
        this.WriteForwardIrState();
    }

    void BtnSendIrCodeClick(object sender, EventArgs e)
    {
      if (this.SendIrCode != null)
        this.SendIrCode();
    }

    #endregion

    #region Keymapping
    
    void DgvKeymapCellParsing(object sender, DataGridViewCellParsingEventArgs e)
    {
      if ((e != null) && (e.Value != null))
      {
        if (e.DesiredType.Equals(typeof(Byte)))
        {
          Byte hex;
          try
          {
            String val = e.Value.ToString().ToLower();
            if (val.StartsWith("0x"))
            {
              hex = Convert.ToByte(val, 16);
            }
            else
            {
              hex = Convert.ToByte(val);
            }
          }
          catch
          {
            MessageBox.Show("Format error of input value. Please insert value again.",
                            "Format error",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            hex = 0;
          }
          e.Value = hex;
        }
        
        if (e.DesiredType.Equals(typeof(UInt16)))
        {
          UInt16 hex;
          try
          {
            String val = e.Value.ToString().ToLower();
            if (val.StartsWith("0x"))
            {
              hex = Convert.ToUInt16(val, 16);
            }
            else
            {
              hex = Convert.ToUInt16(val);
            }
          }
          catch
          {
            MessageBox.Show("Format error of input value. Please insert value again.",
                            "Format error",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            hex = 0;
          }
          e.Value = hex;
        }
        e.ParsingApplied = true;
      }
    }
        
    void DgvKeymapKeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Delete)
      {
        dgvKeymap.CurrentCell.Value = DBNull.Value;
      }
    }

    void BtnAssignCodeClick(object sender, EventArgs e)
    {
      if ((dgvKeymap.CurrentRow == null) && (dgvKeymap.SelectedCells.Count > 0))
      {
        dgvKeymap.CurrentCell = dgvKeymap.SelectedCells[0];
      }
      
      if ((dgvKeymap.CurrentRow != null) && (lblLastProtocol.Text != "none"))
      {
        dgvKeymap.CurrentRow.Cells["IrProtocol"].Value = Convert.ToByte(lblLastProtocol.Text, 16);
        dgvKeymap.CurrentRow.Cells["IrAddress"].Value = Convert.ToUInt16(lblLastAddress.Text, 16);
        dgvKeymap.CurrentRow.Cells["IrCommand"].Value = Convert.ToUInt16(lblLastCommand.Text, 16);
      }
    }
    
    void BtnAssignAppClick(object sender, EventArgs e)
    {
      OpenFileDialog ofd = new OpenFileDialog();
      ofd.Filter = "Executables (*.exe; *.bat)|*.exe; *.bat|All files (*.*)|*.*";
      ofd.RestoreDirectory = true;

      if (ofd.ShowDialog() == DialogResult.OK)
      {
        String applicationpath = "";
        String filename = "";
        String directoryname = "";

        filename = Path.GetFileName(ofd.FileName);
        directoryname = Path.GetDirectoryName(ofd.FileName);
        applicationpath = Path.GetDirectoryName(Application.ExecutablePath);

        if (applicationpath == directoryname)
        {
          dgvKeymap.CurrentRow.Cells["Application"].Value = filename;
        }
        else
        {
          dgvKeymap.CurrentRow.Cells["Application"].Value = ofd.FileName;
        }
      }
    }

    void BtnSaveAssignmentClick(object sender, EventArgs e)
    {
      dgvKeymap.EndEdit();
      
      if (this.SaveAssignment != null)
        this.SaveAssignment();
    }

    #endregion
    
    #region Accessible form properties
    
    public ControlInvoker ctrlInv
    {
       get { return controlInvoker; }
    }
    
    public DataTable assignment
    {
      get
      {
        return dataTable;
//        DataTable dt = new DataTable("Keymap");
//        foreach (DataGridViewColumn gridCol in dgvKeymap.Columns)
//        {
//          dt.Columns.Add(gridCol.Name);
//        }
//        foreach (DataGridViewRow gridRow in dgvKeymap.Rows)
//        {
//          if (gridRow.IsNewRow)
//            continue;
//          
//          DataRow dtRow = dt.NewRow();
//          for (Int32 col = 0; col < dgvKeymap.Columns.Count; col++)
//          {
//            dtRow[col] = (gridRow.Cells[col].Value == null ? DBNull.Value : gridRow.Cells[col].Value);
//          }
//          dt.Rows.Add(dtRow);
//        }
//        return dt;
      }
      set
      {
        dataTable = value;
        dgvKeymap.DataSource = dataTable;
        dgvKeymap.Columns["IrProtocol"].DefaultCellStyle.Format = "X2";
        dgvKeymap.Columns["IrAddress"].DefaultCellStyle.Format = "X4";
        dgvKeymap.Columns["IrCommand"].DefaultCellStyle.Format = "X4";
        
        dgvKeymap.AutoResizeColumn(dgvKeymap.Columns["IrProtocol"].Index,
                                   DataGridViewAutoSizeColumnMode.AllCells);
        dgvKeymap.AutoResizeColumn(dgvKeymap.Columns["IrAddress"].Index,
                                   DataGridViewAutoSizeColumnMode.AllCells);
        dgvKeymap.AutoResizeColumn(dgvKeymap.Columns["IrCommand"].Index,
                                   DataGridViewAutoSizeColumnMode.AllCells);
        dgvKeymap.AutoResizeColumn(dgvKeymap.Columns["Key"].Index,
                                   DataGridViewAutoSizeColumnMode.AllCells);

//        dgvKeymap.Columns["IrAddress"].Width = dgvKeymap.Columns["IrAddress"].
//          GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true)-18;
      }
    }

    #endregion
    
    #region Form events

    public event Action UpdateGeneralTab;
    public event Action UpdateIrTab;
    public event Action UpdateKeymapTab;

    public event Action SaveSettings;
    public event Action ReadTime;
    public event Action WriteTime;
    public event Action WriteTimeCorrection;
    public event Action ReadWakeupTime;
    public event Action WriteWakeupTime;
    public event Action WriteWakeupTimeSpan;
    public event Action WriteControlPcState;
    public event Action UpdateFirmware;
    
    public event Action ClearPowerOnCode;
    public event Action WritePowerOnCode;
    public event Action ClearPowerOffCode;
    public event Action WritePowerOffCode;
    public event Action ClearResetCode;
    public event Action WriteResetCode;
    public event Action WriteMinRepeats;
    public event Action WriteForwardIrState;
    public event Action SendIrCode;
    
    public event Action SaveAssignment;
    
    #endregion

    #endregion
  }
}
