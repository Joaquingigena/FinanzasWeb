using AutoMapper;
using FinanzasWeb.DTOs;
using FinanzasWeb.Models;

namespace FinanzasWeb.Utility
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() {

            CreateMap<CategoriaDTO, Categoria>();
            
            CreateMap<TipoMovimientoDTO, TipoMovimiento>();

            CreateMap<UsuarioDTO, Usuario>();

            CreateMap<MovimientoDTO, Movimiento>();
                //.ForMember(ent => ent.TipoMovimiento,
                //dto => dto.MapFrom(origen => origen.TipoMovimientoId));
        }
    }
}
