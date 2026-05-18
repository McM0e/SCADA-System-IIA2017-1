using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Huginn
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        public int userId { get; private set; }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var (ok, id, token) = AuthService.Login(txtEmail.Text, txtPasswd.Text);

            if (!ok)
            {
                MessageBox.Show("Wrong email or password");
                DialogResult = DialogResult.None;
                return;
            }

            userId = id;
            if (token != null) TokenStorage.SaveToken(token);
            DialogResult = DialogResult.OK;


        }
    }
}
