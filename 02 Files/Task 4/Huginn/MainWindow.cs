using LiveCharts.WinForms;
using Opc.UaFx;
using Opc.UaFx.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Org.BouncyCastle.Math.EC.ECCurve;


namespace Huginn
{
    public partial class MainWindow : Form
    {
        private AppConfig config;
        private int userId;
        private string _currentUserName;
        private AlarmManager _alarmManager;
        private OpcClient client;
        public MainWindow(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            this.Load += MainWindow_Load;

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            
            config = ConfigManager.Load();
            var user = AuthService.GetUserInfo(userId);

            bool test = ConfigManager.CheckData(config);

            if (test) ConfigManager.Save(config);

            _currentUserName = $"{user.firstname} {user.lastname}";

            _alarmManager = new AlarmManager();
            _alarmManager.getAlarms();

            dgvAlarms.DataSource = _alarmManager.Alarms
                .Where(a => a.Status != AlarmStatus.Resolved)
                .ToList();

            dgvAlarms.ReadOnly = true;
            dgvAlarms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAlarms.MultiSelect = false;
            dgvAlarms.AllowUserToAddRows = false;
            dgvAlarms.AllowUserToDeleteRows = false;
            dgvAlarms.RowHeadersVisible = false;

            ConfigureAlarmGrid();

            initGauges();


            lblName.Text = $"{user.firstname} {user.lastname}";
            lblRole.Text = $"{user.role}";

            

            if (user.role == "Admin")
            {
                lnkAdminMenu.Visible = true ;
            } else {  lnkAdminMenu.Visible = false ;}

        }

        private void ConfigureAlarmGrid()
        {
            dgvAlarms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            var cols = dgvAlarms.Columns;
            cols["AlarmId"].HeaderText            = "ID";
            cols["AlarmId"].FillWeight            = 30;
            cols["Sensor"].HeaderText             = "Sensor";
            cols["Sensor"].FillWeight             = 90;
            cols["Value"].HeaderText              = "Value";
            cols["Value"].FillWeight              = 50;
            cols["severity"].HeaderText           = "Severity";
            cols["severity"].FillWeight           = 70;
            cols["AlarmLimit"].HeaderText         = "Limit";
            cols["AlarmLimit"].FillWeight         = 50;
            cols["TimestampRaised"].HeaderText    = "Raised";
            cols["TimestampRaised"].FillWeight    = 120;
            cols["AcknowledgedBy"].HeaderText     = "Acked By";
            cols["AcknowledgedBy"].FillWeight     = 80;
            cols["TimestampResolved"].HeaderText  = "Acknowledged";
            cols["TimestampResolved"].FillWeight  = 120;
            cols["Status"].HeaderText             = "Status";
            cols["Status"].FillWeight             = 60;

            var btnCol = new DataGridViewButtonColumn();
            btnCol.Name        = "ActionButton";
            btnCol.HeaderText  = "";
            btnCol.FillWeight  = 60;
            btnCol.UseColumnTextForButtonValue = false;
            dgvAlarms.Columns.Add(btnCol);

            dgvAlarms.CellFormatting += (s, e) =>
            {
                if (e.ColumnIndex != dgvAlarms.Columns["ActionButton"].Index || e.RowIndex < 0) return;
                var status = (AlarmStatus)dgvAlarms.Rows[e.RowIndex].Cells["Status"].Value;
                e.Value = status == AlarmStatus.Active ? "Ack" : "Resolve";
            };

            dgvAlarms.CellContentClick += dgvAlarms_ActionButtonClick;
        }

        private void dgvAlarms_ActionButtonClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != dgvAlarms.Columns["ActionButton"].Index || e.RowIndex < 0) return;

            int alarmId = (int)dgvAlarms.Rows[e.RowIndex].Cells["AlarmId"].Value;
            var status  = (AlarmStatus)dgvAlarms.Rows[e.RowIndex].Cells["Status"].Value;

            if (status == AlarmStatus.Active)
                _alarmManager.AckAlarm(alarmId, userId);
            else if (status == AlarmStatus.Acked)
                _alarmManager.ResolveAlarm(alarmId);

            RefreshAlarmGrid();
        }

        private void RefreshAlarmGrid()
        {
            _alarmManager.getAlarms();
            dgvAlarms.DataSource = _alarmManager.Alarms
                .Where(a => a.Status != AlarmStatus.Resolved)
                .ToList();
        }

        private void initGauges()
        {

            string url = config.OpcServer.url;

            client = new OpcClient(url);

            client.Security.UserIdentity = new OpcClientIdentity(config.OpcServer.username, config.OpcServer.password);

            client.Connect();

            setGauges();
        
        }

        private void setGauges()
        {
            foreach (var Sensor in config.Sensors)
            {
                if (Sensor.Value.name != "")
                {
                    
                    string number = Sensor.Key.Replace("sensor", "");

                    var gauge = this.Controls.Find($"gauAlarm{number}", true).FirstOrDefault() as SolidGauge;
                    var label = this.Controls.Find($"lblAlarm{number}", true).FirstOrDefault() as Label;

                    if (gauge != null && label != null)
                    {
                        OpcSub(Sensor.Value.name, Sensor.Value.nodeId, gauge, label);

                    }
                }
                else
                {
                    string number = Sensor.Key.Replace("sensor", "");
                    var gauge = this.Controls.Find($"gauAlarm{number}", true).FirstOrDefault() as SolidGauge;
                    var label = this.Controls.Find($"lblAlarm{number}", true).FirstOrDefault() as Label;
                    gauge.Visible = false;
                    label.Visible = false;
                }
            }
        }

        private void lnkLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string token = TokenStorage.ReadToken();
            if (token != null) AuthService.Logout(token);
            TokenStorage.DeleteToken();
            Application.Restart();
        }

        private void OpcSub(string sensorName, string tagName, SolidGauge gauge, Label label)
        {
            try
            {
                var tag = tagName;

                SetGauge(gauge, label, sensorName);

                client.SubscribeDataChange(tag, (s, e) => tempChange(s, e, gauge, label));

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ocured while connecting");
            }

        }

        private void tempChange(object sender, OpcDataChangeReceivedEventArgs e, SolidGauge gauge, Label label)
        {
            double temperature = e.Item.Value.As<double>();
            DateTime timestamp = (e.Item.Value.SourceTimestamp ?? DateTime.UtcNow).ToLocalTime();
            string sensorName = label.Text;

            Task.Run(() => _alarmManager.CheckLimit(sensorName, Math.Round(temperature, 2), timestamp));
            RefreshAlarmGrid();

            Invoke(new Action(() =>
            {
                updateGauge(gauge, temperature);
            }));
        }

        private void SetGauge(SolidGauge gauge, Label label, string sensorName)
        {

            gauge.Visible = true;
            gauge.To = 100;
            
            label.Visible = true;
            label.Text = sensorName;
        }

        private void updateGauge(SolidGauge gauge, double value)
        {
            gauge.Value = Math.Round(value, 2);
        }

        private void btnSensorSettings_Click(object sender, EventArgs e)
        {
            EditSensors editSensorPage = new EditSensors();
            DialogResult result = editSensorPage.ShowDialog();

            if (result == DialogResult.OK)
            {
                config = ConfigManager.Load();
                setGauges();
                
            }
            
        }
    }
}
