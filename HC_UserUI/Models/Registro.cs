namespace HC_UserUI.Models
{
    public class Registro
    {
        //ID DEL REGISTRO
        public int Id { get; set; }

        //ID DEL ESTUDIANTE
        public int Id_Estudiante { get; set; }

        //TIPO DE HORA CONFERENCIA
        public string TipoHoraConferencia { get; set; }

        //ID DE LA ACTIVIDAD
        public int? Id_Actividad { get; set; }

        //ID DE LA PELICULA
        public int? Id_Pelicula { get; set; }

        //FECHA DEL REGISTRO
        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        //ARCHIVO ADJUNTO
        public string Archivo { get; set; }

        //HORAS TOTALES (REGISTRADAS EN MINUTOS)
        public int Minutos { get; set; }

        //TEMA CENTRAL DE LA ACTIVIDAD
        public string TemaCentral { get; set; }

        //DESCRIPCIÓN DEL ESTUDIANTE RESPECTO A LA ACTIVIDAD
        public string Descripcion { get; set; }

        //ESTADO DE LA HORA CONFERENCIA (PENDIENTE O CONFIRMADA)
        public string Estado { get; set; } = "Pendiente";

        //SI LA HORA CONFERENCIA SE RECHAZA, SE BRINDA RETROALIMENTACIÓN DE POR QUÉ SE RECHAZÓ
        public string? Retroalimentacion { get; set; }
    }
}