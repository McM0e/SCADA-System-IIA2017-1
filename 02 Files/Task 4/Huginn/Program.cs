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

            string lagretToken = TokenStorage.ReadToken();
            bool erInnlogget = false;
            int userId = 0;

            if (!string.IsNullOrEmpty(lagretToken))
            {

                userId = AuthService.ValidateToken(lagretToken);
                erInnlogget = userId > 0;
            }


            if (!erInnlogget)
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

            // Start hovedvinduet
            Application.Run(new MainWindow(userId));
        }
    } }
