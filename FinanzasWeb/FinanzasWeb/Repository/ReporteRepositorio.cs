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
            try
            {
                listaMovimientos = await _context.Movimientos.Where(m => m.UsuarioId == idUsuario).ToListAsync();

                if(fechaInicio!=null && fechaFin!=null) {

                    DateTime fecha_inicio = DateTime.ParseExact(fechaInicio, "yyyy-MM-dd", new CultureInfo("es-AR"));
                    DateTime fecha_fin = DateTime.ParseExact(fechaFin, "yyyy-MM-dd", new CultureInfo("es-AR"));

                    var listaPorFechas= listaMovimientos.Where(m => m.Fecha >= fecha_inicio && m.Fecha <= fecha_fin).ToList();

                    reporte.TotalIngresos = listaPorFechas.Where(m => m.TipoMovimientoId == 1).Sum(m => m.Monto);
                    reporte.TotalGastos = listaPorFechas.Where(m => m.TipoMovimientoId == 2).Sum(m => m.Monto);
                    reporte.Balance = reporte.TotalIngresos - reporte.TotalGastos;
                }
                else
                {
                    reporte.TotalIngresos = listaMovimientos.Where(m => m.TipoMovimientoId == 1).Sum(m => m.Monto);
                    reporte.TotalGastos= listaMovimientos.Where(m => m.TipoMovimientoId == 2).Sum(m => m.Monto);
                    reporte.Balance = reporte.TotalIngresos - reporte.TotalGastos;

                    //Movimientos por mes
                    reporte.MovimientosXMes =  movimientosxMes();
                }

                return reporte;
            }
            catch (Exception ex)
            {

                throw ex;
            }
          
        }

        public  List<MovimientosXmesDTO> movimientosxMes()
        {
            try
            {
                var movimientos=  _context.Movimientos
                    .GroupBy(m => new { m.Fecha.Year, m.Fecha.Month })
                    .Select(g => new MovimientosXmesDTO
                    {
                        Mes= g.Key.Month,
                        Ingresos= g.Where(m=> m.TipoMovimientoId==1).Sum(m=>m.Monto),
                        Egresos = g.Where(m => m.TipoMovimientoId == 2).Sum(m => m.Monto)
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
