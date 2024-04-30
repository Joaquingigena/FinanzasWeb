namespace FinanzasWeb.Models
{
    public class Movimiento
    {
        public int Id { get; set; }
        //public int UsuarioId { get; set; }
        //public Usuario Usuario { get; set; }
        //public int TipoMovimientoId { get; set; }
       // public TipoMovimiento TipoMovimiento { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public DateTime Fecha { get; set; }
    }
}
