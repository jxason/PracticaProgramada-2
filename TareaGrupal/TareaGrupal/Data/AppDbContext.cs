using Microsoft.EntityFrameworkCore;
using TareaGrupal.Models;

namespace TareaGrupal.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }



     


    }
}