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

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var filasEliminadas = await _context.Categorias.Where(cat => cat.Id == id).ExecuteDeleteAsync();

                if (filasEliminadas == 0)
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

        public async Task<List<Categoria>> Listar(int idUsuario)
        {
            try
            {
                return await _context.Categorias.Where(cat => cat.UsuarioId == idUsuario).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
