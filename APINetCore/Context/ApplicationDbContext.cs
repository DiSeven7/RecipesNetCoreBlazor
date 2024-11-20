using Microsoft.EntityFrameworkCore;
using PruebasAPIBlazor.Helpers;
using PruebasAPIBlazor.Models;

namespace PruebasAPIBlazor.Context
{
    public class ApplicationDbContext : DbContext
    {
        private IConfigurationManager Config { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Receta> Recetas { get; set; }
    }
}
