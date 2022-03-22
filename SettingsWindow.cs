using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Specialized;

namespace DesktopNotes
{
    public partial class SettingsWindow : Form
    {
        private Font font;
        private Color fontcolour;
        private UInt32 locationX;
        private UInt32 locationY;
        private String note;
        public SettingsWindow()
        {
            InitializeComponent();
            GetConfig();
            DisplayConfig();
        }

        private void GetConfig()
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                String fontfamily = settings["Font"].Value;
                Single fontsize = Convert.ToSingle(settings["FontSize"].Value);
                fontcolour = Color.FromArgb(Convert.ToInt32(settings["FontColour"].Value, 16));
                font = new Font(fontfamily, fontsize);
                note = settings["Note"].Value;
                locationX = Convert.ToUInt32(settings["LocationX"].Value);
                locationY = Convert.ToUInt32(settings["LocationY"].Value);
            }
            catch (ConfigurationErrorsException ex)
            {
                MessageBox.Show(null, "Error reading app settings: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayConfig()
        {
            lblFont.Text = "Font: " + font.Name + ", " + font.Size + "pt, Colour: " + fontcolour.R + ", " + fontcolour.G + ", " + fontcolour.B;
            tbAlpha.Text = (fontcolour.A).ToString();
            tbNote.Text = note;
            tbX.Text = locationX.ToString();
            tbY.Text = locationY.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                settings["Font"].Value = font.Name;
                settings["FontSize"].Value = font.Size.ToString();
                settings["FontColour"].Value = fontcolour.ToArgb().ToString("X");
                settings["Note"].Value = note;
                settings["LocationX"].Value = locationX.ToString();
                settings["LocationY"].Value = locationY.ToString();
                configFile.Save();
            }
            catch (ConfigurationErrorsException ex)
            {
                MessageBox.Show(null, "Error writing app settings: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Close();
            }
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            if(fontDialog1.ShowDialog() == DialogResult.OK)
            {
                font = fontDialog1.Font;
                DisplayConfig();
            }
        }

        private void tbNote_TextChanged(object sender, EventArgs e)
        {
            note = tbNote.Text;
        }

        private void tbAlpha_TextChanged(object sender, EventArgs e)
        {
            fontcolour = Color.FromArgb(Convert.ToInt32(tbAlpha.Text), fontcolour.R, fontcolour.G, fontcolour.B);
        }

        private void tbX_TextChanged(object sender, EventArgs e)
        {
            locationX = Convert.ToUInt32(tbX.Text);
        }

        private void tbY_TextChanged(object sender, EventArgs e)
        {
            locationY = Convert.ToUInt32(tbY.Text);
        }

        private void btnColour_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                fontcolour = colorDialog1.Color;
                fontcolour = Color.FromArgb(Convert.ToInt32(tbAlpha.Text), fontcolour.R, fontcolour.G, fontcolour.B);
                DisplayConfig();
            }
        }
    }
}
