namespace FinanzasWeb.Models
{
    public class TipoMovimiento
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public HashSet<Movimiento> Movimientos { get; set; } = new HashSet<Movimiento>();

        public HashSet<Categoria>Categorias { get; set; }=new HashSet<Categoria>();
    }
}
