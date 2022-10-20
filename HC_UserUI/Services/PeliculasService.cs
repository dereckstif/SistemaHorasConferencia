using HC_UserUI.Models;
using Newtonsoft.Json;

namespace HC_UserUI.Services
{
    public class PeliculasService : IPeliculasService
    {
        private string _baseurl;

        public PeliculasService(IConfiguration configuration)
        {
            _baseurl = configuration.GetSection("ApiUrl:BaseUrl").Value;
        }

        public async Task<List<Pelicula>> ObtenerPeliculas()
        {
            List<Pelicula> peliculas = new List<Pelicula>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync($"api/Peliculas");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Pelicula>>(json_respuesta);
                peliculas = resultado;
            }

            return peliculas;
        }

        public async Task<Pelicula> ObtenerPelicula(int id)
        {
            Pelicula pelicula = new Pelicula();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync($"api/Peliculas/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Pelicula>(json_respuesta);
                pelicula = resultado;
            }

            return pelicula;
        }
    }
}