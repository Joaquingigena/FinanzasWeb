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
        [Route("Listar{id:int}")]
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

        //[HttpGet]
        //[Route("ListarCat")]
        //public async Task<ActionResult<List<Movimiento>>> ListarCat()
        //{

        //    try
        //    {
        //        List<Movimiento> lista = await _repositorio.Listar();



        //        return lista;

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        [HttpPut]
        [Route("Modificar")]
        public async Task<ActionResult> Modificar(MovimientoDTO movimiento)
        {
            try
            {
                var mov = _mapper.Map<Movimiento>(movimiento);

                await _repositorio.Modificar(mov);

                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete]
        [Route("Eliminar")]
        public async Task<ActionResult> Eliminar(MovimientoDTO movimiento)
        {
            try
            {
                var mov = _mapper.Map<Movimiento>(movimiento);

               await _repositorio.Eliminar(mov);

                return Ok(mov);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
