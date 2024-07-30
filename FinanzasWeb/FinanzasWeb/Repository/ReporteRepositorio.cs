using FinanzasWeb.Data;
using FinanzasWeb.DTOs;
using FinanzasWeb.Interfaces;
using FinanzasWeb.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace FinanzasWeb.Repository
{
    public class ReporteRepositorio : IReporteRepositorio
    {
        private readonly ApplicationDbContext _context;

        public ReporteRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ReporteDTO> Reporte(int idUsuario,string? fechaInicio, string? fechaFin)
        {
            List<Movimiento> listaMovimientos=new List<Movimiento>();
            ReporteDTO reporte= new ReporteDTO();

            List<CategoriaDTO> catXMes= new List<CategoriaDTO>();

            List<Categoria> categorias = new List<Categoria>();

            try
            {
                listaMovimientos = await _context.Movimientos.Where(m => m.UsuarioId == idUsuario)
                    .Include(m => m.Categoria)
                    .ToListAsync();

                if(fechaInicio!=null && fechaFin!=null) {

                    DateTime fecha_inicio = DateTime.ParseExact(fechaInicio, "yyyy-MM-dd", new CultureInfo("es-AR"));
                    DateTime fecha_fin = DateTime.ParseExact(fechaFin, "yyyy-MM-dd", new CultureInfo("es-AR"));

                    var listaPorFechas= listaMovimientos.Where(m => m.Fecha >= fecha_inicio && m.Fecha <= fecha_fin).ToList();

                    reporte.TotalIngresos = (listaPorFechas.Where(m => m.TipoMovimientoId == 1).Sum(m => m.Monto)).ToString();
                    reporte.TotalGastos = (listaPorFechas.Where(m => m.TipoMovimientoId == 2).Sum(m => m.Monto)).ToString();
                    //reporte.Balance = reporte.TotalIngresos - reporte.TotalGastos
                }
                else
                {
                    reporte.TotalIngresos = (listaMovimientos.Where(m => m.TipoMovimientoId == 1).Sum(m => m.Monto)).ToString();
                    reporte.TotalGastos= (listaMovimientos.Where(m => m.TipoMovimientoId == 2).Sum(m => m.Monto)).ToString();
                    reporte.Balance = ((listaMovimientos.Where(m => m.TipoMovimientoId == 1).Sum(m => m.Monto))- (listaMovimientos.Where(m => m.TipoMovimientoId == 2).Sum(m => m.Monto))).ToString();

                    //Categorias
                    var listaCategorias= listaMovimientos.GroupBy(m => m.Categoria.Nombre)
                                         .Select(g => new CatXMesDTO {
                                            Nombre= g.Key,
                                            Ingresos= g.Where(g => g.TipoMovimientoId ==1).Sum(g => g.Monto).ToString(),
                                            Egresos = g.Where(g => g.TipoMovimientoId == 2).Sum(g => g.Monto).ToString(),
                                            
                                         }
                                         ).ToList();

                    reporte.CategoriasXMovimientos = listaCategorias;
                    //Movimientos por mes
                    reporte.MovimientosXMes =  movimientosxMes(idUsuario);
                }

                return reporte;
            }
            catch (Exception ex)
            {

                throw ex;
            }
          
        }

        public  List<MovimientosXmesDTO> movimientosxMes(int idUsuario)
        {
            try
            {
                var movimientos = _context.Movimientos.Where(m => m.UsuarioId == idUsuario)
                    .GroupBy(m => new { m.Fecha.Year, m.Fecha.Month })
                    .Select(g => new MovimientosXmesDTO
                    {
                        Mes = g.Key.Month,
                        Ingresos = (g.Where(m => m.TipoMovimientoId == 1).Sum(m => m.Monto)).ToString(),
                        Egresos = (g.Where(m => m.TipoMovimientoId == 2).Sum(m => m.Monto)).ToString(),
                        BalanceMensual = (g.Where(m => m.TipoMovimientoId == 1).Sum(m => m.Monto) -
                        g.Where(m => m.TipoMovimientoId == 2).Sum(m => m.Monto)).ToString()
                    }
                    ).ToList();

                return movimientos;
            } 
            catch (Exception)
            {

                throw;
            }
        }
    }
}
