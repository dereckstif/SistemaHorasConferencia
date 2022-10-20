using HC_UserUI.Models;
using Newtonsoft.Json;

namespace HC_UserUI.Services
{
    public class ActividadesService : IActividadesService
    {
        private string _baseurl;

        public ActividadesService(IConfiguration configuration)
        {
            _baseurl = configuration.GetSection("ApiUrl:BaseUrl").Value;
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
    }
}