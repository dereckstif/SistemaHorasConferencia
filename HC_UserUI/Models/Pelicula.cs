namespace HC_UserUI.Models
{
    public class Pelicula
    {
        //ID DE LA PELICULA
        public int Id { get; set; }

        //PAIS DE LA PELICULA
        public string Pais { get; set; }

        //SEGUNDO PAIS DE LA PELICULA (SI APLICA)
        public string? SegundoPais { get; set; }

        //TITULO DE LA PELICULA
        public string Titulo { get; set; }

        //DIRECTOR DE LA PELICULA
        public string Director { get; set; }

        //ANIO DE ESTRENO DE LA PELICULA
        public int AnioEstreno { get; set; }

        //GENERO DE LA PELICULA
        public string Genero { get; set; }

        //DESCRIPCION/COMENTARIOS DE LA PELICULA
        public string Descripcion { get; set; }

        //DURACIÓN
        public int DuracionMinutos { get; set; }
    }
}