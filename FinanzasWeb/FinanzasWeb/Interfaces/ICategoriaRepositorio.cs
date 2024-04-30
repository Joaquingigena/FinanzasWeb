using FinanzasWeb.Models;

namespace FinanzasWeb.Interfaces
{
    public interface ICategoriaRepositorio
    {
        Task<List<Categoria>> Listar();
        Task<Categoria> Crear(Categoria categoria);
        Task<bool> Elimnar(Categoria categoria);
    }
}
