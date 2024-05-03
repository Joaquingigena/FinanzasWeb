using FinanzasWeb.Data;
using FinanzasWeb.Interfaces;
using FinanzasWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanzasWeb.Repository
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly ApplicationDbContext _context;

        public CategoriaRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Categoria> Crear(Categoria categoria)
        {
            try
            {
                _context.Categorias.Add(categoria);
                await _context.SaveChangesAsync();

                return categoria;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Elimnar(Categoria categoria)
        {
            try
            {
                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Categoria>> Listar()
        {
            try
            {
                return await _context.Categorias.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
