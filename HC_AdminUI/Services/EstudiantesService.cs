using HC_AdminUI.Models;
using Newtonsoft.Json;
using System.Text;

namespace HC_AdminUI.Services
{
    public class EstudiantesService : IEstudiantesService
    {
        private string _baseurl;

        public EstudiantesService(IConfiguration configuration)
        {
            _baseurl = configuration.GetSection("ApiUrl:BaseUrl").Value;
        }

        public async Task<bool> CrearEstudiante(Estudiante estudiante)
        {
            bool Respuesta = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var contenido = new StringContent(JsonConvert.SerializeObject(estudiante), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync("api/Estudiantes", contenido);

            if (response.IsSuccessStatusCode)
            {
                Respuesta = true;
            }
            return Respuesta;
        }

        public async Task<bool> EditarEstudiante(int id, Estudiante estudiante)
        {
            bool Respuesta = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var contenido = new StringContent(JsonConvert.SerializeObject(estudiante), Encoding.UTF8, "application/json");
            var response = await cliente.PutAsync($"api/Estudiantes/{id}", contenido);

            if (response.IsSuccessStatusCode)
            {
                Respuesta = true;
            }
            return Respuesta;
        }

        public async Task<List<Estudiante>> ObtenerEstudiantes()
        {
            List<Estudiante> estudiantes = new List<Estudiante>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync($"api/Estudiantes");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Estudiante>>(json_respuesta);
                estudiantes = resultado;
            }

            return estudiantes;
        }

        public async Task<Estudiante> ObtenerEstudiante(int id)
        {
            Estudiante estudiante = new Estudiante();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync($"api/Estudiantes/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Estudiante>(json_respuesta);
                estudiante = resultado;
            }

            return estudiante;
        }

        public async Task<bool> EliminarEstudiante(int id)
        {
            bool Respuesta = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var response = await cliente.DeleteAsync($"api/Estudiantes/{id}");

            if (response.IsSuccessStatusCode)
            {
                Respuesta = true;
            }
            return Respuesta;
        }
    }
}