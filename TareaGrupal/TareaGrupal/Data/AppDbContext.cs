using Microsoft.EntityFrameworkCore;
using TareaGrupal.Models;

namespace TareaGrupal.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<supplier> suppliers { get; set; }

        public DbSet<product> products { get; set; }

        public DbSet<customer> customers { get; set; }

        public DbSet<Ejm> Prueba { get; set; }


    }
}
