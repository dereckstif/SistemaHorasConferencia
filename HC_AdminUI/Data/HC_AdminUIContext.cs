using Microsoft.EntityFrameworkCore;

namespace HC_AdminUI.Data
{
    public class HC_AdminUIContext : DbContext
    {
        public HC_AdminUIContext(DbContextOptions<HC_AdminUIContext> options)
            : base(options)
        {
        }

        public DbSet<HC_AdminUI.Models.Pelicula> Pelicula { get; set; } = default!;

        public DbSet<HC_AdminUI.Models.Actividad> Actividad { get; set; }

        public DbSet<HC_AdminUI.Models.Estudiante> Estudiante { get; set; }

        public DbSet<HC_AdminUI.Models.Registro> Registro { get; set; }
    }
}