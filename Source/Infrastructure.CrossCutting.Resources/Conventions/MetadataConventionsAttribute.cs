using System;

namespace Infrastructure.CrossCutting.Resources.Conventions
{
    public class MetadataConventionsAttribute : Attribute
    {
        public Type ResourceType { get; set; }
    }
}