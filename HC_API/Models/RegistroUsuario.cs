using System.ComponentModel.DataAnnotations;

namespace HC_API.Models
{
    public class RegistroUsuario
    {
        //CARNE DEL USUARIO
        public string Carne { get; set; } = string.Empty;

        [Required, StringLength(100, MinimumLength = 8)]
        public string Contrasena { get; set; } = string.Empty;

        [Compare("Contrasena", ErrorMessage = "Las contraseñas no coinciden")]
        public string ConfirmarContrasena { get; set; } = string.Empty;
    }
}