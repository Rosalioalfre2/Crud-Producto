using Microsoft.EntityFrameworkCore;


namespace Crudsito.Models
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet<Producto> Productos { get; set; }
    }
}
