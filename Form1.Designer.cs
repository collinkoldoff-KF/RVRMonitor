namespace RVRMonitor
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxAptList = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.comboBoxRwyList = new System.Windows.Forms.ComboBox();
            this.btnAddRwyCancel = new RVRMonitor.FlatButton();
            this.btnAddRwyConfirm = new RVRMonitor.FlatButton();
            this.btnAddRwy = new RVRMonitor.FlatButton();
            this.btnRefreshRVR = new RVRMonitor.FlatButton();
            this.btnLoadRVR = new RVRMonitor.FlatButton();
            this.pnlToolbar = new RVRMonitor.TransparentClickPanel();
            this.btnInfo = new RVRMonitor.FlatButton();
            this.toolbarLabel = new RVRMonitor.TransparentClickLabel();
            this.btnMinimize = new RVRMonitor.FlatButton();
            this.btnClose = new RVRMonitor.FlatButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.btnRefreshRVR);
            this.panel1.Controls.Add(this.btnLoadRVR);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(13, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(433, 60);
            this.panel1.TabIndex = 2;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkBox1.Location = new System.Drawing.Point(287, 9);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(125, 21);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Always On Top";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Airport Code";
            // 
            // comboBoxAptList
            // 
            this.comboBoxAptList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.comboBoxAptList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxAptList.ForeColor = System.Drawing.Color.White;
            this.comboBoxAptList.Items.AddRange(new object[] {
            "Select An Airport"});
            this.comboBoxAptList.Location = new System.Drawing.Point(34, 5);
            this.comboBoxAptList.Name = "comboBoxAptList";
            this.comboBoxAptList.Size = new System.Drawing.Size(132, 24);
            this.comboBoxAptList.TabIndex = 0;
            this.comboBoxAptList.Text = "Select An Airport";
            this.comboBoxAptList.SelectedIndexChanged += new System.EventHandler(this.comboBoxAptList_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(13, 138);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(433, 383);
            this.panel2.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnAddRwyCancel);
            this.panel3.Controls.Add(this.btnAddRwyConfirm);
            this.panel3.Controls.Add(this.comboBoxRwyList);
            this.panel3.Controls.Add(this.btnAddRwy);
            this.panel3.Controls.Add(this.comboBoxAptList);
            this.panel3.Location = new System.Drawing.Point(6, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(421, 40);
            this.panel3.TabIndex = 3;
            // 
            // comboBoxRwyList
            // 
            this.comboBoxRwyList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.comboBoxRwyList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxRwyList.ForeColor = System.Drawing.Color.White;
            this.comboBoxRwyList.Items.AddRange(new object[] {
            "Select A Runway"});
            this.comboBoxRwyList.Location = new System.Drawing.Point(172, 5);
            this.comboBoxRwyList.Name = "comboBoxRwyList";
            this.comboBoxRwyList.Size = new System.Drawing.Size(132, 24);
            this.comboBoxRwyList.TabIndex = 3;
            this.comboBoxRwyList.Text = "Select A Runway";
            this.comboBoxRwyList.SelectedIndexChanged += new System.EventHandler(this.comboBoxRwyList_SelectedIndexChanged);
            // 
            // btnAddRwyCancel
            // 
            this.btnAddRwyCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAddRwyCancel.BorderColor = System.Drawing.Color.Gray;
            this.btnAddRwyCancel.Clicked = false;
            this.btnAddRwyCancel.ClickedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(206)))));
            this.btnAddRwyCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddRwyCancel.DisabledTextColor = System.Drawing.Color.DarkGray;
            this.btnAddRwyCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRwyCancel.ForeColor = System.Drawing.Color.White;
            this.btnAddRwyCancel.Location = new System.Drawing.Point(342, 4);
            this.btnAddRwyCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddRwyCancel.Name = "btnAddRwyCancel";
            this.btnAddRwyCancel.Pushed = false;
            this.btnAddRwyCancel.PushedColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnAddRwyCancel.Size = new System.Drawing.Size(23, 25);
            this.btnAddRwyCancel.TabIndex = 5;
            this.btnAddRwyCancel.Text = "X";
            this.btnAddRwyCancel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnAddRwyCancel_Click);
            // 
            // btnAddRwyConfirm
            // 
            this.btnAddRwyConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAddRwyConfirm.BorderColor = System.Drawing.Color.Gray;
            this.btnAddRwyConfirm.Clicked = false;
            this.btnAddRwyConfirm.ClickedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(206)))));
            this.btnAddRwyConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddRwyConfirm.DisabledTextColor = System.Drawing.Color.DarkGray;
            this.btnAddRwyConfirm.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRwyConfirm.ForeColor = System.Drawing.Color.White;
            this.btnAddRwyConfirm.Location = new System.Drawing.Point(311, 4);
            this.btnAddRwyConfirm.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddRwyConfirm.Name = "btnAddRwyConfirm";
            this.btnAddRwyConfirm.Pushed = false;
            this.btnAddRwyConfirm.PushedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(206)))));
            this.btnAddRwyConfirm.Size = new System.Drawing.Size(23, 25);
            this.btnAddRwyConfirm.TabIndex = 4;
            this.btnAddRwyConfirm.Text = "✓";
            this.btnAddRwyConfirm.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnAddRwyConfirm_Click);
            // 
            // btnAddRwy
            // 
            this.btnAddRwy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAddRwy.BorderColor = System.Drawing.Color.Gray;
            this.btnAddRwy.Clicked = false;
            this.btnAddRwy.ClickedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(206)))));
            this.btnAddRwy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddRwy.DisabledTextColor = System.Drawing.Color.DarkGray;
            this.btnAddRwy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddRwy.ForeColor = System.Drawing.Color.White;
            this.btnAddRwy.Location = new System.Drawing.Point(4, 4);
            this.btnAddRwy.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddRwy.Name = "btnAddRwy";
            this.btnAddRwy.Pushed = false;
            this.btnAddRwy.PushedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(206)))));
            this.btnAddRwy.Size = new System.Drawing.Size(23, 25);
            this.btnAddRwy.TabIndex = 2;
            this.btnAddRwy.Text = "+";
            this.btnAddRwy.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnAddRwy_Click);
            // 
            // btnRefreshRVR
            // 
            this.btnRefreshRVR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnRefreshRVR.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnRefreshRVR.Clicked = false;
            this.btnRefreshRVR.ClickedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(206)))));
            this.btnRefreshRVR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshRVR.DisabledTextColor = System.Drawing.Color.DarkGray;
            this.btnRefreshRVR.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshRVR.ForeColor = System.Drawing.Color.White;
            this.btnRefreshRVR.Location = new System.Drawing.Point(287, 33);
            this.btnRefreshRVR.Name = "btnRefreshRVR";
            this.btnRefreshRVR.Pushed = false;
            this.btnRefreshRVR.PushedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(206)))));
            this.btnRefreshRVR.Size = new System.Drawing.Size(140, 25);
            this.btnRefreshRVR.TabIndex = 2;
            this.btnRefreshRVR.Text = "Refresh RVR Data";
            this.btnRefreshRVR.Click += new System.EventHandler(this.btnRefreshRVR_Click);
            // 
            // btnLoadRVR
            // 
            this.btnLoadRVR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnLoadRVR.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnLoadRVR.Clicked = false;
            this.btnLoadRVR.ClickedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(206)))));
            this.btnLoadRVR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoadRVR.DisabledTextColor = System.Drawing.Color.DarkGray;
            this.btnLoadRVR.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadRVR.ForeColor = System.Drawing.Color.White;
            this.btnLoadRVR.Location = new System.Drawing.Point(141, 33);
            this.btnLoadRVR.Name = "btnLoadRVR";
            this.btnLoadRVR.Pushed = false;
            this.btnLoadRVR.PushedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(206)))));
            this.btnLoadRVR.Size = new System.Drawing.Size(140, 25);
            this.btnLoadRVR.TabIndex = 0;
            this.btnLoadRVR.Text = "Load RVR Data";
            this.btnLoadRVR.Click += new System.EventHandler(this.btnLoadRVR_Click);
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(44)))), ((int)(((byte)(46)))));
            this.pnlToolbar.BorderColor = System.Drawing.Color.Transparent;
            this.pnlToolbar.Controls.Add(this.btnInfo);
            this.pnlToolbar.Controls.Add(this.toolbarLabel);
            this.pnlToolbar.Controls.Add(this.btnMinimize);
            this.pnlToolbar.Controls.Add(this.btnClose);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(0, 0);
            this.pnlToolbar.Margin = new System.Windows.Forms.Padding(4);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(457, 64);
            this.pnlToolbar.TabIndex = 1;
            // 
            // btnInfo
            // 
            this.btnInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(206)))));
            this.btnInfo.BorderColor = System.Drawing.Color.Empty;
            this.btnInfo.Clicked = false;
            this.btnInfo.ClickedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(206)))));
            this.btnInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInfo.DisabledTextColor = System.Drawing.Color.DarkGray;
            this.btnInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnInfo.ForeColor = System.Drawing.Color.White;
            this.btnInfo.Location = new System.Drawing.Point(363, 20);
            this.btnInfo.Margin = new System.Windows.Forms.Padding(4);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Pushed = false;
            this.btnInfo.PushedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(206)))));
            this.btnInfo.Size = new System.Drawing.Size(23, 25);
            this.btnInfo.TabIndex = 2;
            this.btnInfo.Text = "?";
            this.btnInfo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.flatButton1_Click);
            // 
            // toolbarLabel
            // 
            this.toolbarLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.toolbarLabel.AutoSize = true;
            this.toolbarLabel.BorderColor = System.Drawing.Color.Empty;
            this.toolbarLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolbarLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.toolbarLabel.HasBorder = false;
            this.toolbarLabel.Location = new System.Drawing.Point(15, 20);
            this.toolbarLabel.Name = "toolbarLabel";
            this.toolbarLabel.Size = new System.Drawing.Size(105, 20);
            this.toolbarLabel.TabIndex = 5;
            this.toolbarLabel.Text = "RVR Monitor";
            this.toolbarLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnMinimize
            // 
            this.btnMinimize.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnMinimize.Clicked = false;
            this.btnMinimize.ClickedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(206)))));
            this.btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimize.DisabledTextColor = System.Drawing.Color.DarkGray;
            this.btnMinimize.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMinimize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnMinimize.Location = new System.Drawing.Point(393, 20);
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(4);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Pushed = false;
            this.btnMinimize.PushedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(206)))));
            this.btnMinimize.Size = new System.Drawing.Size(23, 25);
            this.btnMinimize.TabIndex = 6;
            this.btnMinimize.Text = "–";
            this.btnMinimize.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnMinimize_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(94)))), ((int)(((byte)(57)))));
            this.btnClose.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnClose.Clicked = false;
            this.btnClose.ClickedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(206)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DisabledTextColor = System.Drawing.Color.DarkGray;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(423, 20);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Pushed = false;
            this.btnClose.PushedColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnClose.Size = new System.Drawing.Size(23, 25);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "X";
            this.btnClose.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnClose_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(22)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(457, 533);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlToolbar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private TransparentClickPanel pnlToolbar;
        private FlatButton btnAddRwy;
        private FlatButton btnClose;
        private FlatButton btnMinimize;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboBoxAptList;
        private TransparentClickLabel toolbarLabel;
        private System.Windows.Forms.Label label1;
        private FlatButton btnLoadRVR;
        private FlatButton btnRefreshRVR;
        private System.Windows.Forms.CheckBox checkBox1;
        private FlatButton btnInfo;
        private System.Windows.Forms.Panel panel3;
        private FlatButton btnAddRwyCancel;
        private FlatButton btnAddRwyConfirm;
        private System.Windows.Forms.ComboBox comboBoxRwyList;
    }
}

