using HC_API.Data;
using HC_API.Models;
using HC_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace HC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacionAdminController : ControllerBase
    {
        public static Administrador admin = new Administrador();

        private readonly IConfiguration _configuration;
        private readonly IAdminService _adminService;

        private readonly HC_APIContext _context;

        public AutenticacionAdminController(IConfiguration configuration, IAdminService adminService, HC_APIContext context)
        {
            _context = context;
            _configuration = configuration;
            _adminService = adminService;
        }

        [HttpGet, Authorize]
        public ActionResult<string> GetAdminConectado()
        {
            var adminConectado = _adminService.GetAdmin();
            return Ok(adminConectado);
        }

        [HttpPost("Registrar")]
        public async Task<ActionResult<Usuario>> RegistrarAdministrador(AdminDTO peticion)
        {
            CrearContrasenaHash(peticion.Contrasena, out byte[] contrasenaHash, out byte[] contrasenaSalt);

            admin.Email = peticion.Email;
            admin.Nombre = peticion.Nombre;
            admin.ContrasenaHash = contrasenaHash;
            admin.ContrasenaSalt = contrasenaSalt;

            return Ok(admin);
        }

        [HttpPost("Entrar")]
        public async Task<ActionResult<string>> Entrar(AdminDTO peticion)
        {
            if (admin.Email.Equals(peticion.Email))
            {
                return BadRequest("El usuario no existe o no fue encontrado");
            }

            if (!VerificarContrasenaHash(peticion.Contrasena, admin.ContrasenaHash, admin.ContrasenaSalt))
            {
                return BadRequest("La contraseña que ingresó no es correcta");
            }

            string token = CrearToken(admin);

            var refrescarToken = GenerarRefrescarToken();
            SetRefrescarToken(refrescarToken);

            return Ok("Ha iniciado sesión");
        }

        [HttpPost("refrescarToken")]
        public async Task<ActionResult<string>> RefrescarToken()
        {
            var refrescarToken = Request.Cookies["refreshToken"];

            if (!admin.RefrescarToken.Equals(refrescarToken))
            {
                return Unauthorized("Refrescamiento de token inválido");
            }
            else if (admin.TokenExpira < DateTime.Now)
            {
                return Unauthorized("El token ha expirado");
            }

            string token = CrearToken(admin);
            var nuevoToken = GenerarRefrescarToken();
            SetRefrescarToken(nuevoToken);

            return Ok(nuevoToken);
        }

        private RefrescarToken GenerarRefrescarToken()
        {
            var refrescarToken = new RefrescarToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expirado = DateTime.Now.AddDays(7),
                Creado = DateTime.Now
            };
            return refrescarToken;
        }

        private void SetRefrescarToken(RefrescarToken nuevoToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = nuevoToken.Expirado
            };
            Response.Cookies.Append("refreshToken", nuevoToken.Token, cookieOptions);

            admin.RefrescarToken = nuevoToken.Token;
            admin.TokenCreado = nuevoToken.Creado;
            admin.TokenExpira = nuevoToken.Expirado;
        }

        private string CrearToken(Administrador admin)
        {
            List<Claim> reclamos = new List<Claim>
            {
                new Claim (ClaimTypes.Name, admin.Email)
            };

            var llave = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var credenciales = new SigningCredentials(llave, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(claims: reclamos, expires: DateTime.Now.AddDays(1), signingCredentials: credenciales);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private void CrearContrasenaHash(string contrasena, out byte[] contrasenaHash, out byte[] contrasenaSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                contrasenaSalt = hmac.Key;
                contrasenaHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(contrasena));
            }
        }

        private bool VerificarContrasenaHash(string contrasena, byte[] contrasenaHash, byte[] contrasenaSalt)
        {
            using (var hmac = new HMACSHA512(contrasenaSalt))
            {
                var hashEnComputadora = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(contrasena));
                return hashEnComputadora.SequenceEqual(contrasenaHash);
            }
        }
    }
}