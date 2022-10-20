using HC_UserUI.Models;
using HC_UserUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HC_UserUI.Controllers
{
    public class PeliculasController : Controller
    {
        private readonly IPeliculasService _context;

        public PeliculasController(IPeliculasService context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Pelicula> lista;

            lista = await _context.ObtenerPeliculas();

            return View(lista);
        }

        public async Task<IActionResult> Detalles(int id)
        {
            var pelicula = await _context.ObtenerPelicula(id);

            if (pelicula == null)
            {
                return NotFound();
            }

            return View(pelicula);
        }
    }
}