using Infrastructure.Data.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using Infrastructure.CrossCutting.IoC;

namespace Infrastructure.Data.MainModule.Test.Core
{
    [TestClass]
    public class InitializeTest
    {
        [AssemblyInitialize]
        public static void GenerarSnapShotDB(TestContext testContext)
        {
            Database.SetInitializer<MainModuleContext>(null);
            PersistenceConfigurator.Configure("SIGCOMT");

            StructuremapMvc.Start();

            var contextDB = new MainModuleContext();
            contextDB.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, @"
                IF DB_ID('SigcomtDB_Snap') IS NOT NULL 
                    DROP DATABASE SigcomtDB_Snap;

                CREATE DATABASE SigcomtDB_Snap ON
                    ( NAME = SigcomtDB, FILENAME = 'D:\Temp\SigcomtDB_Snapshot.ss' )
                 AS SNAPSHOT OF SigcomtDB;
            ");
        }

        [AssemblyCleanup]
        public static void DeleteSnapshot()
        {
            StructuremapMvc.End();

            var contextDB = new MainModuleContext();
            contextDB.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, @"
                USE master                
                DROP DATABASE SigcomtDB_Snap;
            ");
        }
    }
}
