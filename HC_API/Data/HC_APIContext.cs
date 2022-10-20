using Microsoft.EntityFrameworkCore;

namespace HC_API.Data
{
    public class HC_APIContext : DbContext
    {
        public HC_APIContext(DbContextOptions<HC_APIContext> options)
            : base(options)
        {
        }

        public DbSet<HC_API.Models.Actividad> Actividad { get; set; } = default!;

        public DbSet<HC_API.Models.Estudiante> Estudiante { get; set; }

        public DbSet<HC_API.Models.Pelicula> Pelicula { get; set; }

        public DbSet<HC_API.Models.Registro> Registro { get; set; }
    }
}