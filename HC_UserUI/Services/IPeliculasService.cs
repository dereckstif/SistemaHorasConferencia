using HC_UserUI.Models;

namespace HC_UserUI.Services
{
    public interface IPeliculasService
    {
        public Task<List<Pelicula>> ObtenerPeliculas();

        public Task<Pelicula> ObtenerPelicula(int id);
    }
}