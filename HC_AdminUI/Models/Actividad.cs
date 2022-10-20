using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HC_AdminUI.Models
{
    public class Actividad
    {
        //ID DE LA ACTIVIDAD
        public int Id { get; set; }

        //NOMBRE DE LA ACTIVIDAD
        public string Nombre { get; set; }

        //FECHA DE LA ACTIVIDAD
        [Required]
        [BindProperty, DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        //HORA DE INICIO
        [BindProperty, DataType(DataType.Time)]
        public DateTime HoraInicio { get; set; }

        //HORA DE FINALIZACIÓN
        [BindProperty, DataType(DataType.Time)]
        public DateTime HoraFinal { get; set; }

        //ORGANIZADOR DE LA ACTIVIDAD
        public string Organizador { get; set; }

        //EXPOSITOR(A) DE LA ACTIVIDAD
        public string Expositor { get; set; }

        //LUGAR DE LA ACTIVIDAD
        public string Lugar { get; set; }

        //COMENTARIOS & DESCRIPCIÓN DE LA ACTIVIDAD
        public string Descripcion { get; set; }

        //DURACIÓN (SE OBTIENE DE HORA DE INICIO Y HORA FINAL)
        public int DuracionMinutos { get; set; }

        //SI EL REGISTRO ES AGREGADO POR UN ESTUDIANTE, SE ENLAZA SU ID
        public int? AgregadoPorEstudiante { get; set; }
    }
}