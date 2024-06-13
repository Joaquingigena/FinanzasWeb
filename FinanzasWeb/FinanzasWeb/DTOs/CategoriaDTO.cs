using System.ComponentModel.DataAnnotations;

namespace FinanzasWeb.DTOs
{
    public class CategoriaDTO
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Nombre { get; set; } = null!;
        public int TipoMovimientoId { get; set; }
        public int UsuarioId { get; set; }
    }
}
