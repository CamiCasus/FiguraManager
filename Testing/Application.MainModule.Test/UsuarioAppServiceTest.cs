using System.Linq;
using Application.MainModule.DTO;
using Application.MainModule.DTO.AutoMapper;
using Application.MainModule.Interfaces;
using Domain.MainModule.Entities;
using Domain.MainModule.Resources;
using Infrastructure.CrossCutting.IoC;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.MainModule.Test
{
    [TestClass]
    public class UsuarioAppServiceTest
    {
        [TestMethod]
        public void TestAppService()
        {
            AutoMapperConfiguration.Configure();

            var rol = new Rol
            {
                Id = 1,
                Nombre = "Administrador",
                Estado = 1
            };


            var usuario = new UsuarioDto
            {
                UserName = "Ejemplito2",
                Password = "password",
                Email = "email@aaa.c",
                RolId = rol.Id
            };

            //var serviceRol = StructuremapMvc.StructureMapDependencyScope.Container.GetInstance<IRolAppService>();
            //serviceRol.Create(rol);
            
            var service = StructuremapMvc.StructureMapDependencyScope.Container.GetInstance<IUsuarioAppService>();
            var logRegistro = service.Create(usuario);

            Assert.AreEqual(logRegistro.Errors.First(), UsuarioValidationResources.UserNameMustBeUnique);
        }
    }
}
