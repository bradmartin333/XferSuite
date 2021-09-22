using System;
using System.Linq;
using System.Windows.Forms;

namespace XferSuite
{
    public class HourGlass : IDisposable
    {
        public HourGlass(bool UsePlexiglass = true)
        {
            if (UsePlexiglass)
            {
                MainMenu mainMenu = Application.OpenForms.OfType<MainMenu>().First();
                TableLayoutPanel tableLayoutPanel = mainMenu.tableLayoutPanel;
                PlexiGlass plexiglass = new PlexiGlass()
                {
                    Location = tableLayoutPanel.PointToScreen(tableLayoutPanel.Location),
                    Opacity = 0.85
                };
                plexiglass.Show();
                plexiglass.BringToFront();
                Application.DoEvents();
            }
            
            Enabled = true;
        }
        public void Dispose()
        {
            if (Application.OpenForms.OfType<PlexiGlass>().Any())
                Application.OpenForms.OfType<PlexiGlass>().First().Close();
            Enabled = false;
        }
        public static bool Enabled
        {
            get { return Application.UseWaitCursor; }
            set
            {
                if (value == Application.UseWaitCursor) return;
                Application.UseWaitCursor = value;
                Form f = Form.ActiveForm;
                if (f != null && f.Handle != null)   // Send WM_SETCURSOR
                    SendMessage(f.Handle, 0x20, f.Handle, (IntPtr)1);
            }
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
    }
}
