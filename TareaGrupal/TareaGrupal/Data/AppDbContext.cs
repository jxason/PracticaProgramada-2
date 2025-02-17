using Microsoft.EntityFrameworkCore;
using TareaGrupal.Models;

namespace TareaGrupal.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<Product> products { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Supplier> suppliers { get; set; }




    }
}