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
        public static Airport[] airportList;
        public static bool airportListCached = false;
        public static string[] rvrList = new string[] { };
        public static int totalRwys = 0;
        public static int rvrIndex = 0;
        public Panel rvrPanel;

        public Form1()
        {
            InitializeComponent();
            Task.Run(() => refreshAirportList());
            timer = new Timer
            {
                Interval = 60000
            };
            timer.Tick += timer_tick;
            timer.Start();
            TopMost = false;
            comboBoxAptList.Hide();
            comboBoxRwyList.Hide();
            btnAddRwyConfirm.Hide();
            btnAddRwyCancel.Hide();
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

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        private async void refreshAirportList()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            RVRGrabber rvrGrabber = new RVRGrabber();
            rvrGrabber.getAirports();

            foreach (Airport apt in airportList)
            {
                Invoke((MethodInvoker)delegate ()
                {
                    comboBoxAptList.Items.Add(apt.code);
                });
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
            rvrIndex = 0;
            foreach (Control control in panel2.Controls)
            {
                if (control != panel3)
                {
                    panel2.Controls.Remove(control);
                }
            }
            if (rvrList.Length != 0)
            {
                foreach (string aptRwy in rvrList)
                {
                    rvrPanel = RVRGrabber.getRVRData(aptRwy);
                    rvrIndex++;
                    FlatButton btnDeleteRVR = new FlatButton();
                    btnDeleteRVR.BackColor = Color.FromArgb(207, 94, 57);
                    btnDeleteRVR.BorderColor = Color.FromArgb(192, 57, 43);
                    btnDeleteRVR.Clicked = false;
                    btnDeleteRVR.ClickedColor = Color.FromArgb(0, 120, 206);
                    btnDeleteRVR.Cursor = Cursors.Hand;
                    btnDeleteRVR.DisabledTextColor = Color.DarkGray;
                    btnDeleteRVR.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                    btnDeleteRVR.ForeColor = Color.White;
                    btnDeleteRVR.Location = new Point(300, 0);
                    btnDeleteRVR.Margin = new Padding(4);
                    btnDeleteRVR.Name = "btnDeleteRVR";
                    btnDeleteRVR.Pushed = false;
                    btnDeleteRVR.PushedColor = Color.FromArgb(231, 76, 60);
                    btnDeleteRVR.Size = new Size(20, 30);
                    btnDeleteRVR.TabIndex = 2;
                    btnDeleteRVR.Text = "X";
                    btnDeleteRVR.MouseClick += new MouseEventHandler(btnDeleteRVR_Click);
                    rvrPanel.Controls.Add(btnDeleteRVR);
                    
                    panel2.Controls.Add(rvrPanel);
                }
            } else
            {
                Panel rvrPanel = new Panel();
                panel2.Controls.Add(rvrPanel);
            }
            Controls.Remove(panel2);
            disposePanel2Controls();
            Controls.Add(panel2);
        }
        private void btnDeleteRVR_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int index = rvrIndex - 1;
                removeIndex(index);
                totalRwys--;
                foreach (string test in rvrList)
                {
                    Debug.WriteLine(test);
                }
                btnRefreshRVR_Click(null, null);
                panel3.Location = new Point(0, (totalRwys * 40));
                btnRefreshRVR_Click(null, null);
            }
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

        private void btnAddRwy_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                comboBoxAptList.Show();
                btnAddRwyCancel.Show();
            }
        }

        private void comboBoxAptList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(comboBoxAptList.Text == "Select An Airport"))
            {
                comboBoxRwyList.Items.Clear();
                comboBoxRwyList.Items.Add("Select A Runway");
                comboBoxRwyList.SelectedIndex = 0;
                Airport apt = airportList[comboBoxAptList.SelectedIndex - 1];
                foreach (string rwy in apt.runways)
                {
                    comboBoxRwyList.Items.Add(rwy);
                }
                comboBoxRwyList.Show();
            } 
            else
            {
                comboBoxRwyList.Hide();
                btnAddRwyConfirm.Hide();
            }
        }

        private void comboBoxRwyList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(comboBoxRwyList.Text == "Select A Runway"))
            {
                btnAddRwyConfirm.Show();
            }
            else
            {
                btnAddRwyConfirm.Hide();
            }
        }

        private void btnAddRwyCancel_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                comboBoxAptList.SelectedIndex = 0;
                comboBoxRwyList.SelectedIndex = 0;
                comboBoxAptList.Hide();
                comboBoxRwyList.Hide();
                btnAddRwyConfirm.Hide();
                btnAddRwyCancel.Hide();
            }
        }
        private void btnAddRwyConfirm_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Array.Resize(ref rvrList, rvrList.Length + 1);
                rvrList[rvrList.Length - 1] = comboBoxAptList.Text + "." + comboBoxRwyList.Text;

                comboBoxAptList.SelectedIndex = 0;
                comboBoxRwyList.SelectedIndex = 0;
                comboBoxAptList.Hide();
                comboBoxRwyList.Hide();
                btnAddRwyConfirm.Hide(); 
                btnAddRwyCancel.Hide();

                totalRwys++;
                panel3.Location = new Point(0, (totalRwys * 40));
                btnRefreshRVR_Click(null, null);
            }
        }
        private static void removeIndex(int index)
        {
            try {
                string[] oldArray = rvrList;
                string[] newArray = new string[oldArray.Length - 1];

                int i = 0;
                int j = 0;
                while (i < oldArray.Length)
                {
                    if (i != index)
                    {
                        newArray[j] = oldArray[i];
                        j++;
                    }
                    i++;
                }
                rvrList = newArray;
            } catch { }
        }
    }
}
