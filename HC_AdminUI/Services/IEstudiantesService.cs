using HC_AdminUI.Models;

namespace HC_AdminUI.Services
{
    public interface IEstudiantesService
    {
        public Task<bool> CrearEstudiante(Estudiante estudiante);

        public Task<bool> EditarEstudiante(int id, Estudiante estudiante);

        public Task<List<Estudiante>> ObtenerEstudiantes();

        public Task<Estudiante> ObtenerEstudiante(int id);

        public Task<bool> EliminarEstudiante(int id);
    }
}