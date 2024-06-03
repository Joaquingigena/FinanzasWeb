using FinanzasWeb.Models;
using System.ComponentModel.DataAnnotations;

namespace FinanzasWeb.DTOs
{
    public class MovimientoDTO
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int TipoMovimientoId { get; set; }
        public string? DescripcionTipoMovimiento { get; set; } 
        public string? Descripcion { get; set; }
        public decimal Monto { get; set; }
        public int CategoriaId { get; set; }
        public string? DescripcionCategoria { get; set; }
        public DateTime Fecha { get; set; }
    }
}
