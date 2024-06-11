using FinanzasWeb.Data;
using FinanzasWeb.Interfaces;
using FinanzasWeb.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var filasEliminadas= await _context.Movimientos.Where(m => m.Id== id).ExecuteDeleteAsync();

                if(filasEliminadas == 0)
                {
                    return false;
                }

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Movimiento>> Listar(int idUsuario)
        {
            return await _context.Movimientos
                .Include(m => m.Categoria)
                .Include(m => m.TipoMovimiento)
                .Where(m => m.UsuarioId== idUsuario)
                .ToListAsync();
        }

        public async Task<Movimiento> Modificar(Movimiento movimiento)
        {
            try
            {
                _context.Movimientos.Update(movimiento);
                await _context.SaveChangesAsync();

                return movimiento;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Movimiento> ObtenerUno(int id)
        {
            try
            {
               var movimiento= await _context.Movimientos.FirstOrDefaultAsync(m => m.Id == id);

                return movimiento;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
