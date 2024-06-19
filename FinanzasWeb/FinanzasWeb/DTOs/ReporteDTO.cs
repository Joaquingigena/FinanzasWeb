namespace FinanzasWeb.DTOs
{
    public class ReporteDTO
    {
        public int idUsuario { get; set; }
        public decimal Balance { get; set; }
        public decimal TotalIngresos { get; set; }
        public decimal TotalGastos { get; set; }
    }
}
