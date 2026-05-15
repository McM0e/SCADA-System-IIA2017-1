using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Compilation;
using static Org.BouncyCastle.Math.EC.ECCurve;
using Microsoft.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace Huginn
{

    public enum AlarmSeverity
    {
        Info = 0,
        Warning = 1,
        Critical = 2
    }

    public enum AlarmStatus
    {
        Active = 0,
        Acked = 1,
        Resolved = 2
    }
    public class Alarm
    {
        public int AlarmId { get; set; }
        public string Sensor {  get; set; }
        public double Value { get; set; }
        public AlarmSeverity severity { get; set; }
        public double AlarmLimit { get; set; }
        public string TimestampRaised { get; set; }
        public string AcknowledgedBy { get; set; }
        public string TimestampResolved { get; set; }
        public AlarmStatus Status { get; set; } = AlarmStatus.Active;
    }

    public class AlarmManager
    {
        public List<Alarm> Alarms = new List<Alarm> ();
        public AppConfig config;
        private static readonly object _checkLock = new object();


        

        public void saveAlarm(Alarm alarm)
        {
            config = ConfigManager.Load();
            string ConnectionString = $"Server={config.dbServer.url};Database={config.dbServer.datebase};User Id={config.dbServer.username};Password={config.dbServer.password};TrustServerCertificate=True;";
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();


                int measurementId = getMeasurementId(config, alarm);


                if (measurementId == 0)
                {
                    MessageBox.Show("Failed saving the alarm");
                    return;
                }
                
                using (var cmd = new SqlCommand($"EXEC CreateAlarm {measurementId}, {(int)alarm.severity}, {alarm.AlarmLimit}", conn))
                {
                    cmd.ExecuteNonQuery();

                }

                using (var cmd2 = new SqlCommand($"SELECT AlarmId FROM AlarmId_getter WHERE measurementId={measurementId} AND Severity={(int)alarm.severity} AND Timestamp = '{alarm.TimestampRaised}' AND Value={alarm.Value}", conn))
                {
                    int result = Convert.ToInt32(cmd2.ExecuteScalar());
                    alarm.AlarmId = result;
                }

                conn.Close();

            }
        }

        public void getAlarms()
        {
            config = ConfigManager.Load();
            string ConnectionString = $"Server={config.dbServer.url};Database={config.dbServer.datebase};User Id={config.dbServer.username};Password={config.dbServer.password};TrustServerCertificate=True;";

            this.Alarms.Clear();


            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand("SELECT AlarmId, Sensor, Value, Severity, Limit, Raised, FirstName, TimestampResolved, Status FROM AlarmsExpl", conn))
                using (var reader = cmd.ExecuteReader())
                { 
                    while (reader.Read())
                    {
                        this.Alarms.Add(new Alarm
                        {
                            AlarmId         = reader.GetInt32(0),
                            Sensor          = reader.GetString(1),
                            Value           = reader.GetDouble(2),
                            severity        = (AlarmSeverity)reader.GetInt32(3),
                            AlarmLimit      = reader.GetDouble(4),
                            TimestampRaised = reader.GetDateTime(5).ToString(),
                            AcknowledgedBy = reader.IsDBNull(6) ? "" : reader.GetString(6),
                            TimestampResolved = reader.IsDBNull(7) ? "" : reader.GetDateTime(7).ToString(),
                            Status          = (AlarmStatus)reader.GetInt32(8),
                        });
                    }
                }
            }
        }

        public void AckAlarm(int alarmId, int userid)
        {
            config = ConfigManager.Load();
            string ConnectionString = $"Server={config.dbServer.url};Database={config.dbServer.datebase};User Id={config.dbServer.username};Password={config.dbServer.password};TrustServerCertificate=True;";

            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand($"EXEC AckAlarm {alarmId}, {userid}", conn))
                    cmd.ExecuteNonQuery();
            }
        }

        public void ResolveAlarm(int alarmId)
        {
            config = ConfigManager.Load();
            string ConnectionString = $"Server={config.dbServer.url};Database={config.dbServer.datebase};User Id={config.dbServer.username};Password={config.dbServer.password};TrustServerCertificate=True;";

            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand($"UPDATE Alarms SET Status = 2, TimestampResolved = GETDATE() WHERE AlarmId = {alarmId}", conn))
                    cmd.ExecuteNonQuery();
            }
        }

        public int getMeasurementId(AppConfig config, Alarm alarm)
        {
            string ConnectionString = $"Server={config.dbServer.url};Database={config.dbServer.datebase};User Id={config.dbServer.username};Password={config.dbServer.password};TrustServerCertificate=True;";


            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();


                using (var cmd = new SqlCommand($"SELECT measurementId FROM Alarm_MeasurementId  WHERE Name='{alarm.Sensor}' AND Value={alarm.Value} AND Timestamp='{alarm.TimestampRaised}'", conn))
                {
                    //MessageBox.Show($"SELECT measurementId FROM Alarm_MeasurementId  WHERE Name='{alarm.Sensor}' AND Value={alarm.Value} AND Timestamp='{alarm.TimestampRaised}'");
                    var reader = cmd.ExecuteReader();
                    reader.Read();
                    if (reader == null) return 0;

                    int result = reader.GetInt32(0);
                    return result;
                }
            }
            
        }

        public void CheckLimit(string sensor, double temp, DateTime timestamp)
        {
            //MessageBox.Show(sensor);
            config = ConfigManager.Load();
            string ConnectionString = $"Server={config.dbServer.url};Database={config.dbServer.datebase};User Id={config.dbServer.username};Password={config.dbServer.password};TrustServerCertificate=True;";
            double limit;

            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand($"SELECT AlarmLimit FROM Sensors WHERE Name='{sensor}'", conn))
                    limit = Convert.ToDouble(cmd.ExecuteScalar());

                if (temp < limit) return;
            }

            lock (_checkLock)
            {
                using (var conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    using (var cmd = new SqlCommand($"SELECT COUNT(*) FROM AlarmsExpl WHERE Sensor='{sensor}' AND Status IN (0, 1)", conn))
                    {
                        int existing = Convert.ToInt32(cmd.ExecuteScalar());
                        if (existing > 0) return;
                    }
                }

                var alarm = new Alarm
                {
                    Sensor          = sensor,
                    Value           = temp,
                    severity        = AlarmSeverity.Warning,
                    AlarmLimit      = limit,
                    TimestampRaised = timestamp.ToString("yyyy-MM-dd HH:mm:ss"),
                    Status          = AlarmStatus.Active
                };
                saveAlarm(alarm);
            }
        }
        
    }
}
