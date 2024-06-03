using AutoMapper;
using FinanzasWeb.DTOs;
using FinanzasWeb.Interfaces;
using FinanzasWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinanzasWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoMovimientoController : ControllerBase
    {
        private readonly ITipoMovimientoRepositorio _repositorio;
        private readonly IMapper _mapper;

        public TipoMovimientoController(ITipoMovimientoRepositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        [HttpPost]
        
        public async Task<ActionResult> Crear(TipoMovimientoDTO tipoMov)
        {
            try
            {
                var tipo = _mapper.Map<TipoMovimiento>(tipoMov);

                await _repositorio.Crear(tipo);

                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<ActionResult<List<TipoMovimiento>>> Listar()
        {
            try
            {
                return await _repositorio.Listar();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
