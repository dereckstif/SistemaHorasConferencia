using HC_UserUI.Models;
using Newtonsoft.Json;
using System.Text;

namespace HC_UserUI.Services
{
    public class RegistroService : IRegistroService
    {
        private string _baseurl;

        public RegistroService(IConfiguration configuration)
        {
            _baseurl = configuration.GetSection("ApiUrl:BaseUrl").Value;
        }

        public async Task<bool> CrearRegistro(Registro registro)
        {
            bool Respuesta = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var contenido = new StringContent(JsonConvert.SerializeObject(registro), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync("api/Registros", contenido);

            if (response.IsSuccessStatusCode)
            {
                Respuesta = true;
            }
            return Respuesta;
        }

        public async Task<bool> EditarRegistro(int id, Registro registro)
        {
            bool Respuesta = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var contenido = new StringContent(JsonConvert.SerializeObject(registro), Encoding.UTF8, "application/json");
            var response = await cliente.PutAsync($"api/Registros/{id}", contenido);

            if (response.IsSuccessStatusCode)
            {
                Respuesta = true;
            }
            return Respuesta;
        }

        public async Task<List<Registro>> ObtenerRegistrosDeEstudiante(int id_Estudiante)
        {
            List<Registro> registros = new List<Registro>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync($"api/Registros/Estudiante/{id_Estudiante}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Registro>>(json_respuesta);
                registros = resultado;
            }

            return registros;
        }

        public async Task<List<Registro>> ObtenerRegistrosConfirmadosDeEstudiante(int id_Estudiante)
        {
            List<Registro> registros = new List<Registro>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync($"api/Registros/Estudiante/Confirmados/{id_Estudiante}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Registro>>(json_respuesta);
                registros = resultado;
            }

            return registros;
        }

        public async Task<List<Registro>> ObtenerRegistrosPendientesDeEstudiante(int id_Estudiante)
        {
            List<Registro> registros = new List<Registro>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync($"api/Registros/Estudiante/Pendientes/{id_Estudiante}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Registro>>(json_respuesta);
                registros = resultado;
            }

            return registros;
        }

        public async Task<List<Registro>> ObtenerRegistrosRechazadosDeEstudiante(int id_Estudiante)
        {
            List<Registro> registros = new List<Registro>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync($"api/Registros/Estudiante/Rechazados/{id_Estudiante}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Registro>>(json_respuesta);
                registros = resultado;
            }

            return registros;
        }

        public async Task<Registro> ObtenerRegistro(int id)
        {
            Registro registro = new Registro();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync($"api/Registros/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Registro>(json_respuesta);
                registro = resultado;
            }

            return registro;
        }
    }
}