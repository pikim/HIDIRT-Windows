using System;
using System.Data;
using HIDIRT;

namespace HIDIRT
{
  /// <summary>
  /// Description of IView.
  /// </summary>
  public interface IView
  {
    #region View Properties
    
    ControlInvoker ctrlInv { get; }
    
    DataTable assignment { get; set; }
    
    #endregion
    
    #region View Methods
    
    void DisableControls();
    void EnableControls();
    
    #endregion
    
    #region View Events
    
    event Action UpdateGeneralTab;
    event Action UpdateIrTab;
    event Action UpdateKeymapTab;
    
    event Action SaveSettings;
    event Action ReadTime;
    event Action WriteTime;
    event Action WriteTimeCorrection;
    event Action ReadWakeupTime;
    event Action WriteWakeupTime;
    event Action WriteWakeupTimeSpan;
    event Action WriteControlPcState;
    event Action UpdateFirmware;
    
    event Action ClearPowerOnCode;
    event Action WritePowerOnCode;
    event Action ClearPowerOffCode;
    event Action WritePowerOffCode;
    event Action ClearResetCode;
    event Action WriteResetCode;
    event Action WriteMinRepeats;
    event Action WriteForwardIrState;
    event Action HandleCustomIrCode;
    
    event Action SaveAssignment;
    event Action<IrCode> SendSavedIrCode;
    
    #endregion
  }
}
