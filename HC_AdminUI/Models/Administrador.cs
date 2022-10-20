using System.ComponentModel.DataAnnotations;

namespace HC_AdminUI.Models
{
    public class Administrador
    {
        //ID DEL ADMINISTRADOR
        public int Id { get; set; }

        //NOMBRE DEL ADMINISTRADOR
        public string Nombre { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        public byte[] ContrasenaHash { get; set; }

        public byte[] ContrasenaSalt { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}