using HC_AdminUI.Models;

namespace HC_AdminUI.Services
{
    public interface IPeliculasService
    {
        public Task<bool> CrearPelicula(Pelicula pelicula);

        public Task<bool> EditarPelicula(int id, Pelicula pelicula);

        public Task<List<Pelicula>> ObtenerPeliculas();

        public Task<Pelicula> ObtenerPelicula(int id);

        public Task<bool> EliminarPelicula(int id);
    }
}