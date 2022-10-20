using HC_AdminUI.Models;
using HC_AdminUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HC_AdminUI.Controllers
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

        public IActionResult Agregar()
        {
            ViewBag.Paises = ListaPaises();

            List<String> paisesOpcionales = new List<String> { " " };
            paisesOpcionales.AddRange(ListaPaises());

            ViewBag.PaisesOpcionales = paisesOpcionales;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Agregar(Pelicula pelicula)
        {
            if (ModelState.IsValid)
            {
                await _context.CrearPelicula(pelicula);
                return RedirectToAction(nameof(Index));
            }
            return View(pelicula);
        }

        public async Task<IActionResult> Editar(int id)
        {
            var pelicula = await _context.ObtenerPelicula(id);
            if (pelicula == null)
            {
                return NotFound();
            }
            return View(pelicula);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Pelicula pelicula)
        {
            if (id != pelicula.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.EditarPelicula(id, pelicula);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeliculaExists(pelicula.Id))
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
            return View(pelicula);
        }

        public async Task<IActionResult> Eliminar(int id)
        {
            var pelicula = await _context.ObtenerPelicula(id);
            if (pelicula == null)
            {
                return NotFound();
            }

            return View(pelicula);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarConfirmado(int id)
        {
            await _context.EliminarPelicula(id);
            return RedirectToAction(nameof(Index));
        }

        private bool PeliculaExists(int id)
        {
            if (_context.ObtenerPelicula(id) == null)
            {
                return false;
            }

            return true;
        }

        private List<String> ListaPaises()
        {
            List<String> paises = new List<String>();

            paises.AddRange(new List<String>() { "Costa Rica", "Afganistán", "Albania", "Alemania", "Andorra", "Angola", "Antigua y Barbuda", "Arabia Saudita", "Argelia", "Argentina" });

            paises.AddRange(new List<String>() { "Armenia", "Australia", "Austria", "Azerbaiyán", "Bahamas", "Bangladés", "Barbados", "Baréin", "Bélgica" });

            paises.AddRange(new List<String>() { "Belice", "Benín", "Bielorrusia", "Birmania", "Birmania", "Bosnia y Herzegovina", "Botsuana", "Brasil", "Brunéi" });

            paises.AddRange(new List<String>() { "Bulgaria", "Burkina Faso", "Burundi", "Bután", "Cabo Verde", "Camboya", "Camerún", "Canadá", "Catar" });

            paises.AddRange(new List<String>() { "Chad", "Chile", "China", "Chipre", "Ciudad del Vaticano", "Colombia", "Comoras", "Corea del Norte", "Corea del Sur", "Costa de Marfil" });

            paises.AddRange(new List<String>() { "Croacia", "Cuba", "Dinamarca", "Dominica", "Ecuador", "Egipto", "El Salvador", "Emiratos Árabes Unidos", "Eritrea" });

            paises.AddRange(new List<String>() { "Eslovaquia", "Eslovenia", "España", "Estados Unidos", "Estonia", "Etiopía", "Etiopía", "Finlandia", "Fiyi" });

            paises.AddRange(new List<String>() { "Francia", "Gabón", "Gambia", "Georgia", "Bahamas", "Ghana", "Granada", "Grecia", "Guatemala" });

            paises.AddRange(new List<String>() { "Guyana", "Guinea", "Guinea ecuatorial", "Guinea-Bisáu", "Haití", "Honduras", "Hungría", "India", "Indonesia" });

            paises.AddRange(new List<String>() { "Irak", "Irán", "Irlanda", "Islandia", "Islas Marshall", "Islas Salomón", "Israel", "Italia", "Jamaica" });

            paises.AddRange(new List<String>() { "Japón", "Jordania", "Kazajistán", "Kenia", "Kirguistán", "Kiribati", "Kuwait", "Laos", "Lesoto" });

            paises.AddRange(new List<String>() { "Letonia", "Líbano", "Liberia", "Libia", "Liechtenstein", "Lituania", "Luxemburgo", "Macedonia del Norte", "Madagascar" });

            paises.AddRange(new List<String>() { "Malasia", "Malaui", "Maldivas", "Malí", "Malta", "Marruecos", "Mauricio", "Mauritania", "México" });

            paises.AddRange(new List<String>() { "Micronesia", "Moldavia", "Monaco", "Mongolia", "Montenegro", "Mozambique", "Namibia", "Nauru", "Nepal" });

            paises.AddRange(new List<String>() { "Nicaragua", "Níger", "Nigeria", "Noruega", "Nueva Zelanda", "Omán", "Países Bajos", "Pakistán", "Palaos", "Palestina" });

            paises.AddRange(new List<String>() { "Panamá", "Papúa Nueva Guinea", "Paraguay", "Perú", "Polonia", "Portugal", "Reino Unido", "República Centroafricana", "República Checa" });

            paises.AddRange(new List<String>() { "República del Congo", "República Democrática del Congo", "República Dominicana", "Ruanda", "Rumanía", "Rusia", "Samoa", "San Cristóbal y Nieves", "San Marino" });

            paises.AddRange(new List<String>() { "San Vicente y las Granadinas", "Santa Lucía", "Santo Tomé y Príncipe", "Senegal", "Serbia", "Seychelles", "Sierra Leona", "Singapur", "Siria" });

            paises.AddRange(new List<String>() { "Somalia", "Sri Lanka", "Suazilandia", "Sudáfrica", "Sudán", "Sudán del Sur", "Suecia", "Suiza", "Surinam" });

            paises.AddRange(new List<String>() { "Tailandia", "Tanzania", "Tayikistán", "Timor Oriental", "Togo", "Tonga", "Trinidad y Tobago", "Túnez", "Turkmenistán" });

            paises.AddRange(new List<String>() { "Turquía", "Tuvalu", "Ucrania", "Uganda", "Unión Sovietica", "Uruguay", "Uzbekistán", "Vanuatu", "Venezuela" });

            paises.AddRange(new List<String>() { "Vietnam", "Yemen", "Yibuti", "Yugoslavia", "Zambia", "Zimbabue" });

            return paises;
        }
    }
}