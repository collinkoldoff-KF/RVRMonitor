using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RVRMonitor
{
    public partial class Form1 : Form
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        private readonly Timer timer;

        public static string airport = "Select An Airport";
        public Panel rvrPanel;

        public Form1()
        {
            InitializeComponent();
            refreshAirportList();
            timer = new Timer
            {
                Interval = 60000
            };
            timer.Tick += timer_tick;
            timer.Start();
            TopMost = false;
        }
        private void timer_tick(object sender, EventArgs e)
        {
            btnRefreshRVR_Click(null, null);
        }
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnMinimize_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                WindowState = FormWindowState.Minimized;
            }
        }

        private void btnClose_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Application.Exit();
            }
        }

        private void flatButton1_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MessageBox.Show("Developed by Collin Koldoff using the FAA RVR Status Monitor, and the xPilot UI source code developed by Justin Shannon. \n\nDisclaimer: The information contained in this application is to be used for flight simulation purposes only. It is not intended nor should it be used for real world navigation. This application is in no way affiliated with the FAA.", "RVR Monitor Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void refreshAirportList()
        {
            string[] aptList = RVRGrabber.getAirports();
            foreach(string apt in aptList)
            {
                comboBoxAptList.Items.Add(apt);
            }
        }

        private void btnLoadRVR_Click(object sender, EventArgs e)
        {
            airport = comboBoxAptList.SelectedItem.ToString();
            rvrPanel = RVRGrabber.getRVRData(airport);
            Controls.Remove(panel2);
            disposePanel2Controls();
            panel2 = rvrPanel;
            Controls.Add(panel2);
        }

        private void btnRefreshRVR_Click(object sender, EventArgs e)
        {
            rvrPanel = RVRGrabber.getRVRData(airport);
            Controls.Remove(panel2);
            disposePanel2Controls();
            panel2 = rvrPanel;
            Controls.Add(panel2);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = checkBox1.Checked;
        }

        private void disposePanel2Controls()
        {
            List<Control> c = panel2.Controls.OfType<TextBox>().Cast<Control>().ToList();
            foreach (Control item in c)
            {
                item.Dispose();
            }
        }
    }
}
