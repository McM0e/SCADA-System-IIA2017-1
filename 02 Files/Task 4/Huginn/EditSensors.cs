using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Huginn
{
    public partial class EditSensors : Form
    {
        private AppConfig config;
        private Dictionary<int, string> _dbSensors;
        private string _dbConString;

        public EditSensors()
        {
            InitializeComponent();
            this.Load += editsensor_Load;
            btnSave.Click += btnSave_Click;
        }

        public void editsensor_Load(object sender, EventArgs e)
        {
            config = ConfigManager.Load();

            _dbConString = $"Server={config.dbServer.url};Database={config.dbServer.datebase};User Id={config.dbServer.username};Password={config.dbServer.password};TrustServerCertificate=True;";

            _dbSensors = getDbSensors(_dbConString);

            var combos = new[] { cmbSens1, cmbSens2, cmbSens3, cmbSens4, cmbSens5, cmbSens6, cmbSens7, cmbSens8, cmbSens9 };
            var txtBoxes = new[] { txtNodeId1, txtNodeId2, txtNodeId3, txtNodeId4, txtNodeId5, txtNodeId6, txtNodeId7, txtNodeId8, txtNodeId9 };

            for (int i = 0; i < combos.Length; i++)
            {
                addSensorsToComboBox(combos[i], _dbSensors);

                string configKey = $"sensor{i + 1}";
                if (config.Sensors.TryGetValue(configKey, out var sensorCfg))
                {
                    if (!string.IsNullOrEmpty(sensorCfg.name))
                    {
                        var match = _dbSensors.FirstOrDefault(kvp => kvp.Value == sensorCfg.name);
                        if (match.Value != null)
                            combos[i].SelectedValue = match.Key;
                    }
                    txtBoxes[i].Text = sensorCfg.nodeId;
                }

                var cmb = combos[i];
                var txt = txtBoxes[i];
                cmb.SelectionChangeCommitted += (s, e2) =>
                {
                    int sensorId = (int)cmb.SelectedValue;
                    txt.Text = sensorId == -1 ? "" : getLatestNodeId(sensorId);
                };
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var combos = new[] { cmbSens1, cmbSens2, cmbSens3, cmbSens4, cmbSens5, cmbSens6, cmbSens7, cmbSens8, cmbSens9 };
            var txtBoxes = new[] { txtNodeId1, txtNodeId2, txtNodeId3, txtNodeId4, txtNodeId5, txtNodeId6, txtNodeId7, txtNodeId8, txtNodeId9 };

            for (int i = 0; i < combos.Length; i++)
            {
                string configKey = $"sensor{i + 1}";
                if (!config.Sensors.ContainsKey(configKey))
                    config.Sensors[configKey] = new SensorConfig();

                int selectedId = (int)combos[i].SelectedValue;
                config.Sensors[configKey].name = selectedId == -1 ? "" : _dbSensors[selectedId];
                config.Sensors[configKey].nodeId = txtBoxes[i].Text;
            }

            ConfigManager.Save(config);
        }

        private string getLatestNodeId(int sensorId)
        {
            using (var conn = new SqlConnection(_dbConString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT TOP 1 NodeId FROM measurements WHERE SensorID = @id ORDER BY MeasurementID DESC", conn))
                {
                    cmd.Parameters.AddWithValue("@id", sensorId);
                    var result = cmd.ExecuteScalar();
                    return result?.ToString() ?? "";
                }
            }
        }

        private void addSensorsToComboBox(ComboBox cmb, Dictionary<int, string> sensors)
        {
            var items = new List<KeyValuePair<int, string>> { new KeyValuePair<int, string>(-1, "") };
            items.AddRange(sensors);

            cmb.DataSource = items;
            cmb.DisplayMember = "Value";
            cmb.ValueMember = "Key";
            cmb.SelectedIndex = 0;
        }

        public Dictionary<int, string> getDbSensors(string dbConString)
        {
            var dbSensors = new Dictionary<int, string>();

            using (var conn = new SqlConnection(dbConString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT SensorID, Name FROM Sensors", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        dbSensors.Add(reader.GetInt32(0), reader.GetString(1));
                }
            }

            return dbSensors;
        }
    }
}
