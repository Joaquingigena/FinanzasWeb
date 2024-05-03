using System.ComponentModel.DataAnnotations;

namespace FinanzasWeb.DTOs
{
    public class TipoMovimientoDTO
    {
        [MaxLength(100)]
        public string Nombre { get; set; } = null!;
    }
}
