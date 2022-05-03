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
                FontStyle fontstyle = FontStyle.Regular;
                String[] fontstyles = settings["FontStyle"].Value.Split(',');
                if (fontstyles.Contains("Bold"))
                    fontstyle |= FontStyle.Bold;
                if (fontstyles.Contains("Italic"))
                    fontstyle |= FontStyle.Italic;
                if (fontstyles.Contains("Underline"))
                    fontstyle |= FontStyle.Underline;
                if (fontstyles.Contains("Strikeout"))
                    fontstyle |= FontStyle.Strikeout;
                font = new Font(fontfamily, fontsize, fontstyle);
                fontDialog1.Font = font;
                note = settings["Note"].Value;
                String strAlign = settings["StringAlign"].Value;
                if (strAlign.ToLower() == "left" || strAlign.ToLower() == "center" || strAlign.ToLower() == "right")
                    cbStrAlign.SelectedItem = strAlign;
                else
                    cbStrAlign.SelectedItem = "Left";
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
                FontStyle fontstyle = font.Style;
                String fontstyles = "Regular";
                if (((Int32)fontstyle & (Int32)FontStyle.Bold) != 0)
                    fontstyles = "Bold";
                if (((Int32)fontstyle & (Int32)FontStyle.Italic) != 0)
                    fontstyles += ",Italic";
                if (((Int32)fontstyle & (Int32)FontStyle.Underline) != 0)
                    fontstyles += ",Underline";
                if (((Int32)fontstyle & (Int32)FontStyle.Strikeout) != 0)
                    fontstyles += ",Strikeout";
                settings["FontStyle"].Value = fontstyles;
                settings["StringAlign"].Value = cbStrAlign.Text;
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
                Program.Refresh();
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

        private void btnColour_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                fontcolour = colorDialog1.Color;
                fontcolour = Color.FromArgb(Convert.ToInt32(tbAlpha.Text), fontcolour.R, fontcolour.G, fontcolour.B);
                DisplayConfig();
            }
        }

        private void tbAlpha_Validating(object sender, CancelEventArgs e)
        {
            tbAlpha.Text = ValidatedIntString(sender.ToString());
        }

        private Int32 ConvertToInt(String inStr)
        {
            try
            {
                return Convert.ToInt32(inStr);
            }
            catch
            {
                return 0;
            }
        }
        private UInt32 ConvertToUInt(String inStr)
        {
            try
            {
                return Convert.ToUInt32(inStr);
            }
            catch
            {
                return 0;
            }
        }

        private String ValidatedIntString(String inStr, bool unsigned = false)
        {
            if (unsigned == false)
                return ConvertToInt(inStr).ToString();
            else
                return ConvertToUInt(inStr).ToString();
        }

        private void tbAlpha_Leave(object sender, EventArgs e)
        {
            tbAlpha.Text = ValidatedIntString(tbAlpha.Text);
            fontcolour = Color.FromArgb(Convert.ToInt32(tbAlpha.Text), fontcolour.R, fontcolour.G, fontcolour.B);
        }

        private void tbX_Leave(object sender, EventArgs e)
        {
            locationX = ConvertToUInt(tbX.Text);
            tbX.Text = locationX.ToString();
        }

        private void tbY_Leave(object sender, EventArgs e)
        {
            locationY = ConvertToUInt(tbY.Text);
            tbY.Text = locationY.ToString();
        }
    }
}
