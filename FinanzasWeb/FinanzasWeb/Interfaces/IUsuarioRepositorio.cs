using FinanzasWeb.Models;

namespace FinanzasWeb.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<Usuario>> Listar();
        Task<Usuario> ObtenerUno(int id);
        Task<Usuario> Crear(Usuario usuario);
        Task<bool> Elimnar(Usuario usuario);
        Task<Usuario> Modificar(Usuario usuario);
    }
}
