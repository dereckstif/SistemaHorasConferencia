using HC_AdminUI.Models;
using HC_AdminUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HC_AdminUI.Controllers
{
    public class EstudiantesController : Controller
    {
        private readonly IEstudiantesService _context;

        public EstudiantesController(IEstudiantesService context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Estudiante> lista;

            lista = await _context.ObtenerEstudiantes();

            return View(lista);
        }

        public async Task<IActionResult> Detalles(int id)
        {
            var estudiante = await _context.ObtenerEstudiante(id);
            if (estudiante == null)
            {
                return NotFound();
            }

            return View(estudiante);
        }

        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Agregar(Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                await _context.CrearEstudiante(estudiante);
                return RedirectToAction(nameof(Index));
            }
            return View(estudiante);
        }

        public async Task<IActionResult> Editar(int id)
        {
            var estudiante = await _context.ObtenerEstudiante(id);
            if (estudiante == null)
            {
                return NotFound();
            }
            return View(estudiante);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Estudiante estudiante)
        {
            if (id != estudiante.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.EditarEstudiante(id, estudiante);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudianteExists(estudiante.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(estudiante);
        }

        public async Task<IActionResult> Eliminar(int id)
        {
            var estudiante = await _context.ObtenerEstudiante(id);
            if (estudiante == null)
            {
                return NotFound();
            }

            return View(estudiante);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarConfirmado(int id)
        {
            await _context.EliminarEstudiante(id);
            return RedirectToAction(nameof(Index));
        }

        private bool EstudianteExists(int id)
        {
            if (_context.ObtenerEstudiante(id) == null)
            {
                return false;
            }

            return true;
        }
    }
}