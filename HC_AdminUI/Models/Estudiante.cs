using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HC_AdminUI.Models
{
    public class Estudiante
    {
        //ID DEL ESTUDIANTE
        public int Id { get; set; }

        //NOMBRE DEL ESTUDIANTE
        public string Nombre { get; set; }

        //CARNE DEL ESTUDIANTE
        public string Carne { get; set; }

        //CORREO DEL ESTUDIANTE
        [BindProperty, DataType(DataType.EmailAddress)]
        public string Correo { get; set; }

        //ENFASIS DE COMUNICACIÓN DEL ESTUDIANTE
        public string Enfasis { get; set; }

        //MINUTOS REGISTRADOS DE HORAS CONFERENCIA
        //50 HORAS CONFERENCIA = 3000 MINUTOS
        public int MinutosRegistrados { get; set; }

        //MINUTOS REGISTRADOS DE HORAS CONFERENCIA
        public int ActividadesRegistradas { get; set; }
    }
}