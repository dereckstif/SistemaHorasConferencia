using HC_UserUI.Models;
using HC_UserUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HC_UserUI.Controllers
{
    public class ActividadesController : Controller
    {
        private readonly IActividadesService _context;

        public ActividadesController(IActividadesService context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Actividad> lista;

            lista = await _context.ObtenerActividades();

            return View(lista);
        }

        public async Task<IActionResult> Detalles(int id)
        {
            var actividad = await _context.ObtenerActividad(id);
            if (actividad == null)
            {
                return NotFound();
            }

            return View(actividad);
        }
    }
}