using Infrastructure.Data.Core;
using Infrastructure.Data.MainModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;

namespace DataBase.Generator
{
    [TestClass]
    public class DataBaseGenerator
    {
        [TestMethod]
        public void TestCreateDatabaseDevelopment()
        {
            Database.SetInitializer(new DbContextDropCreateDatabaseAlwaysDevelopment<MainModuleContext>());

            PersistenceConfigurator.Configure("SIGCOMT");
            
            var target = new MainModuleContext();
            target.Database.Initialize(true);
        }
    }
}
