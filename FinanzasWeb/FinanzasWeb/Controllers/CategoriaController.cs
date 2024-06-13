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
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepositorio _repositorio;
        private readonly IMapper _mapper;

        public CategoriaController(ICategoriaRepositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Agregar")]
        public async Task<ActionResult> Crear(CategoriaDTO categoria)
        {
            try
            {
                  var cat = _mapper.Map<Categoria>(categoria);

            await _repositorio.Crear(cat);

            return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("Listar/{id:int}")]
        public async Task<ActionResult<List<CategoriaDTO>>> Listar(int id)
        {
            try
            {
                var lista = await _repositorio.Listar(id);

                return _mapper.Map<List<CategoriaDTO>>(lista);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<ActionResult> Eliminar(int id)
        {
            try
            {
                bool eliminado = await _repositorio.Eliminar(id);

                if (eliminado == false)
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
