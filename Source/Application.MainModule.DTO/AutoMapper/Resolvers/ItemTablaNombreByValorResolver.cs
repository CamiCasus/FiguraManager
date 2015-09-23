using AutoMapper;
using Domain.MainModule.Entities;
using Domain.MainModule.Interfaces.Services;
using Infrastructure.CrossCutting.Cache;
using Infrastructure.CrossCutting.Cache.Core;
using Infrastructure.CrossCutting.Enums;
using Infrastructure.CrossCutting.IoC;
using System.Collections.Generic;
using System.Linq;

namespace Application.MainModule.DTO.AutoMapper.Resolvers
{
    public class ItemTablaNombreByValorResolver : ValueResolver<object, string>
    {
        private readonly string _propertyName;
        private readonly TipoTabla _tipoTabla;
        private readonly IItemTablaService _itemTablaService;
        private static readonly ICacheProvider CacheProvider = new HttpCacheProvider();

        public ItemTablaNombreByValorResolver(string propertyName, TipoTabla tipoTabla)
        {
            _propertyName = propertyName;
            _tipoTabla = tipoTabla;
            _itemTablaService = StructuremapMvc.StructureMapDependencyScope.Container.GetInstance<IItemTablaService>();
        }

        protected override string ResolveCore(object source)
        {
            var itemsTabla = GetItems();
            var valor = GetPropValue(source, _propertyName).ToString();
            var itemTablaActual = itemsTabla.FirstOrDefault(p => p.Valor == valor);
            return itemTablaActual != null ? itemTablaActual.Nombre : string.Empty;
        }

        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }

        private List<ItemTabla> GetItems()
        {
            var keyCache = string.Format("{0}.{1}", CacheTypes.ItemTabla, (int)_tipoTabla);

            if (!CacheProvider.ExistsItem(keyCache))
            {
                var cacheValue = _itemTablaService.Find(p => p.TablaId == (int)_tipoTabla && p.Estado == (int)TipoEstado.Activo).ToList();
                CacheProvider.AddItem(cacheValue, keyCache);
            }
            return CacheProvider.GetItem<List<ItemTabla>>(keyCache);
        }
    }
}
