using FinanzasWeb.Models;

namespace FinanzasWeb.Interfaces
{
    public interface ICategoriaRepositorio
    {
        Task<List<Categoria>> Listar(int idUsuario);
        Task<Categoria> Crear(Categoria categoria);
        Task<bool> Eliminar(int id);
    }
}
