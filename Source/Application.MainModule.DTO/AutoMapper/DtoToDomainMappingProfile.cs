using System;
using AutoMapper;
using Domain.MainModule.Entities;
using Infrastructure.CrossCutting.Common;

namespace Application.MainModule.DTO.AutoMapper
{
    public class DtoToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DtoToDomainMappingProfile"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<UsuarioDto, Usuario>()
                .ForMember(p => p.Password, x => x.Condition(p => p.Id == 0))
                .ForMember(p => p.Password, x => x.UseValue(Encriptador.Encriptar(Guid.NewGuid().ToString())))
                .ForMember(p => p.UsuarioModificacion, x => x.MapFrom(p => p.UsuarioRegistro))
                .ForMember(p => p.FechaModificacion, x => x.MapFrom(p => DateTime.UtcNow))
                .ForMember(p => p.FechaCreacion, x => x.Condition(p => p.Id == 0))
                .ForMember(p => p.FechaCreacion, x => x.MapFrom(p => DateTime.UtcNow))
                .ForMember(p => p.UsuarioCreacion, x => x.Condition(p => p.Id == 0))
                .ForMember(p => p.UsuarioCreacion, x => x.MapFrom(p => p.UsuarioRegistro));

            Mapper.CreateMap<UsuarioDto, RolUsuario>()
                .ForMember(p => p.UsuarioId, x => x.MapFrom(p => p.Id));

            Mapper.CreateMap<RolDto, Rol>();
            Mapper.CreateMap<FiguraDto, Figura>()
                .ForMember(p => p.FechaPedido, x => x.MapFrom(p => DateTime.Parse(p.FechaPedido)))
                .ForMember(p => p.FechaLlegada,
                    x => x.MapFrom(p => p.FechaLlegada != null ? DateTime.Parse(p.FechaLlegada) : default(DateTime?)))
                .ForMember(p => p.FechaRelease, x => x.MapFrom(p => DateTime.Parse(p.FechaRelease)));
        }
    }
}
