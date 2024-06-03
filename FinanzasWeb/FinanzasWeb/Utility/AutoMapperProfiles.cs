using AutoMapper;
using FinanzasWeb.DTOs;
using FinanzasWeb.Models;

namespace FinanzasWeb.Utility
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {

            CreateMap<CategoriaDTO, Categoria>()
                .ReverseMap();

            CreateMap<TipoMovimientoDTO, TipoMovimiento>();

            CreateMap<UsuarioDTO, Usuario>()
                .ReverseMap();

            CreateMap<Movimiento, MovimientoDTO>()
                .ForMember(ent => ent.DescripcionTipoMovimiento,
                dto => dto.MapFrom(origen => origen.TipoMovimiento.Nombre))
                .ForMember(ent => ent.DescripcionCategoria,
                dto => dto.MapFrom(origen => origen.Categoria.Nombre));

            CreateMap<MovimientoDTO, Movimiento>();




        }
    }
}
