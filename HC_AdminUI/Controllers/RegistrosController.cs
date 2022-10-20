using HC_AdminUI.Models;
using HC_AdminUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HC_AdminUI.Controllers
{
    public class RegistrosController : Controller
    {
        private readonly IRegistroService _context;

        private readonly IPeliculasService _contextPeliculas;

        public RegistrosController(IRegistroService context, IPeliculasService contextPeliculas)
        {
            _context = context;

            _contextPeliculas = contextPeliculas;
        }

        public async Task<IActionResult> ObtenerDetalles(int id)
        {
            Registro registro = await _context.ObtenerRegistro(id);
            if (registro == null)
            {
                return NotFound();
            }

            if (registro.Id_Pelicula == null)
            {
                List<String> estados = new List<String> { "Pendiente", "Confirmado", "Rechazado" };
                ViewBag.Estados = estados;
                return View("DetallesActividad", registro);
            }
            else
            {
                List<String> estados = new List<String> { "Pendiente", "Confirmado", "Rechazado" };
                ViewBag.Estados = estados;
                return View("DetallesPelicula", registro);
            }
        }

        public async Task<IActionResult> Validar(int id)
        {
            var registro = await _context.ObtenerRegistro(id);
            if (registro == null)
            {
                return NotFound();
            }
            return View(registro);
        }

        public async Task<IActionResult> RegistrarPelicula()
        {
            List<Pelicula> peliculas = await _contextPeliculas.ObtenerPeliculas();

            ViewBag.Peliculas = peliculas;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrarPelicula(Registro registro)
        {
            if (ModelState.IsValid)
            {
                await _context.CrearRegistro(registro);
                return RedirectToAction(nameof(Index));
            }
            return View(registro);
        }

        public IActionResult RegistrarActividad()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrarActividad(Registro registro)
        {
            if (ModelState.IsValid)
            {
                await _context.CrearRegistro(registro);
                return RedirectToAction(nameof(Index));
            }
            return View(registro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Validar(int id, Registro registro)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    id = registro.Id;
                    await _context.EditarRegistro(id, registro);
                }
                catch (Exception e)
                {
                }
                return RedirectToAction(nameof(Index));
            }
            return View(registro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmacionRapida(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Registro registro = await _context.ObtenerRegistro(id);
                    registro.Estado = "Confirmado";
                    await _context.EditarRegistro(id, registro);
                }
                catch (Exception e)
                {
                }
            }
            return RedirectToAction(nameof(RegistrosPendientes));
        }

        public async Task<IActionResult> Index()
        {
            List<Registro> lista;

            lista = await _context.ObtenerRegistros();

            return View(lista);
        }

        public async Task<IActionResult> RegistrosEstudiante(int id)
        {
            List<Registro> lista;

            lista = await _context.ObtenerRegistrosDeEstudiante(id);

            return View(lista);
        }

        public async Task<IActionResult> RegistrosActividad(int id)
        {
            List<Registro> lista;

            lista = await _context.ObtenerRegistrosDeActividad(id);

            return View(lista);
        }

        public async Task<IActionResult> RegistrosPelicula(int id)
        {
            List<Registro> lista;

            lista = await _context.ObtenerRegistrosDePelicula(id);

            return View(lista);
        }

        public async Task<IActionResult> RegistrosPendientes()
        {
            List<Registro> lista;

            lista = await _context.ObtenerRegistrosPendientes();

            return View(lista);
        }

        public async Task<IActionResult> RegistrosConfirmados()
        {
            List<Registro> lista;

            lista = await _context.ObtenerRegistrosConfirmados();

            return View(lista);
        }

        public async Task<IActionResult> Eliminar(int id)
        {
            var registro = await _context.ObtenerRegistro(id);
            if (registro == null)
            {
                return NotFound();
            }

            return View(registro);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarConfirmado(int id)
        {
            await _context.EliminarRegistro(id);
            return RedirectToAction(nameof(Index));
        }

        private bool RegistroExists(int id)
        {
            if (_context.ObtenerRegistro(id) == null)
            {
                return false;
            }

            return true;
        }
    }
}