using FinanzasWeb.Models;

namespace FinanzasWeb.Interfaces
{
    public interface IMovimientoRepositorio
    {
        Task<List<Movimiento>> Listar();
        Task<Movimiento> ObtenerUno(int id);
        Task<Movimiento> Crear(Movimiento movimiento);
        Task<bool> Elimnar(Movimiento movimiento);
        Task<Movimiento> Modificar(Movimiento movimiento);
    }
}
