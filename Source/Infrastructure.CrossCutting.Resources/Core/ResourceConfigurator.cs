using System.Collections.Generic;

namespace Infrastructure.CrossCutting.Resources.Core
{
    public abstract class ResourceConfigurator
    {
        public static Dictionary<string, ResourceEntry> Resources = null;
        public static bool CacheActive;

        public static void Configure(bool cacheActive)
        {
            CacheActive = cacheActive;
        }
    }
}