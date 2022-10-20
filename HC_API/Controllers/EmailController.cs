using HC_API.Data;
using HC_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace HC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public IActionResult EnviarEmail(EmailDTO peticion)
        {
            _emailService.EnviarEmail(peticion);

            return Ok();
        }
    }
}