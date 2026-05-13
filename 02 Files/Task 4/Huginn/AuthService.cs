using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using BCrypt.Net;
using System.Windows.Forms;

namespace Huginn
{
    public static class AuthService
    {
        private const string ConnectionString = "Server=10.0.0.150,1433;Database=SCADAAssignement;User Id=sa;Password=***;TrustServerCertificate=True;";

        public static (bool ok, int brukerId, string token) Login(string email, string password)
        {
            var conn = new SqlConnection(ConnectionString);
            conn.Open();

            var cmd = new SqlCommand(
                "SELECT UserId, Password, Salt FROM Users WHERE email = @u", conn);
            cmd.Parameters.AddWithValue("@u", email);

            var reader = cmd.ExecuteReader();
            if (!reader.Read()) return (false, 0, null);


            int id = reader.GetInt32(0);
            string hash = reader.GetString(1);
            string  salt = reader.GetString(2);
            reader.Close();

            bool PasswdOK = BCrypt.Net.BCrypt.Verify(password, hash);

            if (!PasswdOK)
            { return (false, 0, null); }

            string token = Guid.NewGuid().ToString("N") + Guid.NewGuid().ToString("N");
            DateTime utloper = DateTime.UtcNow.AddDays(30);

            var insert = new SqlCommand(
            "INSERT INTO Sessions (Token, UserId, ExpiresAt) VALUES (@t, @id, @e)", conn);
            insert.Parameters.AddWithValue("@t", token);
            insert.Parameters.AddWithValue("@id", id);
            insert.Parameters.AddWithValue("@e", utloper);
            insert.ExecuteNonQuery();

            return (true, id, token);

        }

        public static int ValidateToken(string Token)
        {
            var conn = new SqlConnection(ConnectionString);
            conn.Open();

            var cmd = new SqlCommand(
                "SELECT UserId FROM Sessions WHERE Token = @t AND ExpiresAt > @now", conn);
            cmd.Parameters.AddWithValue("@t", Token);
            cmd.Parameters.AddWithValue("@now", DateTime.UtcNow);

            var result = cmd.ExecuteScalar();
            return result != null ? (int)result : 0;
        }

        public static void Logout(string token)
        {
            var conn = new SqlConnection(ConnectionString);
            conn.Open();
            var cmd = new SqlCommand("DELETE FROM Sessions WHERE Token = @t", conn);
            cmd.Parameters.AddWithValue("@t", token);
            cmd.ExecuteNonQuery();
        }

        public static (string firstname, string lastname, string email, string role) GetUserInfo(int userId)
        {

            var fname = "";
            var lname = "";
            var email = "";
            int roleid = 0;
            var role = "";


            var conn = new SqlConnection(ConnectionString);
            conn.Open();

            var cmd = new SqlCommand(
                "SELECT FirstName, LastName, Email, Role FROM Users WHERE UserId = @id", conn);
            cmd.Parameters.AddWithValue("@id", userId);

            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                fname = reader.GetString(0);
                lname = reader.GetString(1);
                email = reader.GetString(2);
                roleid = reader.GetInt32(3);
               
            }

            reader.Close();

            cmd = new SqlCommand(
                "SELECT Name Role FROM UserRoles WHERE RoleId = @id", conn);
            cmd.Parameters.AddWithValue("@id", roleid);

            reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                role = reader.GetString(0);
            }

            reader.Close();

            if (fname != "")
            {
                return 
                    (
                    fname,
                    lname,
                    email,
                    role
                    );
            }

                return ("", "", "", "");
        }
    }
}
