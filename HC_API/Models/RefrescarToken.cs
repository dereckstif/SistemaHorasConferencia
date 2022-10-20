namespace HC_API.Models
{
    public class RefrescarToken
    {
        public int Id { get; set; }

        public string Token { get; set; } = string.Empty;

        public DateTime Creado { get; set; } = DateTime.Now;

        public DateTime Expirado { get; set; }
    }
}