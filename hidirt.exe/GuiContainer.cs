using System;
using System.Windows.Forms;
using HIDIRT;

namespace HIDIRT
{
  /// <summary>
  /// Container setup for the HIDIRT executable.
  /// </summary>
  public partial class GuiContainer : Form
  {
    #region Public Methods

    public GuiContainer(GuiControl gui)
    {
      this.Gui = gui;
      InitializeComponent();
    }

    #endregion
  }
}
