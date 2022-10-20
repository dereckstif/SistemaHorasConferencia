using HC_UserUI.Models;
using HC_UserUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HC_UserUI.Controllers
{
    public class RegistrosController : Controller
    {
        //PARA PRUEBAS
        public int estudiante = 1;

        private readonly IRegistroService _context;

        private readonly IPeliculasService _contextPeliculas;

        public RegistrosController(IRegistroService context, IPeliculasService contextPeliculas)
        {
            _context = context;

            _contextPeliculas = contextPeliculas;
        }

        public async Task<IActionResult> Index()
        {
            List<Registro> lista;

            lista = await _context.ObtenerRegistrosDeEstudiante(estudiante);

            return View(lista);
        }

        public async Task<IActionResult> Confirmados()
        {
            List<Registro> lista;

            lista = await _context.ObtenerRegistrosConfirmadosDeEstudiante(estudiante);

            return View(lista);
        }

        public async Task<IActionResult> Pendientes()
        {
            List<Registro> lista;

            lista = await _context.ObtenerRegistrosPendientesDeEstudiante(estudiante);

            return View(lista);
        }

        public async Task<IActionResult> Rechazados()
        {
            List<Registro> lista;

            lista = await _context.ObtenerRegistrosRechazadosDeEstudiante(estudiante);

            return View(lista);
        }

        public async Task<IActionResult> Exportar()
        {
            List<Registro> lista;

            lista = await _context.ObtenerRegistrosDeEstudiante(estudiante);

            return View(lista);
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
                return View("DetallesActividad", registro);
            }
            else
            {
                return View("DetallesPelicula", registro);
            }
        }

        public async Task<IActionResult> Editar(int id)
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

        // GET: Registroes/Create
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
        public async Task<IActionResult> Editar(int id, Registro registro)
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
    }
}