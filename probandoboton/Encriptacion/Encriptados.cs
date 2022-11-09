using System.Security.Cryptography;
using System.Text;
using probandoboton.Models;
using static probandoboton.Models.ApplicationUser;

namespace probandoboton.Encriptacion
{
    public class Encriptados
    {
        public static string ConvertSha256(string texto)
        {
           
                StringBuilder Sb = new StringBuilder();
                using (SHA256 hash = SHA256.Create())
                {
                    Encoding enc = Encoding.UTF8;
                    byte[] result = hash.ComputeHash(enc.GetBytes(texto));
                    foreach (byte b in result)
                        Sb.Append(b.ToString("x2"));
                }
                return Sb.ToString();
            

        }
    }
}
