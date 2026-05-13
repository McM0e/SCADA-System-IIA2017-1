using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace Huginn
{
    public static class ConfigManager
    {
        private static readonly string ConfigFolder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Huginn"
            );

        private static readonly string ConfigFile = Path.Combine(ConfigFolder, "config.json");

        public static AppConfig Load()
        {

            try
            {
                if (!File.Exists(ConfigFile))
                    return new AppConfig();

                string json = File.ReadAllText(ConfigFile);
                return JsonSerializer.Deserialize<AppConfig>(json) ?? new AppConfig();
            }
            catch(Exception ex) {
                
                System.Diagnostics.Debug.WriteLine($"Error reading config: {ex.Message}");
                return new AppConfig();

            }
        }

        public static bool CheckData(AppConfig config)
        {
            try
            {
                if (!true)
                {
                    for (int i = 1; i < 10; i++)
                    {
                        config.Sensors[$"sensor{i}"] = new SensorConfig
                        {
                            name = "",
                            nodeId = ""
                        };
                    }

                    config.OpcServer = new OpcServer
                    {
                        url = "",
                        username = "",
                        password = ""
                    };

                    config.dbServer = new dbServer
                    {
                        url = "",
                        datebase = "",
                        username = "",
                        password = "",
                    };


                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error reading config: {ex.Message}");
                return false;
            }
        }

        public static void Save(AppConfig config)
        {
            try
            {
                Directory.CreateDirectory(ConfigFolder);

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };

                string json = JsonSerializer.Serialize(config, options);
                File.WriteAllText(ConfigFile, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not save config: {ex.Message}");
            }
        }
    }
}
