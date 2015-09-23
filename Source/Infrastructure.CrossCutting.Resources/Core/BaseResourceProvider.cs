using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.CrossCutting.Resources.Core
{
   public abstract class BaseResourceProvider : IResourceProvider
    {
        private static readonly object LockResources = new object();

        /// <summary>
        /// Returns a single resource for a specific culture
        /// </summary>
        /// <param name="name">Resorce name (ie key)</param>
        /// <param name="culture">Culture code</param>
        /// <returns>Resource</returns>
        public string GetResource(string name, string culture)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Resource name cannot be null or empty.");

            if (string.IsNullOrWhiteSpace(culture))
                throw new ArgumentException("Culture name cannot be null or empty.");

            // normalize
            //culture = culture.ToLowerInvariant();

            if (ResourceConfigurator.CacheActive && ResourceConfigurator.Resources == null)
            {
                // Fetch all resources
                lock (LockResources)
                {
                    if (ResourceConfigurator.Resources == null)
                    {
                        ResourceConfigurator.Resources = ReadResources().ToDictionary(r => string.Format("{0}.{1}", r.Idioma.ToLowerInvariant(), r.Codigo));
                    }
                }
            }

            if (ResourceConfigurator.CacheActive)
            {
                if (ResourceConfigurator.Resources.Any(p => p.Key == string.Format("{0}.{1}", culture, name)))
                {
                    var resourceCache = ResourceConfigurator.Resources[string.Format("{0}.{1}", culture, name)];

                    if (resourceCache != null)
                    {
                        return resourceCache.Valor;
                    }
                }
                return string.Empty;
            }

            var resource = ReadResource(name, culture);

            if (resource != null)
            {
                return resource.Valor;
            }
            return string.Empty;
        }

        public string GetResource(string prefix, string name, string culture)
        {
            return GetResource(string.Format("{0}_{1}", prefix, name), culture);
        }

        /// <summary>
        /// Returns all resources for all cultures. (Needed for caching)
        /// </summary>
        /// <returns>A list of resources</returns>
        protected abstract IList<ResourceEntry> ReadResources();

        /// <summary>
        /// Returns a single resource for a specific culture
        /// </summary>
        /// <param name="name">Resorce name (ie key)</param>
        /// <param name="culture">Culture code</param>
        /// <returns>Resource</returns>
        protected abstract ResourceEntry ReadResource(string name, string culture);
    }
}