using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Huginn
{
    public partial class EditSensors : Form
    {
        private AppConfig config;
        public EditSensors()
        {
            InitializeComponent();
            
            this.Load += editsensor_Load;
        }

        public void editsensor_Load(object sender, EventArgs e)
        {
            config = ConfigManager.Load();

            string dbConString = $"Server={config.dbServer.url};Database={config.dbServer.datebase};User Id={config.dbServer.username};Password={config.dbServer.password};TrustServerCertificate=True;";
            
        }
    }
}
