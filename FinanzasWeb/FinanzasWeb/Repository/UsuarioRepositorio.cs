using FinanzasWeb.Data;
using FinanzasWeb.Interfaces;
using FinanzasWeb.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanzasWeb.Repository
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<List<Usuario>> Listar()
        {
            try
            {
                return await _context.Usuarios.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Usuario> ObtenerUno(int id)
        {
            try
            {
                Usuario usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);

                return usuario;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Usuario> Crear(Usuario usuario)
        {
            try
            {
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                return usuario;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<bool> Elimnar(Usuario usuario)
        {
            try
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Usuario> Modificar(Usuario usuario)
        {
             _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }
    }
}
