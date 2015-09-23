using Domain.MainModule.Entities;
using Infrastructure.Data.Core.Context;
using Infrastructure.Data.MainModule.Mapping;
using System.Data.Entity;

namespace Infrastructure.Data.MainModule
{
    public class MainModuleContext : DbContextBase
    {
        #region Mapping

        protected override void MapEntitiesFromMappingConfigurations(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new FormularioMap());
            modelBuilder.Configurations.Add(new ItemTablaMap());
            modelBuilder.Configurations.Add(new PermisoFormularioMap());
            modelBuilder.Configurations.Add(new PermisoFormularioRolMap());
            modelBuilder.Configurations.Add(new PermisoFormularioUsuarioMap());
            modelBuilder.Configurations.Add(new RolMap());
            modelBuilder.Configurations.Add(new RolUsuarioMap());
            modelBuilder.Configurations.Add(new TablaMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new FiguraMap());
        }

        #endregion

        #region DbSet

        public DbSet<Formulario> Formularios { get; set; }
        public DbSet<ItemTabla> ItemTablas { get; set; }
        public DbSet<PermisoFormulario> PermisoFormularios { get; set; }
        public DbSet<PermisoFormularioRol> PermisoFormularioRoles { get; set; }
        public DbSet<PermisoFormularioUsuario> PermisoFormularioUsuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<RolUsuario> RolesUsuarios { get; set; }
        public DbSet<Tabla> Tablas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Figura> Figuras { get; set; }

        #endregion
    }
}
