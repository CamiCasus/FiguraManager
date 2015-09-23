namespace Infrastructure.Data.Core
{
    public abstract class PersistenceConfigurator
    {
        public static string ConnectionStringKey;

        public static string DefaultSchemaDatabase;

        public static void Configure(string connectionStringKey, string defaultSchemaDatabase = "dbo")
        {
            ConnectionStringKey = connectionStringKey;
            DefaultSchemaDatabase = defaultSchemaDatabase;
        }
    }
}
