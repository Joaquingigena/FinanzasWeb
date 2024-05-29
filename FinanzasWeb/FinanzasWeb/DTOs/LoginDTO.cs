namespace FinanzasWeb.DTOs
{
    public class LoginDTO
    {
        public int Id { get; set; }
        public string Correo { get; set; } = null!;
        public string Clave { get; set; } = null!;
    }
}
