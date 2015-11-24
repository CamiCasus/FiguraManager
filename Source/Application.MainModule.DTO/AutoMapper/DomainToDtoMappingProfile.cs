using System;
using System.Linq;
using AutoMapper;
using Domain.MainModule.Entities;

namespace Application.MainModule.DTO.AutoMapper
{
    public class DomainToDtoMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToDtoMappingProfile"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Usuario, UsuarioLoginDto>()
               .ForMember(d => d.RolId, x => x.MapFrom(p => p.RolUsuarioList.FirstOrDefault().RolId))
               .ForMember(d => d.RolNombre, x => x.MapFrom(p => p.RolUsuarioList.FirstOrDefault().Rol.Nombre));

            Mapper.CreateMap<Usuario, UsuarioDto>()
                .ForMember(d => d.RolId, x => x.MapFrom(p => p.RolUsuarioList.FirstOrDefault().RolId));

            Mapper.CreateMap<Usuario, UsuarioPaginationDto>()
                .ForMember(d => d.RolNombre, x => x.MapFrom(p => p.RolUsuarioList.FirstOrDefault().Rol.Nombre));

            Mapper.CreateMap<Formulario, FormularioDto>();
            Mapper.CreateMap<PermisoFormulario, PermisoFormularioDto>();
            Mapper.CreateMap<Rol, RolDto>();
            Mapper.CreateMap<Figura, FiguraDto>()
                .ForMember(p => p.FechaPedido, x => x.MapFrom(p => p.FechaPedido.ToString("yyyy-MM-dd")))
                .ForMember(p => p.FechaLlegada,
                    x =>
                        x.MapFrom(
                            p => p.FechaLlegada != null ? p.FechaLlegada.Value.ToString("yyyy-MM-dd") : string.Empty))
                .ForMember(p => p.FechaEnvio,
                    x =>
                        x.MapFrom(
                            p => p.FechaEnvio != null ? p.FechaEnvio.Value.ToString("yyyy-MM-dd") : string.Empty))
                .ForMember(p => p.FechaRelease, x => x.MapFrom(p => p.FechaRelease.ToString("yyyy-MM-dd")))
                .ForMember(p => p.Imagen, x => x.Ignore())
                .ForMember(p => p.RutaImagen, x => x.MapFrom(q => q.Imagen));
        }
    }
}
