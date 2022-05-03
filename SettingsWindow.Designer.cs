
namespace DesktopNotes
{
    partial class SettingsWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbNote = new System.Windows.Forms.TextBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.lblFont = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.btnFont = new System.Windows.Forms.Button();
            this.tbX = new System.Windows.Forms.TextBox();
            this.tbY = new System.Windows.Forms.TextBox();
            this.lblX = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.tbAlpha = new System.Windows.Forms.TextBox();
            this.lblAlpha = new System.Windows.Forms.Label();
            this.btnColour = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.cbStrAlign = new System.Windows.Forms.ComboBox();
            this.lblAlignment = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(163, 399);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(244, 399);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tbNote
            // 
            this.tbNote.Location = new System.Drawing.Point(12, 123);
            this.tbNote.Multiline = true;
            this.tbNote.Name = "tbNote";
            this.tbNote.Size = new System.Drawing.Size(307, 270);
            this.tbNote.TabIndex = 2;
            this.tbNote.TextChanged += new System.EventHandler(this.tbNote_TextChanged);
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Location = new System.Drawing.Point(12, 107);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(33, 13);
            this.lblNote.TabIndex = 3;
            this.lblNote.Text = "Note:";
            // 
            // lblFont
            // 
            this.lblFont.AutoSize = true;
            this.lblFont.Location = new System.Drawing.Point(12, 14);
            this.lblFont.Name = "lblFont";
            this.lblFont.Size = new System.Drawing.Size(31, 13);
            this.lblFont.TabIndex = 4;
            this.lblFont.Text = "Font:";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(12, 62);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(51, 13);
            this.lblLocation.TabIndex = 5;
            this.lblLocation.Text = "Location:";
            // 
            // btnFont
            // 
            this.btnFont.Location = new System.Drawing.Point(12, 34);
            this.btnFont.Name = "btnFont";
            this.btnFont.Size = new System.Drawing.Size(85, 23);
            this.btnFont.TabIndex = 6;
            this.btnFont.Text = "Change Font";
            this.btnFont.UseVisualStyleBackColor = true;
            this.btnFont.Click += new System.EventHandler(this.btnFont_Click);
            // 
            // tbX
            // 
            this.tbX.Location = new System.Drawing.Point(35, 79);
            this.tbX.Name = "tbX";
            this.tbX.Size = new System.Drawing.Size(64, 20);
            this.tbX.TabIndex = 7;
            this.tbX.Leave += new System.EventHandler(this.tbX_Leave);
            // 
            // tbY
            // 
            this.tbY.Location = new System.Drawing.Point(125, 79);
            this.tbY.Name = "tbY";
            this.tbY.Size = new System.Drawing.Size(64, 20);
            this.tbY.TabIndex = 8;
            this.tbY.Leave += new System.EventHandler(this.tbY_Leave);
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(12, 82);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(17, 13);
            this.lblX.TabIndex = 9;
            this.lblX.Text = "X:";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(102, 82);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(17, 13);
            this.lblY.TabIndex = 10;
            this.lblY.Text = "Y:";
            // 
            // tbAlpha
            // 
            this.tbAlpha.Location = new System.Drawing.Point(261, 34);
            this.tbAlpha.Name = "tbAlpha";
            this.tbAlpha.Size = new System.Drawing.Size(58, 20);
            this.tbAlpha.TabIndex = 11;
            this.tbAlpha.Leave += new System.EventHandler(this.tbAlpha_Leave);
            // 
            // lblAlpha
            // 
            this.lblAlpha.AutoSize = true;
            this.lblAlpha.Location = new System.Drawing.Point(218, 37);
            this.lblAlpha.Name = "lblAlpha";
            this.lblAlpha.Size = new System.Drawing.Size(37, 13);
            this.lblAlpha.TabIndex = 12;
            this.lblAlpha.Text = "Alpha:";
            // 
            // btnColour
            // 
            this.btnColour.Location = new System.Drawing.Point(103, 34);
            this.btnColour.Name = "btnColour";
            this.btnColour.Size = new System.Drawing.Size(109, 23);
            this.btnColour.TabIndex = 13;
            this.btnColour.Text = "Change Colour";
            this.btnColour.UseVisualStyleBackColor = true;
            this.btnColour.Click += new System.EventHandler(this.btnColour_Click);
            // 
            // cbStrAlign
            // 
            this.cbStrAlign.FormattingEnabled = true;
            this.cbStrAlign.Items.AddRange(new object[] {
            "Left",
            "Center",
            "Right"});
            this.cbStrAlign.Location = new System.Drawing.Point(208, 78);
            this.cbStrAlign.Name = "cbStrAlign";
            this.cbStrAlign.Size = new System.Drawing.Size(111, 21);
            this.cbStrAlign.TabIndex = 14;
            this.cbStrAlign.Text = "Left";
            // 
            // lblAlignment
            // 
            this.lblAlignment.AutoSize = true;
            this.lblAlignment.Location = new System.Drawing.Point(205, 61);
            this.lblAlignment.Name = "lblAlignment";
            this.lblAlignment.Size = new System.Drawing.Size(56, 13);
            this.lblAlignment.TabIndex = 15;
            this.lblAlignment.Text = "Alignment:";
            // 
            // SettingsWindow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(331, 428);
            this.Controls.Add(this.lblAlignment);
            this.Controls.Add(this.cbStrAlign);
            this.Controls.Add(this.btnColour);
            this.Controls.Add(this.lblAlpha);
            this.Controls.Add(this.tbAlpha);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.tbY);
            this.Controls.Add(this.tbX);
            this.Controls.Add(this.btnFont);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblFont);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.tbNote);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Settings";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbNote;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Label lblFont;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button btnFont;
        private System.Windows.Forms.TextBox tbX;
        private System.Windows.Forms.TextBox tbY;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.TextBox tbAlpha;
        private System.Windows.Forms.Label lblAlpha;
        private System.Windows.Forms.Button btnColour;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ComboBox cbStrAlign;
        private System.Windows.Forms.Label lblAlignment;
    }
}