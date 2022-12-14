using System.ComponentModel.DataAnnotations;

namespace HC_API.Models
{
    public class RegistroAdministrador
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, StringLength(100, MinimumLength = 8)]
        public string Contrasena { get; set; } = string.Empty;

        [Compare("Contrasena", ErrorMessage = "Las contraseñas no coinciden")]
        public string ConfirmarContrasena { get; set; } = string.Empty;
    }
}