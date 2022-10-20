using HC_AdminUI.Models;

namespace HC_AdminUI.Services
{
    public interface IActividadesService
    {
        public Task<bool> CrearActividad(Actividad actividad);

        public Task<bool> EditarActividad(int id, Actividad actividad);

        public Task<List<Actividad>> ObtenerActividades();

        public Task<Actividad> ObtenerActividad(int id);

        public Task<bool> EliminarActividad(int id);
    }
}