using FinanzasWeb.Data;
using FinanzasWeb.DTOs;
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

        public async Task<Usuario> Registrar(Usuario usuario)
        {
            try
            {
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                await CategoriasXdefecto(usuario.Id);

                return usuario;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<bool> Eliminar(Usuario usuario)
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

        public async Task<Usuario> Loguear(LoginDTO loginDTO)
        {
            Usuario user= await _context.Usuarios.FirstOrDefaultAsync(u => u.Clave == loginDTO.Clave && u.Email == loginDTO.Correo);

            return user;
            
        }

        public async Task CategoriasXdefecto(int idUsuario)
        {
            try
            {
                List<Categoria> categorias = new List<Categoria>
                {
                    new Categoria { UsuarioId = idUsuario,Nombre="Sueldo",TipoMovimientoId=1},
                    new Categoria {UsuarioId = idUsuario,Nombre="Inversion",TipoMovimientoId=1},
                    new Categoria {UsuarioId = idUsuario,Nombre="Otro",TipoMovimientoId=1},

                    new Categoria {UsuarioId = idUsuario,Nombre="Alquiler",TipoMovimientoId=2},
                    new Categoria {UsuarioId = idUsuario,Nombre="Comida",TipoMovimientoId=2},
                    new Categoria {UsuarioId = idUsuario,Nombre="Ropa",TipoMovimientoId=2}
                };

                await _context.Categorias.AddRangeAsync(categorias);

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
