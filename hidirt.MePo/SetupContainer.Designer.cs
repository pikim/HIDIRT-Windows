namespace HIDIRT.MePo
{
  partial class hidirtSetupControl
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
      this.SuspendLayout();
      // 
      // GuiControl
      // 
      this.Gui.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                  | System.Windows.Forms.AnchorStyles.Left) 
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.Gui.Location = new System.Drawing.Point(0, 0);
      this.Gui.Name = "GuiControl";
      this.Gui.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.Gui.Size = new System.Drawing.Size(484, 426);
      this.Gui.TabIndex = 0;
      // 
      // hidirtSetupControl
      // 
      this.Controls.Add(this.Gui);
      this.Name = "hidirtSetupControl";
      this.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.Size = new System.Drawing.Size(484, 426);
      this.ResumeLayout(false);
    }
    
    private HIDIRT.GuiControl Gui;
    
    #endregion
  }
}