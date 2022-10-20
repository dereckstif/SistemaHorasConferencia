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
    public class AutenticacionUsuarioController : ControllerBase
    {
        public static Usuario usuario = new Usuario();
        private readonly HC_APIContext _context;
        private readonly IUsuarioService _usuarioService;
        private readonly IConfiguration _configuration;

        public AutenticacionUsuarioController(IConfiguration configuration, IUsuarioService usuarioService, HC_APIContext context)
        {
            _context = context;
            _usuarioService = usuarioService;
            _configuration = configuration;
        }

        [HttpGet, Authorize]
        public ActionResult<string> GetUsuarioConectado()
        {
            var usuarioConectado = _usuarioService.GetUsuario();
            return Ok(usuarioConectado);
        }

        [HttpPost("Registrar")]
        public async Task<ActionResult<Usuario>> RegistrarUsuario(UsuarioDTO peticion)
        {
            CrearContrasenaHash(peticion.Contrasena, out byte[] contrasenaHash, out byte[] contrasenaSalt);

            usuario.Carne = peticion.Carne;
            usuario.ContrasenaHash = contrasenaHash;
            usuario.ContrasenaSalt = contrasenaSalt;

            return Ok(usuario);
        }

        [HttpPost("Entrar")]
        public async Task<ActionResult<string>> Entrar(UsuarioDTO peticion)
        {
            if (usuario.Carne.Equals(peticion.Carne))
            {
                return BadRequest("El usuario no existe o no fue encontrado");
            }

            if (!VerificarContrasenaHash(peticion.Contrasena, usuario.ContrasenaHash, usuario.ContrasenaSalt))
            {
                return BadRequest("La contraseña que ingresó no es correcta");
            }

            string token = CrearToken(usuario);

            return Ok("Ha iniciado sesión");
        }

        private string CrearToken(Usuario usuario)
        {
            List<Claim> reclamos = new List<Claim>
            {
                new Claim (ClaimTypes.Name, usuario.Carne),
                new Claim (ClaimTypes.Role, "Estudiante")
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