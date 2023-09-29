using System.Security.Cryptography;
using System.Text;

namespace SmartAPI.Util {
    public static class Encrypt {
        public static string GenerateHash(string Pwd) 
        {
            return BCrypt.Net.BCrypt.HashPassword(Pwd);
        }

        public static bool ComparePassword(string password, string hash) {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}
