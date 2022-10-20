using System.Security.Claims;

namespace HC_API.Services
{
    public class AdminService : IAdminService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AdminService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetAdmin()
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