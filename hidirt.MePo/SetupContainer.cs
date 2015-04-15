using System;
using System.Threading;

namespace HIDIRT.MePo
{
  /// <summary>
  /// Container setup for the HIDIRT plugin.
  /// </summary>
  public partial class hidirtSetupControl : SetupTv.SectionSettings
  {
    #region Variables

    private Thread _refreshStatusThread;
    private Thread _setupTvThread;
    private HIDIRT.hidInterface device;
    private HIDIRT.Presenter presenter;

    #endregion

    #region Public Methods

    public hidirtSetupControl()
    {
      this.Gui = new HIDIRT.GuiControl();
      device = HIDIRT.hidInterface.Instance;
      presenter = new HIDIRT.Presenter(device, Gui);
      InitializeComponent();
    }

    public override void LoadSettings()
    {
      // Start the RefeshStatusThread responsible for refreshing status information
      _setupTvThread = Thread.CurrentThread;
      _refreshStatusThread = new Thread(RefreshStatusThread);
      _refreshStatusThread.Name = "RefreshStatusThread";
      _refreshStatusThread.IsBackground = true;
      _refreshStatusThread.Start();
    }

    public override void SaveSettings()
    {
      RefreshStatus();
    }

    #endregion

    #region Private Methods

    private void RefreshStatusThread()
    {
      while (_setupTvThread.IsAlive)
      {
        RefreshStatus();
        Thread.Sleep(5000);
      }
    }

    private void RefreshStatus()
    {
      presenter.ReadDeviceTime();
      presenter.ReadWakeupTime();
    }

    #endregion
  }
}
