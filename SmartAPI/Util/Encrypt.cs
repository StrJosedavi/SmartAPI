using System.Security.Cryptography;
using System.Text;

namespace SmartAPI.Util {
    public static class Encrypt {
        public static string GenerateHash(string Pwd) 
        {
            var encodPass = Encoding.UTF8.GetBytes(Pwd);
            int salt = new Random().Next(9000, 99999999);
            byte[] saltBytes = Encoding.ASCII.GetBytes(salt.ToString());
            var hmacSHA512 = new HMACSHA512(saltBytes);
            byte[] saltedHash = hmacSHA512.ComputeHash(encodPass);

            return Convert.ToBase64String(saltedHash);
        }
    }
}
