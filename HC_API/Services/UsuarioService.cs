using System.Security.Claims;

namespace HC_API.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UsuarioService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUsuario()
        {
            var resultado = string.Empty;

            if (_httpContextAccessor.HttpContext != null)
            {
                resultado = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            }
            return resultado;
        }
    }
}