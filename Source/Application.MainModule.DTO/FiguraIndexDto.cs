using System;
using System.Collections.Generic;
using Application.MainModule.DTO.Resources;
using Infrastructure.CrossCutting.Resources.Conventions;

namespace Application.MainModule.DTO
{
    [Serializable]
    [MetadataConventions(ResourceType = typeof(FiguraDtoResources))]
    public class FiguraIndexDto
    {
        public IEnumerable<KeyValuePair<int, string>> Tiendas { get; set; }
        public IEnumerable<KeyValuePair<int, string>> Escultores { get; set; }
        public FiguraDto Figura { get; set; }
    }
}