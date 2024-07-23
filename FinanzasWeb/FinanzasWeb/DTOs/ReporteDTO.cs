namespace FinanzasWeb.DTOs
{
    public class ReporteDTO
    {
        public int idUsuario { get; set; }
        public string? Balance { get; set; }
        public string? TotalIngresos { get; set; }
        public string? TotalGastos { get; set; }
        public List<MovimientosXmesDTO> MovimientosXMes { get; set; } = new List<MovimientosXmesDTO>();

        public List<CatXMesDTO> CategoriasXMovimientos { get; set; } = new List<CatXMesDTO>();
    }
}
