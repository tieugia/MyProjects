using System.Security.Cryptography;
using System.Text;

namespace WebApp
{
    public static class Helper
    {
        public static string RandomString(int len)
        {
            char[] chars = new char[len];
            string pattern = "qwertyuiopasdfghjklzxcvbnm1234567890";
            Random random = new Random();
            for (int i = 0; i < len; i++)
            {
                chars[i] = pattern[random.Next(pattern.Length)];
            }
            return string.Join("", chars);
        }
        public static byte[] Hash(string plantext)
        {
            HashAlgorithm hashAlgorithm = HashAlgorithm.Create("SHA-512");
            return hashAlgorithm.ComputeHash(Encoding.ASCII.GetBytes(plantext));
        }
    }
}
