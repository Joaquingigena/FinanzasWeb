using FinanzasWeb.DTOs;
using FinanzasWeb.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinanzasWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteController : ControllerBase
    {
        private readonly IReporteRepositorio _repositorio;

        public ReporteController(IReporteRepositorio repositorio) {
            _repositorio = repositorio;
        }

        [HttpGet]
        [Route("Listar/{idUsuario:int}")]
        public async Task<ActionResult<ReporteDTO>> Reporte(int idUsuario, string? fechaInicio, string? fechaFin)
        {
            try
            {
                var reporte =await _repositorio.Reporte(idUsuario, fechaInicio, fechaFin);

                return Ok(reporte);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
