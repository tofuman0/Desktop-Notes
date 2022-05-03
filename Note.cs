using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Configuration;

namespace DesktopNotes
{
    public partial class Note : Form
    {
        public Note()
        {
            SetStyle(System.Windows.Forms.ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();
            GetConfig();
            BackColor = Color.Transparent;
            notifyIcon1.Visible = true;
        }

        private void GetConfig()
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (Convert.ToInt32(settings["AutoRefresh"].Value) == 1)
                    autoRefreshToolStripMenuItem.Checked = true;

            }
            catch (ConfigurationErrorsException ex)
            {
                MessageBox.Show(null, "Error reading app settings: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveConfig()
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                settings["AutoRefresh"].Value = autoRefreshToolStripMenuItem.Checked ? "1" : "0";
                configFile.Save();
            }
            catch (ConfigurationErrorsException ex)
            {
                MessageBox.Show(null, "Error writing app settings: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void autoRefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            autoRefreshToolStripMenuItem.Checked = autoRefreshToolStripMenuItem.Checked ? false : true;
            Program.Refresh();
            if (autoRefreshToolStripMenuItem.Checked)
            {
                Thread trd = new Thread(new ThreadStart(this.ThreadTask));
                trd.IsBackground = true;
                trd.Start();
            }
            SaveConfig();
        }

        private void ThreadTask()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            while (autoRefreshToolStripMenuItem.Checked)
            {
                if (sw.ElapsedMilliseconds > (1000 * 1))
                {
                    Program.Refresh(true);
                    sw.Restart();
                }
                Thread.Sleep(1);
            }
        }
    }
}
