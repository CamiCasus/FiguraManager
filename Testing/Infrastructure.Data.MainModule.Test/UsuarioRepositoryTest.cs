using Domain.MainModule.Interfaces.RepositoryContracts;
using Infrastructure.CrossCutting.IoC;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Infrastructure.Data.MainModule.Test
{
    [TestClass]
    public class UsuarioRepositoryTest
    {
        [TestMethod]
        public void TestRepository()
        {
            var repository = StructuremapMvc.StructureMapDependencyScope.Container.GetInstance<IUsuarioRepository>();
            var count = repository.Count(p => p.UserName == "Admin");

            Assert.AreNotEqual(0, count);
        }
    }
}
