using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Huginn
{
    internal static class Program
    {

        [STAThread]
        static void Main()
        {

            string storedToken = TokenStorage.ReadToken();
            bool isLoggedIn = false;
            int userId = 0;

            if (!string.IsNullOrEmpty(storedToken))
            {

                userId = AuthService.ValidateToken(storedToken);
                isLoggedIn = userId > 0;
            }


            if (!isLoggedIn)
            {
                using (var login = new loginForm())
                {
                    if (login.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }
                    userId = login.BrukerId;
                }
            }

            Application.Run(new MainWindow(userId));
        }
    } }
