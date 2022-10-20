using HC_API.Data;
using HC_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrosController : ControllerBase
    {
        private readonly HC_APIContext _context;

        public RegistrosController(HC_APIContext context)
        {
            _context = context;
        }

        // GET: api/Registros
        [HttpGet, Authorize(Roles = "Administrador")]
        public async Task<ActionResult<IEnumerable<Registro>>> GetRegistro()
        {
            return await _context.Registro.ToListAsync();
        }

        // GET: api/Registros/5
        [HttpGet("{id}"), Authorize]
        public async Task<ActionResult<Registro>> GetRegistro(int id)
        {
            var registro = await _context.Registro.FindAsync(id);

            if (registro == null)
            {
                return NotFound();
            }

            return registro;
        }

        // GET: api/Registros/Estudiante/5
        [HttpGet("Estudiante/{id}"), Authorize]
        public async Task<ActionResult<IEnumerable<Registro>>> GetRegistrosPorEstudiante(int id)
        {
            return await _context.Registro.Where(x => x.Id_Estudiante.Equals(id)).ToListAsync();
        }

        // GET: api/Registros/Actividad/5
        [HttpGet("Actividad/{id}"), Authorize(Roles = "Administrador")]
        public async Task<ActionResult<IEnumerable<Registro>>> GetRegistrosPorActividad(int id)
        {
            return await _context.Registro.Where(x => x.Id_Actividad.Equals(id)).ToListAsync();
        }

        // GET: api/Registros/Pelicula/5
        [HttpGet("Pelicula/{id}"), Authorize(Roles = "Administrador")]
        public async Task<ActionResult<IEnumerable<Registro>>> GetRegistrosPorPelicula(int id)
        {
            return await _context.Registro.Where(x => x.Id_Pelicula.Equals(id)).ToListAsync();
        }

        // GET: api/Registros/Confirmados
        [HttpGet("Confirmados"), Authorize(Roles = "Administrador")]
        public async Task<ActionResult<IEnumerable<Registro>>> GetRegistrosConfirmados()
        {
            return await _context.Registro.Where(x => x.Estado.Equals("Confirmado")).ToListAsync();
        }

        // GET: api/Registros/Pendientes
        [HttpGet("Pendientes"), Authorize(Roles = "Administrador")]
        public async Task<ActionResult<IEnumerable<Registro>>> GetRegistrosPendientes()
        {
            return await _context.Registro.Where(x => x.Estado.Equals("Pendiente")).ToListAsync();
        }

        // GET: api/Registros/Estudiante/Confirmados/5
        [HttpGet("Estudiante/Confirmados/{id}"), Authorize]
        public async Task<ActionResult<IEnumerable<Registro>>> GetRegistrosConfirmadosPorEstudiante(int id)
        {
            return await _context.Registro.Where(x => x.Id_Estudiante.Equals(id)).Where(y => y.Estado.Equals("Confirmado")).ToListAsync();
        }

        // GET: api/Registros/Estudiante/Pendientes/5
        [HttpGet("Estudiante/Pendientes/{id}"), Authorize]
        public async Task<ActionResult<IEnumerable<Registro>>> GetRegistrosPendientesPorEstudiante(int id)
        {
            return await _context.Registro.Where(x => x.Id_Estudiante.Equals(id)).Where(y => y.Estado.Equals("Pendiente")).ToListAsync();
        }

        // GET: api/Registros/Estudiante/Rechazados/5
        [HttpGet("Estudiante/Rechazados/{id}"), Authorize]
        public async Task<ActionResult<IEnumerable<Registro>>> GetRegistrosRechazadosPorEstudiante(int id)
        {
            return await _context.Registro.Where(x => x.Id_Estudiante.Equals(id)).Where(y => y.Estado.Equals("Rechazado")).ToListAsync();
        }

        // PUT: api/Registros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> PutRegistro(int id, Registro registro)
        {
            if (id != registro.Id)
            {
                return BadRequest();
            }

            _context.Entry(registro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistroExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Registros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost, Authorize]
        public async Task<ActionResult<Registro>> PostRegistro(Registro registro)
        {
            _context.Registro.Add(registro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegistro", new { id = registro.Id }, registro);
        }

        // DELETE: api/Registros/5
        [HttpDelete("{id}"), Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DeleteRegistro(int id)
        {
            var registro = await _context.Registro.FindAsync(id);
            if (registro == null)
            {
                return NotFound();
            }

            _context.Registro.Remove(registro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegistroExists(int id)
        {
            return _context.Registro.Any(e => e.Id == id);
        }
    }
}