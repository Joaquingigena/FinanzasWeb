using FinanzasWeb.Data;
using FinanzasWeb.Interfaces;
using FinanzasWeb.Models;

namespace FinanzasWeb.Repository
{
    public class MovimientoRepositorio : IMovimientoRepositorio
    {
        private readonly ApplicationDbContext _context;

        public MovimientoRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Movimiento> Crear(Movimiento movimiento)
        {
            try
            {
                _context.Movimientos.Add(movimiento);
                await _context.SaveChangesAsync();

                return movimiento;
            }
            catch (Exception)
            {
                throw;

            }
        }

        public Task<bool> Elimnar(Movimiento movimiento)
        {
            throw new NotImplementedException();
        }

        public Task<List<Movimiento>> Listar()
        {
            throw new NotImplementedException();
        }

        public Task<Movimiento> Modificar(Movimiento movimiento)
        {
            throw new NotImplementedException();
        }

        public Task<Movimiento> ObtenerUno(int id)
        {
            throw new NotImplementedException();
        }
    }
}
