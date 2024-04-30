namespace FinanzasWeb.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public HashSet<Movimiento> Movimientos { get; set; } = new HashSet<Movimiento>();

    }
}
