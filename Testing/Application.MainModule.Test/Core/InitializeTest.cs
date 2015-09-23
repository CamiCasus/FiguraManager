using Infrastructure.CrossCutting.IoC;
using Infrastructure.Data.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.MainModule.Test.Core
{
    [TestClass]
    public class InitializeTest
    {
        [AssemblyInitialize]
        public static void GenerarSnapShotDb(TestContext testContext)
        {
            PersistenceConfigurator.Configure("SIGCOMT");

            StructuremapMvc.Start();
        }

        [AssemblyCleanup]
        public static void DeleteSnapshot()
        {
            StructuremapMvc.End();
        }
    }
}
