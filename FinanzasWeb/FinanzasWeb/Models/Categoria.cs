namespace FinanzasWeb.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int TipoMovimientoId { get; set; }
        public TipoMovimiento TipoMovimiento { get; set; } = null!;
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;
        public HashSet<Movimiento> Movimientos { get; set; } = new HashSet<Movimiento>();

    }
}
