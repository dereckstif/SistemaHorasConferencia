using HC_AdminUI.Models;

namespace HC_AdminUI.Services
{
    public interface IRegistroService
    {
        public Task<bool> CrearRegistro(Registro registro);

        public Task<bool> EditarRegistro(int id, Registro registro);

        public Task<List<Registro>> ObtenerRegistros();

        public Task<List<Registro>> ObtenerRegistrosDeEstudiante(int id_Estudiante);

        public Task<List<Registro>> ObtenerRegistrosDeActividad(int id_Actividad);

        public Task<List<Registro>> ObtenerRegistrosDePelicula(int id_Pelicula);

        public Task<List<Registro>> ObtenerRegistrosPendientes();

        public Task<List<Registro>> ObtenerRegistrosConfirmados();

        public Task<Registro> ObtenerRegistro(int id);

        public Task<bool> EliminarRegistro(int id);
    }
}