using AutoMapper;
using FinanzasWeb.DTOs;
using FinanzasWeb.Interfaces;
using FinanzasWeb.Models;
using FinanzasWeb.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinanzasWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _repositorio;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioRepositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> Crear(UsuarioDTO usuario)
        {
            var user = _mapper.Map<Usuario>(usuario);

            await _repositorio.Registrar(user);

            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>>Listar(){
            
            return await _repositorio.Listar();
        }

        [HttpPut]
        public async Task<ActionResult> Modificar(UsuarioDTO usuario)
        {
            var user = _mapper.Map<Usuario>(usuario);

            await _repositorio.Modificar(user);

            return Ok(user);
        }

        [HttpDelete]
        public async Task<ActionResult> Eliminar(UsuarioDTO usuario)
        {
            var user = _mapper.Map<Usuario>(usuario);

            await _repositorio.Eliminar(user);

            return Ok(user);
        }
    }
}
