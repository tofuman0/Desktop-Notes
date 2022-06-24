using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Specialized;
using System.IO;

namespace DesktopNotes
{
    class Program
    {
        static private byte[] wallpaperdata;

        [MTAThread]
        static void Main(string[] args)
        {
            CheckOrCreateConfig();
            DrawDesktop();
            Note note = new Note();
            Application.Run();
            RefreshWallpaper();
        }

        static private void CheckOrCreateConfig()
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                bool save = false;
                if (settings["Font"] == null)
                {
                    settings.Add("Font", "Arial");
                    save = true;
                }
                if (settings["FontSize"] == null)
                {
                    settings.Add("FontSize", "12");
                    save = true;
                }
                if (settings["FontColour"] == null)
                {
                    settings.Add("FontColour", "E0FFFFFF");
                    save = true;
                }
                if (settings["FontStyle"] == null)
                {
                    settings.Add("FontStyle", "Regular");
                    save = true;
                }
                if (settings["Note"] == null)
                {
                    settings.Add("Note", "Desktop Notes:\r\nAdd useful information here!");
                    save = true;
                }
                if (settings["StringAlign"] == null)
                {
                    settings.Add("StringAlign", "Left");
                    save = true;
                }
                if (settings["LocationX"] == null)
                {
                    settings.Add("LocationX", "100");
                    save = true;
                }
                if (settings["LocationY"] == null)
                {
                    settings.Add("LocationY", "100");
                    save = true;
                }
                if (settings["AutoRefresh"] == null)
                {
                    settings.Add("AutoRefresh", "0");
                    save = true;
                }

                if (save)
                    configFile.Save();
            }
            catch (ConfigurationErrorsException ex)
            {
                MessageBox.Show(null, "Error reading/writing app settings: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static public void Refresh(bool ifOnChanged = false)
        {
            if (wallpaperdata == null)
                wallpaperdata = GetWallpaperData();
            if(ifOnChanged)
            {
                byte[] currentwallpaper = GetWallpaperData();
                if (wallpaperdata.SequenceEqual(currentwallpaper))
                    return;
                wallpaperdata = currentwallpaper;
            }
            RefreshWallpaper();
            // Wait some time before drawing
            Thread.Sleep(1000);
            DrawDesktop();

        }

        static private void SetDesktopShadow(bool enable)
        {
            W32.SystemParametersInfo(0x1041, 0, enable, 0x3);
        }

        static private byte[] GetWallpaperData()
        {
            byte[] currentwallpaperdata = null;
            StringBuilder s = new StringBuilder(300);
            // Get Wallpaper
            if(W32.SystemParametersInfo(0x0073, 300, s, 0) == 1)
                currentwallpaperdata = File.ReadAllBytes(s.ToString());
            return currentwallpaperdata;
        }

        static public void DrawDesktop()
        {
            // Fetch the Progman window
            IntPtr progman = W32.FindWindow("Progman", null);

            IntPtr result = IntPtr.Zero;

            // Send 0x052C to Progman. This message directs Progman to spawn a 
            // WorkerW behind the desktop icons. If it is already there, nothing 
            // happens.
            W32.SendMessageTimeout(progman,
                                   0x052C,
                                   new IntPtr(0),
                                   IntPtr.Zero,
                                   W32.SendMessageTimeoutFlags.SMTO_NORMAL,
                                   1000,
                                   out result);

            IntPtr workerw = IntPtr.Zero;

            // We enumerate all Windows, until we find one, that has the SHELLDLL_DefView 
            // as a child. 
            // If we found that window, we take its next sibling and assign it to workerw.
            W32.EnumWindows(new W32.EnumWindowsProc((tophandle, topparamhandle) =>
            {
                IntPtr p = W32.FindWindowEx(tophandle,
                                            IntPtr.Zero,
                                            "SHELLDLL_DefView",
                                            IntPtr.Zero);

                if (p != IntPtr.Zero)
                {
                    // Gets the WorkerW Window after the current one.
                    workerw = W32.FindWindowEx(IntPtr.Zero,
                                               tophandle,
                                               "WorkerW",
                                               IntPtr.Zero);
                }

                return true;
            }), IntPtr.Zero);

            // Get the Device Context of the WorkerW
            IntPtr dc = W32.GetDCEx(workerw, IntPtr.Zero, (W32.DeviceContextValues)0x403);
            if (dc != IntPtr.Zero)
            {
                SetDesktopShadow(false);
                // Create a Graphics instance from the Device Context
                DrawNotes(dc);

                // make sure to release the device context after use.
                W32.ReleaseDC(workerw, dc);
            }
        }

        static public void DrawNotes(IntPtr dc)
        {
            using (Graphics g = Graphics.FromHdc(dc))
            {
                try
                {
                    g.TranslateClip(2, 2);

                    var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    var settings = configFile.AppSettings.Settings;
                    String fontfamily = settings["Font"].Value;
                    Single fontsize = Convert.ToSingle(settings["FontSize"].Value);
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
                    Int32 fontcolour = Convert.ToInt32(settings["FontColour"].Value, 16);
                    String note = settings["Note"].Value;
                    UInt32 locationx = Convert.ToUInt32(settings["LocationX"].Value);
                    UInt32 locationy = Convert.ToUInt32(settings["LocationY"].Value);
                    Font font = new Font(fontfamily, fontsize, fontstyle);
                    StringAlignment stringAlignment = StringAlignment.Near;
                    String strAlignment = settings["StringAlign"].Value;
                    if (strAlignment.ToLower() == "center")
                        stringAlignment = StringAlignment.Center;
                    else if (strAlignment.ToLower() == "right")
                        stringAlignment = StringAlignment.Far;
                    StringFormat stringFormat = new StringFormat();
                    stringFormat.Alignment = stringAlignment;
                    Brush brush = new SolidBrush(Color.FromArgb(fontcolour));
                    Rectangle resolution = Screen.PrimaryScreen.Bounds;
                    g.DrawString(note, font, brush, new PointF(locationx, locationy), stringFormat);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(null, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        static public void RefreshWallpaper()
        {
            StringBuilder s = new StringBuilder(300);
            // Get Wallpaper
            int res = W32.SystemParametersInfo(0x0073, 300, s, 0);
            if (res == 1)
            {
                // Set Wallpaper
                W32.SystemParametersInfo(0x0014, 0, s, 0x2);
            }
        }               
    }
}
