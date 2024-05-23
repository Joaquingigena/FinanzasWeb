using FinanzasWeb.DTOs;
using FinanzasWeb.Models;

namespace FinanzasWeb.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<Usuario>> Listar();
        Task<Usuario> ObtenerUno(int id);
        Task<Usuario> Registrar(Usuario usuario);
        Task<bool> Eliminar(Usuario usuario);
        Task<Usuario> Modificar(Usuario usuario);
        Task<Usuario> Loguear(LoginDTO loginDTO);
    }
}
