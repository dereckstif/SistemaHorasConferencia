using HC_UserUI.Models;

namespace HC_UserUI.Services
{
    public interface IActividadesService
    {
        public Task<List<Actividad>> ObtenerActividades();

        public Task<Actividad> ObtenerActividad(int id);
    }
}