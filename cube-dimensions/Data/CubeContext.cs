using cube_dimensions.Models;
using Microsoft.EntityFrameworkCore;

namespace cube_dimensions.Data
{
    public class CubeContext : DbContext
    {
        public CubeContext(DbContextOptions<CubeContext> options) : base(options) { }

        public DbSet<Cube> Cubes { get; set; }
    }
}
