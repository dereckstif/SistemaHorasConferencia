namespace HC_API.Models
{
    public class Usuario
    {
        //ID DEL USUARIO
        public int Id { get; set; }

        //ID DEL PERFIL DE ESTUDIANTE ENLAZADO
        public int Id_Estudiante { get; set; }

        //CARNE DEL ESTUDIANTE (USERNAME)
        public string Carne { get; set; }

        //CORREO DEL USUARIO (NO SE SI BORRAR)
        public string Correo { get; set; }

        public byte[] ContrasenaHash { get; set; }

        public byte[] ContrasenaSalt { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public string RefrescarToken { get; set; } = string.Empty;

        public DateTime TokenCreado { get; set; }

        public DateTime TokenExpira { get; set; }
    }
}