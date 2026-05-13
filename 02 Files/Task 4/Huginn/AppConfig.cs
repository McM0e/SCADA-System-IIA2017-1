using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Huginn
{

    public class SensorConfig
    {
        [JsonPropertyName("name")]
        public string name { get; set; } = "";
        [JsonPropertyName("nodeId")]
        public string nodeId { get; set; } = "";
    }

    public class OpcServer
    {
        [JsonPropertyName("url")]
        public string url { get; set; } = "";

        [JsonPropertyName("username")]
        public string username { get; set; } = "";

        [JsonPropertyName("Password")]
        public string password { get; set; } = "";
    }

    public class dbServer
    {
        [JsonPropertyName("url")]
        public string url { get; set; } = "";
        [JsonPropertyName("database")]
        public string datebase { get; set; } = "";
        [JsonPropertyName("username")]
        public string username { get; set; } = "";
        [JsonPropertyName("password")]
        public string password { get; set; } = "";
    }
    public class AppConfig
    {
        [JsonPropertyName("sensors")]
        public Dictionary<string, SensorConfig> Sensors { get; set; } = new Dictionary<string, SensorConfig>();

        [JsonPropertyName("opcServer")]
        public OpcServer OpcServer { get; set; } = new OpcServer();

        [JsonPropertyName("dbServer")]
        public dbServer dbServer { get; set; } = new dbServer();


        public List<string> RecentFiles { get; set; } = new List<string>();
    }
}
