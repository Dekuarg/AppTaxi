using System.ComponentModel.DataAnnotations;

namespace probandoboton.Models
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }

        [RegularExpression(@"\b[A-Z0-9._%-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b")]
        [StringLength(45)]
        public string Email { get; set; }

        public string? Usuario { get; set; }

        public string Clave { get; set; }

        public string? Token { get; set; }
    }

}
