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



        [HttpPost]
        [Route("Crear")]
        public async Task<ActionResult<MovimientoDTO>> Crear(MovimientoDTO movimiento)
        {
            try
            {
                var mov = _mapper.Map<Movimiento>(movimiento);

                await _repositorio.Crear(mov);

                return Ok(movimiento);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("Listar/{id:int}")]
        public async Task<ActionResult<List<MovimientoDTO>>> Listar(int id)
        {

            try
            {
                var lista = await _repositorio.Listar(id);

                return _mapper.Map<List<MovimientoDTO>>(lista);

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        [Route("Modificar")]
        public async Task<ActionResult> Modificar(MovimientoDTO movimiento)
        {
            try
            {
                var mov = _mapper.Map<Movimiento>(movimiento);

                await _repositorio.Modificar(mov);

                return Ok(movimiento);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<ActionResult> Eliminar(int id )
        {
            try
            {
               bool eliminado=await _repositorio.Eliminar(id);
               
                if(eliminado == false)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
