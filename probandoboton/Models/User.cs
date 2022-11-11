using System.ComponentModel.DataAnnotations;

namespace probandoboton.Models
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }
        public string Email { get; set; }

        public string Usuario { get; set; }

        public string Clave { get; set; }

        public string Token { get; set; }
    }

}
