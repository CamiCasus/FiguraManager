using Presentation.Core;
using System.Web.Optimization;

namespace Presentation.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            if (!WebUtils.IsDebug())
            {
                BundleTable.EnableOptimizations = true;
            }
        }
    }
}
