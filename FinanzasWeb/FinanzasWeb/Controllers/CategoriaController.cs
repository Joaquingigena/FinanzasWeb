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
        public async Task<ActionResult> Crear(CategoriaDTO categoria)
        {
            var cat = _mapper.Map<Categoria>(categoria);

            await _repositorio.Crear(cat);

            return Ok();
        }
    }
}
