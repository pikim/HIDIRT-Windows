namespace HIDIRT
{
  partial class GuiContainer
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
      this.Gui.Location = new System.Drawing.Point(6, 6);
      this.Gui.Name = "GuiControl";
      this.Gui.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.Gui.Size = new System.Drawing.Size(484, 426);
      this.Gui.TabIndex = 0;
      // 
      // exeForm
      // 
      this.ClientSize = new System.Drawing.Size(496, 438);
      this.Controls.Add(this.Gui);
      this.MinimumSize = new System.Drawing.Size(514, 481);
      this.Name = "exeForm";
      this.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.Text = "HIDIRT";
      this.ResumeLayout(false);
    }
    
    private HIDIRT.GuiControl Gui;

    #endregion
  }
}