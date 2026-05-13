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


namespace Huginn
{
    public partial class MainWindow : Form
    {
        private AppConfig config;
        private int userId;
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

            initGauges();


            lblName.Text = $"{user.firstname} {user.lastname}";
            lblRole.Text = $"{user.role}";

            

            if (user.role == "Admin")
            {
                lnkAdminMenu.Visible = true ;
            } else {  lnkAdminMenu.Visible = false ;}

        }

        private void initGauges()
        {

            string url = config.OpcServer.url;

            client = new OpcClient(url);

            client.Security.UserIdentity = new OpcClientIdentity(config.OpcServer.username, config.OpcServer.password);

            client.Connect();

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

                client.SubscribeDataChange(tag, (s, e) => tempChange(s, e, gauge));

            }
            catch (Exception ex)
            {
                MessageBox.Show("Feil ved tilkobling");
            }

        }

        private void tempChange(object sender, OpcDataChangeReceivedEventArgs e, SolidGauge gauge)
        {

            double temperature = e.Item.Value.As<double>();
            DateTime timestamp = e.Item.Value.SourceTimestamp ?? DateTime.Now;

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
    }
}
