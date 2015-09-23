using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;

namespace Infrastructure.Data.Core.Context
{
    public abstract class DbContextBase : DbContext, IDbContext
    {
        protected DbContextBase()
            : this(PersistenceConfigurator.ConnectionStringKey)
        {
        }

        protected DbContextBase(string connectionStringName)
            : base(connectionStringName)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(PersistenceConfigurator.DefaultSchemaDatabase);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);

            MapEntitiesFromMappingConfigurations(modelBuilder);
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                string msg = dbEx.EntityValidationErrors.Aggregate(
                    dbEx.Message, (current1, validationErrors) =>
                        validationErrors.ValidationErrors.Aggregate(
                            current1, (current, validationError) =>
                                current + (string.Format(" Class: {0}, Property: {1}, Error: {2}",
                                           validationErrors.Entry.Entity.GetType().FullName,
                                           validationError.PropertyName,
                                           validationError.ErrorMessage))));

                throw new Exception(msg);
            }
        }

        protected abstract void MapEntitiesFromMappingConfigurations(DbModelBuilder modelBuilder);
    }
}
