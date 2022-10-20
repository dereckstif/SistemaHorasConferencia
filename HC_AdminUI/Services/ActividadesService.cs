using HC_AdminUI.Models;
using Newtonsoft.Json;
using System.Text;

namespace HC_AdminUI.Services
{
    public class ActividadesService : IActividadesService
    {
        private string _baseurl;

        public ActividadesService(IConfiguration configuration)
        {
            _baseurl = configuration.GetSection("ApiUrl:BaseUrl").Value;
        }

        public async Task<bool> CrearActividad(Actividad actividad)
        {
            bool Respuesta = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var contenido = new StringContent(JsonConvert.SerializeObject(actividad), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync("api/Actividad", contenido);

            if (response.IsSuccessStatusCode)
            {
                Respuesta = true;
            }
            return Respuesta;
        }

        public async Task<bool> EditarActividad(int id, Actividad actividad)
        {
            bool Respuesta = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var contenido = new StringContent(JsonConvert.SerializeObject(actividad), Encoding.UTF8, "application/json");
            var response = await cliente.PutAsync($"api/Actividad/{id}", contenido);

            if (response.IsSuccessStatusCode)
            {
                Respuesta = true;
            }
            return Respuesta;
        }

        public async Task<List<Actividad>> ObtenerActividades()
        {
            List<Actividad> actividades = new List<Actividad>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync($"api/Actividad");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Actividad>>(json_respuesta);
                actividades = resultado;
            }

            return actividades;
        }

        public async Task<Actividad> ObtenerActividad(int id)
        {
            Actividad actividad = new Actividad();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync($"api/Actividad/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Actividad>(json_respuesta);
                actividad = resultado;
            }

            return actividad;
        }

        public async Task<bool> EliminarActividad(int id)
        {
            bool Respuesta = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var response = await cliente.DeleteAsync($"api/Actividad/{id}");

            if (response.IsSuccessStatusCode)
            {
                Respuesta = true;
            }
            return Respuesta;
        }
    }
}