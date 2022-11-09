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
    public class UserEntity
    {

        public string Usuario { get; set; }

        public string Clave { get; set; }

    }
}
