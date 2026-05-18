using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Huginn
{
    public static class TokenStorage
    {
        private static readonly string FilePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "Huginn",
            "session.dat"
            );

        public static void SaveToken(string token )
        {
            Directory.CreateDirectory(Path.GetDirectoryName(FilePath));

            byte[] encrypted = ProtectedData.Protect(
                Encoding.UTF8.GetBytes(token),
                null,
                DataProtectionScope.CurrentUser
                );
            File.WriteAllBytes(FilePath, encrypted);
        }
        
        public static string ReadToken()
        {
            if (!File.Exists(FilePath)) return null;
            try
            {
                byte[] encrypted = File.ReadAllBytes(FilePath);
                byte[] decrypted = ProtectedData.Unprotect(encrypted, null, DataProtectionScope.CurrentUser);
                return Encoding.UTF8.GetString(decrypted);
            }
            catch
            { return null; }
        }

        public static void DeleteToken()
        {
            if (File.Exists(FilePath)) File.Delete(FilePath);
        }
    }
}
