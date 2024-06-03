using FinanzasWeb.Models;

namespace FinanzasWeb.Interfaces
{
    public interface ITipoMovimientoRepositorio
    {
        Task<TipoMovimiento> Crear(TipoMovimiento tipoMovimiento);
        Task<List<TipoMovimiento>> Listar();
    }
}
