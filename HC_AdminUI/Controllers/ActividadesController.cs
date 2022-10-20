using HC_AdminUI.Models;
using HC_AdminUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HC_AdminUI.Controllers
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

        public IActionResult Agregar()
        {
            List<String> paisesOpcionales = new List<String> { " " };

            ViewBag.PaisesOpcionales = paisesOpcionales;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Agregar(Actividad actividad)
        {
            DateTime inicio = actividad.HoraInicio;
            DateTime final = actividad.HoraFinal;

            int minutos = (int)final.Subtract(inicio).TotalMinutes;

            actividad.DuracionMinutos = minutos;

            if (minutos < 0)
            {
                ViewBag.Message = "La hora final no coincide con la hora de inicio";
                return View(actividad);
            }

            if (ModelState.IsValid)
            {
                await _context.CrearActividad(actividad);
                return RedirectToAction(nameof(Index));
            }

            return View(actividad);
        }

        public async Task<IActionResult> Editar(int id)
        {
            var actividad = await _context.ObtenerActividad(id);
            if (actividad == null)
            {
                return NotFound();
            }
            return View(actividad);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Actividad actividad)
        {
            if (id != actividad.Id)
            {
                return NotFound();
            }

            DateTime inicio = actividad.HoraInicio;
            DateTime final = actividad.HoraFinal;

            int minutos = (int)final.Subtract(inicio).TotalMinutes;

            actividad.DuracionMinutos = minutos;

            if (minutos < 0)
            {
                ViewBag.Message = "La hora final no coincide con la hora de inicio";
                return View(actividad);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.EditarActividad(id, actividad);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActividadExists(actividad.Id))
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
            return View(actividad);
        }

        public async Task<IActionResult> Eliminar(int id)
        {
            var actividad = await _context.ObtenerActividad(id);
            if (actividad == null)
            {
                return NotFound();
            }

            return View(actividad);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarConfirmado(int id)
        {
            await _context.EliminarActividad(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ActividadExists(int id)
        {
            if (_context.ObtenerActividad(id) == null)
            {
                return false;
            }

            return true;
        }
    }
}