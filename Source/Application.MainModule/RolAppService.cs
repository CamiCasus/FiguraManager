using Application.Core;
using Application.MainModule.DTO;
using Application.MainModule.Interfaces;
using Domain.MainModule.Entities;
using Domain.MainModule.Interfaces.Services;
using Infrastructure.Data.Core.UoW;
using System.Collections.Generic;

namespace Application.MainModule
{
    public class RolAppService : AppService, IRolAppService
    {
        private readonly IRolService _rolService;

        public RolAppService(IRolService rolService, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _rolService = rolService;
        }

        public IEnumerable<RolDto> GetActivosOrdenadosPorNombre()
        {
            var entityList = _rolService.GetActivosOrdenadosPorNombreAsc();
            var entityDtoList = MapperHelper.Map<IEnumerable<Rol>, IEnumerable<RolDto>>(entityList);

            return entityDtoList;
        }
    }
}
