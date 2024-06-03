using FinanzasWeb.Data;
using FinanzasWeb.Interfaces;
using FinanzasWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanzasWeb.Repository
{
    public class TipoMovimientoRepositorio : ITipoMovimientoRepositorio
    {
        private readonly ApplicationDbContext _context;

        public TipoMovimientoRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TipoMovimiento> Crear(TipoMovimiento tipoMovimiento)
        {
            try
            {
                _context.TipoMovimientos.Add(tipoMovimiento);
                await _context.SaveChangesAsync();

                return tipoMovimiento;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<TipoMovimiento>> Listar()
        {
            try
            {
                return await _context.TipoMovimientos.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
