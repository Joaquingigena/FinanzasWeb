using FinanzasWeb.DTOs;

namespace FinanzasWeb.Interfaces
{
    public interface IReporteRepositorio
    {
        public Task<ReporteDTO> Reporte(int idUsuario,string? fechaInicio,string? fechaFin);
    }
}
