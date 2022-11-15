using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace probandoboton.Models
{
    public class ApplicationUser: DbContext
    {
            public ApplicationUser(DbContextOptions<ApplicationUser> options) : base(options)
            {

            }
            public DbSet<User> prueba { get; set; }

    }
    public class UserLogin
    {
        public string Usuario { get; set; }

        public string Clave { get; set; }
        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Usuario) || string.IsNullOrEmpty(Clave))
                return false;

            return true;
        }

    }
    public class UserRegister
    {
        public string Usuario { get; set; }
        [RegularExpression(@"\b[A-Z0-9._%-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b")]
        [StringLength(45)]
        public string Email { get; set; }
        public string Clave { get; set; }

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Usuario)|| string.IsNullOrEmpty(Email)||string.IsNullOrEmpty(Clave))
                return false;

            return true;
        }
    }
}
