using HC_AdminUI.Models;
using Newtonsoft.Json;
using System.Text;

namespace HC_AdminUI.Services
{
    public class PeliculasService : IPeliculasService
    {
        private string _baseurl;

        public PeliculasService(IConfiguration configuration)
        {
            _baseurl = configuration.GetSection("ApiUrl:BaseUrl").Value;
        }

        public async Task<bool> CrearPelicula(Pelicula pelicula)
        {
            bool Respuesta = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var contenido = new StringContent(JsonConvert.SerializeObject(pelicula), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync("api/Peliculas", contenido);

            if (response.IsSuccessStatusCode)
            {
                Respuesta = true;
            }
            return Respuesta;
        }

        public async Task<bool> EditarPelicula(int id, Pelicula pelicula)
        {
            bool Respuesta = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var contenido = new StringContent(JsonConvert.SerializeObject(pelicula), Encoding.UTF8, "application/json");
            var response = await cliente.PutAsync($"api/Peliculas/{id}", contenido);

            if (response.IsSuccessStatusCode)
            {
                Respuesta = true;
            }
            return Respuesta;
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

        public async Task<bool> EliminarPelicula(int id)
        {
            bool Respuesta = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var response = await cliente.DeleteAsync($"api/Peliculas/{id}");

            if (response.IsSuccessStatusCode)
            {
                Respuesta = true;
            }
            return Respuesta;
        }
    }
}