using System.Security.Cryptography;
using System.Text;
using probandoboton.Models;
using static probandoboton.Models.ApplicationUser;

namespace probandoboton.Encriptacion
{
    public class Encriptados
    {
        //public static string ConvertSha256(string texto)
        //{

        //        StringBuilder Sb = new StringBuilder();
        //        using (SHA256 hash = SHA256.Create())
        //        {
        //            Encoding enc = Encoding.UTF8;
        //            byte[] result = hash.ComputeHash(enc.GetBytes(texto));
        //            foreach (byte b in result)
        //                Sb.Append(b.ToString("x2"));
        //        }
        //        return Sb.ToString();


        //}
         
        // Metodo que se utiliza para encriptar la contraseña 
        // el metodo de arriba genera encriptaciones diferentes para computadora no usar hasta encontrar una semilla util
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
