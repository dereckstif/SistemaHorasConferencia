using HC_UserUI.Models;

namespace HC_UserUI.Services
{
    public interface IRegistroService
    {
        public Task<bool> CrearRegistro(Registro registro);

        public Task<bool> EditarRegistro(int id, Registro registro);

        public Task<List<Registro>> ObtenerRegistrosDeEstudiante(int id_Estudiante);

        public Task<List<Registro>> ObtenerRegistrosPendientesDeEstudiante(int id_Estudiante);

        public Task<List<Registro>> ObtenerRegistrosConfirmadosDeEstudiante(int id_Estudiante);

        public Task<List<Registro>> ObtenerRegistrosRechazadosDeEstudiante(int id_Estudiante);

        public Task<Registro> ObtenerRegistro(int id);
    }
}