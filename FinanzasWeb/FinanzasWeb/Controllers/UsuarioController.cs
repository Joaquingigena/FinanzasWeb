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

        public UsuarioController(IUsuarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> Listar()
        {
            var lista=await _repositorio.Listar();

            return Ok(lista);
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> Crear(Usuario usuario)
        {
            var user = await _repositorio.Crear(usuario);

            return Ok(user);
        }
    }
}
