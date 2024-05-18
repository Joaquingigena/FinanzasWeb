using AutoMapper;
using FinanzasWeb.DTOs;
using FinanzasWeb.Models;

namespace FinanzasWeb.Utility
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {

            CreateMap<CategoriaDTO, Categoria>();

            CreateMap<TipoMovimientoDTO, TipoMovimiento>();

            CreateMap<UsuarioDTO, Usuario>();

            CreateMap<MovimientoDTO, Movimiento>()
                .ReverseMap();
                //.ForMember(ent => ent.TipoMovimiento,
                //dto => dto.MapFrom(origen => origen.TipoMovimientoId))
                //.ForMember(ent => ent.Categoria,
                //dto => dto.MapFrom(origen => origen.CategoriaId))
                //.ForMember(ent => ent.Usuario,
                //dto => dto.MapFrom(origen => origen.UsuarioId));


        }
    }
}
