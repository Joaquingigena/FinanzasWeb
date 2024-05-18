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
    public class MovimientoController : ControllerBase
    {
        private readonly IMovimientoRepositorio _repositorio;
        private readonly IMapper _mapper;

        public MovimientoController(IMovimientoRepositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        //TODO Falta corregir mapeo de Movimiento a MovimientoDTO

        [HttpPost]
        public async Task<ActionResult<MovimientoDTO>> Crear(MovimientoDTO movimiento)
        {
            var mov = _mapper.Map<Movimiento>(movimiento);

            await _repositorio.Crear(mov);

            return Ok(movimiento);
        }

        [HttpGet]
        public async Task<ActionResult<List<MovimientoDTO>>> Listar()
        {

            var lista= await _repositorio.Listar();

            return _mapper.Map<List<MovimientoDTO>>(lista);
        }

        [HttpPut]
        public async Task<ActionResult> Modificar(MovimientoDTO movimiento)
        {
            var mov = _mapper.Map<Movimiento>(movimiento);

            await _repositorio.Modificar(mov);

            return Ok(mov);
        }

        [HttpDelete]
        public async Task<ActionResult> Eliminar(MovimientoDTO movimiento)
        {
            var mov = _mapper.Map<Movimiento>(movimiento);

            await _repositorio.Eliminar(mov);

            return Ok(mov);
        }
    }
}
