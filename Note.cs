using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DesktopNotes
{
    public partial class Note : Form
    {
        public Note()
        {
            SetStyle(System.Windows.Forms.ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();
            BackColor = Color.Transparent;
            notifyIcon1.Visible = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsWindow sw = new SettingsWindow();
            sw.ShowDialog();
        }
    }
}
