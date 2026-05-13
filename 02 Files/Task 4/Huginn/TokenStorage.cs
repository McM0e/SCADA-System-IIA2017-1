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

            byte[] kryptert = ProtectedData.Protect(
                Encoding.UTF8.GetBytes(token),
                null,
                DataProtectionScope.CurrentUser
                );
            File.WriteAllBytes(FilePath, kryptert);
        }
        
        public static string ReadToken()
        {
            if (!File.Exists(FilePath)) return null;
            try
            {
                byte[] kryptert = File.ReadAllBytes(FilePath);
                byte[] dekryptert = ProtectedData.Unprotect(kryptert, null, DataProtectionScope.CurrentUser);
                return Encoding.UTF8.GetString(dekryptert);
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
