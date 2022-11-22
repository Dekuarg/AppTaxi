using System.Security.Cryptography;
using System.Text;
using probandoboton.Models;
using static probandoboton.Models.ApplicationUser;

namespace probandoboton.Encriptacion
{
    public class Encriptados
    {
        public static String ConvertMD5(String texto)
        {
            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(texto);
            bs = x.ComputeHash(bs);
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            String hash = s.ToString();
            return hash;
        }
    }
}
