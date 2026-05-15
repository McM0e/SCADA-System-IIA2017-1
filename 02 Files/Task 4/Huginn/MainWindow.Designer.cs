using System;
using System.Windows.Forms;


namespace Huginn
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.lblTitle = new System.Windows.Forms.Label();
            this.lnkAdminMenu = new System.Windows.Forms.LinkLabel();
            this.lnkLogout = new System.Windows.Forms.LinkLabel();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gauAlarm1 = new LiveCharts.WinForms.SolidGauge();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblSensors = new System.Windows.Forms.Label();
            this.gauAlarm9 = new LiveCharts.WinForms.SolidGauge();
            this.gauAlarm8 = new LiveCharts.WinForms.SolidGauge();
            this.gauAlarm7 = new LiveCharts.WinForms.SolidGauge();
            this.gauAlarm6 = new LiveCharts.WinForms.SolidGauge();
            this.gauAlarm5 = new LiveCharts.WinForms.SolidGauge();
            this.gauAlarm4 = new LiveCharts.WinForms.SolidGauge();
            this.gauAlarm3 = new LiveCharts.WinForms.SolidGauge();
            this.gauAlarm2 = new LiveCharts.WinForms.SolidGauge();
            this.lblAlarm9 = new System.Windows.Forms.Label();
            this.lblAlarm8 = new System.Windows.Forms.Label();
            this.lblAlarm7 = new System.Windows.Forms.Label();
            this.lblAlarm6 = new System.Windows.Forms.Label();
            this.lblAlarm5 = new System.Windows.Forms.Label();
            this.lblAlarm4 = new System.Windows.Forms.Label();
            this.lblAlarm3 = new System.Windows.Forms.Label();
            this.lblAlarm2 = new System.Windows.Forms.Label();
            this.lblAlarm1 = new System.Windows.Forms.Label();
            this.btnSensorSettings = new System.Windows.Forms.Button();
            this.dgvAlarms = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblAlarms = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlarms)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(706, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(183, 55);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Huginn";
            // 
            // lnkAdminMenu
            // 
            this.lnkAdminMenu.AutoSize = true;
            this.lnkAdminMenu.Location = new System.Drawing.Point(165, 55);
            this.lnkAdminMenu.Name = "lnkAdminMenu";
            this.lnkAdminMenu.Size = new System.Drawing.Size(66, 13);
            this.lnkAdminMenu.TabIndex = 9;
            this.lnkAdminMenu.TabStop = true;
            this.lnkAdminMenu.Text = "Admin Menu";
            this.lnkAdminMenu.Visible = false;
            // 
            // lnkLogout
            // 
            this.lnkLogout.AutoSize = true;
            this.lnkLogout.Location = new System.Drawing.Point(191, 9);
            this.lnkLogout.Name = "lnkLogout";
            this.lnkLogout.Size = new System.Drawing.Size(40, 13);
            this.lnkLogout.TabIndex = 8;
            this.lnkLogout.TabStop = true;
            this.lnkLogout.Text = "Logout";
            this.lnkLogout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLogout_LinkClicked);
            // 
            // lblRole
            // 
            this.lblRole.Location = new System.Drawing.Point(4, 39);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(97, 13);
            this.lblRole.TabIndex = 7;
            this.lblRole.Text = "PlaceHolder";
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(3, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(187, 23);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "Placeholder";
            this.lblName.Enter += new System.EventHandler(this.MainWindow_Load);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 95);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gauAlarm1);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.gauAlarm9);
            this.splitContainer1.Panel1.Controls.Add(this.gauAlarm8);
            this.splitContainer1.Panel1.Controls.Add(this.gauAlarm7);
            this.splitContainer1.Panel1.Controls.Add(this.gauAlarm6);
            this.splitContainer1.Panel1.Controls.Add(this.gauAlarm5);
            this.splitContainer1.Panel1.Controls.Add(this.gauAlarm4);
            this.splitContainer1.Panel1.Controls.Add(this.gauAlarm3);
            this.splitContainer1.Panel1.Controls.Add(this.gauAlarm2);
            this.splitContainer1.Panel1.Controls.Add(this.lblAlarm9);
            this.splitContainer1.Panel1.Controls.Add(this.lblAlarm8);
            this.splitContainer1.Panel1.Controls.Add(this.lblAlarm7);
            this.splitContainer1.Panel1.Controls.Add(this.lblAlarm6);
            this.splitContainer1.Panel1.Controls.Add(this.lblAlarm5);
            this.splitContainer1.Panel1.Controls.Add(this.lblAlarm4);
            this.splitContainer1.Panel1.Controls.Add(this.lblAlarm3);
            this.splitContainer1.Panel1.Controls.Add(this.lblAlarm2);
            this.splitContainer1.Panel1.Controls.Add(this.lblAlarm1);
            this.splitContainer1.Panel1.Controls.Add(this.btnSensorSettings);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvAlarms);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(1695, 676);
            this.splitContainer1.SplitterDistance = 619;
            this.splitContainer1.TabIndex = 6;
            // 
            // gauAlarm1
            // 
            this.gauAlarm1.Location = new System.Drawing.Point(3, 89);
            this.gauAlarm1.Name = "gauAlarm1";
            this.gauAlarm1.Size = new System.Drawing.Size(200, 100);
            this.gauAlarm1.TabIndex = 40;
            this.gauAlarm1.Tag = "";
            this.gauAlarm1.Text = "a";
            this.gauAlarm1.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblSensors);
            this.groupBox1.Location = new System.Drawing.Point(0, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(615, 79);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            // 
            // lblSensors
            // 
            this.lblSensors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSensors.AutoSize = true;
            this.lblSensors.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSensors.Location = new System.Drawing.Point(231, 20);
            this.lblSensors.Name = "lblSensors";
            this.lblSensors.Size = new System.Drawing.Size(152, 39);
            this.lblSensors.TabIndex = 11;
            this.lblSensors.Text = "Sensors";
            this.lblSensors.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gauAlarm9
            // 
            this.gauAlarm9.Location = new System.Drawing.Point(415, 488);
            this.gauAlarm9.Name = "gauAlarm9";
            this.gauAlarm9.Size = new System.Drawing.Size(200, 100);
            this.gauAlarm9.TabIndex = 37;
            this.gauAlarm9.Tag = "";
            this.gauAlarm9.Text = "solidGauge1";
            this.gauAlarm9.Visible = false;
            // 
            // gauAlarm8
            // 
            this.gauAlarm8.Location = new System.Drawing.Point(209, 488);
            this.gauAlarm8.Name = "gauAlarm8";
            this.gauAlarm8.Size = new System.Drawing.Size(200, 100);
            this.gauAlarm8.TabIndex = 36;
            this.gauAlarm8.Tag = "";
            this.gauAlarm8.Text = "solidGauge1";
            this.gauAlarm8.Visible = false;
            // 
            // gauAlarm7
            // 
            this.gauAlarm7.Location = new System.Drawing.Point(3, 488);
            this.gauAlarm7.Name = "gauAlarm7";
            this.gauAlarm7.Size = new System.Drawing.Size(200, 100);
            this.gauAlarm7.TabIndex = 35;
            this.gauAlarm7.Tag = "";
            this.gauAlarm7.Text = "solidGauge1";
            this.gauAlarm7.Visible = false;
            // 
            // gauAlarm6
            // 
            this.gauAlarm6.Location = new System.Drawing.Point(415, 298);
            this.gauAlarm6.Name = "gauAlarm6";
            this.gauAlarm6.Size = new System.Drawing.Size(200, 100);
            this.gauAlarm6.TabIndex = 34;
            this.gauAlarm6.Tag = "";
            this.gauAlarm6.Text = "solidGauge1";
            this.gauAlarm6.Visible = false;
            // 
            // gauAlarm5
            // 
            this.gauAlarm5.Location = new System.Drawing.Point(209, 298);
            this.gauAlarm5.Name = "gauAlarm5";
            this.gauAlarm5.Size = new System.Drawing.Size(200, 100);
            this.gauAlarm5.TabIndex = 33;
            this.gauAlarm5.Tag = "";
            this.gauAlarm5.Text = "solidGauge1";
            this.gauAlarm5.Visible = false;
            // 
            // gauAlarm4
            // 
            this.gauAlarm4.Location = new System.Drawing.Point(3, 298);
            this.gauAlarm4.Name = "gauAlarm4";
            this.gauAlarm4.Size = new System.Drawing.Size(200, 100);
            this.gauAlarm4.TabIndex = 32;
            this.gauAlarm4.Tag = "";
            this.gauAlarm4.Text = "solidGauge1";
            this.gauAlarm4.Visible = false;
            // 
            // gauAlarm3
            // 
            this.gauAlarm3.Location = new System.Drawing.Point(415, 89);
            this.gauAlarm3.Name = "gauAlarm3";
            this.gauAlarm3.Size = new System.Drawing.Size(200, 100);
            this.gauAlarm3.TabIndex = 31;
            this.gauAlarm3.Tag = "";
            this.gauAlarm3.Text = "solidGauge1";
            this.gauAlarm3.Visible = false;
            // 
            // gauAlarm2
            // 
            this.gauAlarm2.Location = new System.Drawing.Point(209, 89);
            this.gauAlarm2.Name = "gauAlarm2";
            this.gauAlarm2.Size = new System.Drawing.Size(200, 100);
            this.gauAlarm2.TabIndex = 30;
            this.gauAlarm2.Tag = "";
            this.gauAlarm2.Text = "solidGauge1";
            this.gauAlarm2.Visible = false;
            // 
            // lblAlarm9
            // 
            this.lblAlarm9.AutoSize = true;
            this.lblAlarm9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlarm9.Location = new System.Drawing.Point(483, 591);
            this.lblAlarm9.Name = "lblAlarm9";
            this.lblAlarm9.Size = new System.Drawing.Size(63, 20);
            this.lblAlarm9.TabIndex = 29;
            this.lblAlarm9.Text = "Alarm 9";
            this.lblAlarm9.Visible = false;
            // 
            // lblAlarm8
            // 
            this.lblAlarm8.AutoSize = true;
            this.lblAlarm8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlarm8.Location = new System.Drawing.Point(278, 591);
            this.lblAlarm8.Name = "lblAlarm8";
            this.lblAlarm8.Size = new System.Drawing.Size(63, 20);
            this.lblAlarm8.TabIndex = 28;
            this.lblAlarm8.Text = "Alarm 8";
            this.lblAlarm8.Visible = false;
            // 
            // lblAlarm7
            // 
            this.lblAlarm7.AutoSize = true;
            this.lblAlarm7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlarm7.Location = new System.Drawing.Point(71, 591);
            this.lblAlarm7.Name = "lblAlarm7";
            this.lblAlarm7.Size = new System.Drawing.Size(63, 20);
            this.lblAlarm7.TabIndex = 27;
            this.lblAlarm7.Text = "Alarm 7";
            this.lblAlarm7.Visible = false;
            // 
            // lblAlarm6
            // 
            this.lblAlarm6.AutoSize = true;
            this.lblAlarm6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlarm6.Location = new System.Drawing.Point(483, 401);
            this.lblAlarm6.Name = "lblAlarm6";
            this.lblAlarm6.Size = new System.Drawing.Size(63, 20);
            this.lblAlarm6.TabIndex = 26;
            this.lblAlarm6.Text = "Alarm 6";
            this.lblAlarm6.Visible = false;
            // 
            // lblAlarm5
            // 
            this.lblAlarm5.AutoSize = true;
            this.lblAlarm5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlarm5.Location = new System.Drawing.Point(278, 401);
            this.lblAlarm5.Name = "lblAlarm5";
            this.lblAlarm5.Size = new System.Drawing.Size(63, 20);
            this.lblAlarm5.TabIndex = 25;
            this.lblAlarm5.Text = "Alarm 5";
            this.lblAlarm5.Visible = false;
            // 
            // lblAlarm4
            // 
            this.lblAlarm4.AutoSize = true;
            this.lblAlarm4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlarm4.Location = new System.Drawing.Point(71, 401);
            this.lblAlarm4.Name = "lblAlarm4";
            this.lblAlarm4.Size = new System.Drawing.Size(63, 20);
            this.lblAlarm4.TabIndex = 24;
            this.lblAlarm4.Text = "Alarm 4";
            this.lblAlarm4.Visible = false;
            // 
            // lblAlarm3
            // 
            this.lblAlarm3.AutoSize = true;
            this.lblAlarm3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlarm3.Location = new System.Drawing.Point(483, 192);
            this.lblAlarm3.Name = "lblAlarm3";
            this.lblAlarm3.Size = new System.Drawing.Size(63, 20);
            this.lblAlarm3.TabIndex = 23;
            this.lblAlarm3.Text = "Alarm 3";
            this.lblAlarm3.Visible = false;
            // 
            // lblAlarm2
            // 
            this.lblAlarm2.AutoSize = true;
            this.lblAlarm2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlarm2.Location = new System.Drawing.Point(278, 192);
            this.lblAlarm2.Name = "lblAlarm2";
            this.lblAlarm2.Size = new System.Drawing.Size(63, 20);
            this.lblAlarm2.TabIndex = 22;
            this.lblAlarm2.Text = "Alarm 2";
            this.lblAlarm2.Visible = false;
            // 
            // lblAlarm1
            // 
            this.lblAlarm1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAlarm1.AutoSize = true;
            this.lblAlarm1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlarm1.Location = new System.Drawing.Point(71, 192);
            this.lblAlarm1.Name = "lblAlarm1";
            this.lblAlarm1.Size = new System.Drawing.Size(63, 20);
            this.lblAlarm1.TabIndex = 21;
            this.lblAlarm1.Text = "Alarm 1";
            this.lblAlarm1.Visible = false;
            // 
            // btnSensorSettings
            // 
            this.btnSensorSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSensorSettings.Location = new System.Drawing.Point(462, 623);
            this.btnSensorSettings.Name = "btnSensorSettings";
            this.btnSensorSettings.Size = new System.Drawing.Size(154, 50);
            this.btnSensorSettings.TabIndex = 12;
            this.btnSensorSettings.Text = "Edit Sensors";
            this.btnSensorSettings.UseVisualStyleBackColor = true;
            this.btnSensorSettings.Click += new System.EventHandler(this.btnSensorSettings_Click);
            // 
            // dgvAlarms
            // 
            this.dgvAlarms.AllowUserToAddRows = false;
            this.dgvAlarms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlarms.Location = new System.Drawing.Point(3, 89);
            this.dgvAlarms.Name = "dgvAlarms";
            this.dgvAlarms.Size = new System.Drawing.Size(1065, 583);
            this.dgvAlarms.TabIndex = 40;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblAlarms);
            this.groupBox2.Location = new System.Drawing.Point(3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1066, 79);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            // 
            // lblAlarms
            // 
            this.lblAlarms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAlarms.AutoSize = true;
            this.lblAlarms.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlarms.Location = new System.Drawing.Point(467, 20);
            this.lblAlarms.Name = "lblAlarms";
            this.lblAlarms.Size = new System.Drawing.Size(133, 39);
            this.lblAlarms.TabIndex = 12;
            this.lblAlarms.Text = "Alarms";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.lnkAdminMenu);
            this.panel1.Controls.Add(this.lnkLogout);
            this.panel1.Controls.Add(this.lblRole);
            this.panel1.Location = new System.Drawing.Point(1473, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(234, 77);
            this.panel1.TabIndex = 10;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1724, 800);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.lblTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(1740, 839);
            this.MinimumSize = new System.Drawing.Size(1740, 839);
            this.Name = "MainWindow";
            this.Text = "Huginn";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlarms)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblTitle;
        private Label lblRole;
        private Label lblName;
        private SplitContainer splitContainer1;
        private LinkLabel lnkLogout;
        private LinkLabel lnkAdminMenu;
        private Panel panel1;
        private Label lblSensors;
        private Label lblAlarms;
        private Button btnSensorSettings;
        private Label lblAlarm9;
        private Label lblAlarm8;
        private Label lblAlarm7;
        private Label lblAlarm6;
        private Label lblAlarm5;
        private Label lblAlarm4;
        private Label lblAlarm3;
        private Label lblAlarm2;
        private Label lblAlarm1;
        private LiveCharts.WinForms.SolidGauge gauAlarm9;
        private LiveCharts.WinForms.SolidGauge gauAlarm8;
        private LiveCharts.WinForms.SolidGauge gauAlarm7;
        private LiveCharts.WinForms.SolidGauge gauAlarm6;
        private LiveCharts.WinForms.SolidGauge gauAlarm5;
        private LiveCharts.WinForms.SolidGauge gauAlarm4;
        private LiveCharts.WinForms.SolidGauge gauAlarm3;
        private LiveCharts.WinForms.SolidGauge gauAlarm2;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private DataGridView dgvAlarms;
        private LiveCharts.WinForms.SolidGauge gauAlarm1;
    }
}

