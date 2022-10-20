using HC_AdminUI.Models;
using Newtonsoft.Json;
using System.Text;

namespace HC_AdminUI.Services
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

        public async Task<List<Registro>> ObtenerRegistrosDeActividad(int id_Actividad)
        {
            List<Registro> registros = new List<Registro>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync($"api/Registros/Actividad/{id_Actividad}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Registro>>(json_respuesta);
                registros = resultado;
            }

            return registros;
        }

        public async Task<List<Registro>> ObtenerRegistrosDePelicula(int id_Pelicula)
        {
            List<Registro> registros = new List<Registro>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync($"api/Registros/Pelicula/{id_Pelicula}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Registro>>(json_respuesta);
                registros = resultado;
            }

            return registros;
        }

        public async Task<List<Registro>> ObtenerRegistrosConfirmados()
        {
            List<Registro> registros = new List<Registro>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync($"api/Registros/Confirmados");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Registro>>(json_respuesta);
                registros = resultado;
            }

            return registros;
        }

        public async Task<List<Registro>> ObtenerRegistrosPendientes()
        {
            List<Registro> registros = new List<Registro>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync($"api/Registros/Pendientes");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Registro>>(json_respuesta);
                registros = resultado;
            }

            return registros;
        }

        public async Task<List<Registro>> ObtenerRegistros()
        {
            List<Registro> registros = new List<Registro>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync($"api/Registros");

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

        public async Task<bool> EliminarRegistro(int id)
        {
            bool Respuesta = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var response = await cliente.DeleteAsync($"api/Registros/{id}");

            if (response.IsSuccessStatusCode)
            {
                Respuesta = true;
            }
            return Respuesta;
        }
    }
}