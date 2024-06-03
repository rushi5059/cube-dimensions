
using cube_dimensions.Models;
using Microsoft.EntityFrameworkCore;

namespace cube_dimensions.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cube> Cubes { get; set; }
    }
}
