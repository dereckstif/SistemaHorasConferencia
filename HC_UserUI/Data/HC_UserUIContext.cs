using Microsoft.EntityFrameworkCore;

namespace HC_UserUI.Data
{
    public class HC_UserUIContext : DbContext
    {
        public HC_UserUIContext(DbContextOptions<HC_UserUIContext> options)
            : base(options)
        {
        }

        public DbSet<HC_UserUI.Models.Pelicula> Pelicula { get; set; } = default!;

        public DbSet<HC_UserUI.Models.Actividad> Actividad { get; set; }
    }
}