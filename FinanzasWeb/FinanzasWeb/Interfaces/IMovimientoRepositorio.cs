using FinanzasWeb.Models;

namespace FinanzasWeb.Interfaces
{
    public interface IMovimientoRepositorio
    {
        Task<List<Movimiento>> Listar(int idUsuario);
        Task<Movimiento> ObtenerUno(int id);
        Task<Movimiento> Crear(Movimiento movimiento);
        Task<bool> Eliminar(int id);
        Task<Movimiento> Modificar(Movimiento movimiento);
    }
}
