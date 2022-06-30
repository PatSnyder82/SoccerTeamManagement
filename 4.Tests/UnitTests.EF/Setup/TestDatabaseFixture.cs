using Core.Models.Lookups;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;

namespace UnitTests.EF.Setup
{

    public class TestDatabaseFixture
    {
        private const string ConnectionString = @"Server=(localdb)\mssqllocaldb;Database=TestingDB;Trusted_Connection=True;";

        private static readonly object _lock = new();
        private static bool _databaseInitialized;

        public TestDatabaseFixture()
        {
            
            lock (_lock)
            {
                if (!_databaseInitialized)
                {
                    using (var context = CreateContext())
                    {
                        context.Database.EnsureDeleted();
                        context.Database.EnsureCreated();

                        context.AddRange(
                            new Country { Value = "bob", Alpha2Code = "bob", Alpha3Code = "bob", IsDisabled = false, Text = "bob" },
                            new Country { Value = "bob", Alpha2Code = "bob", Alpha3Code = "bob", IsDisabled = false, Text = "bob" });

                        context.SaveChanges();
                    }

                    _databaseInitialized = true;
                }
            }
        }

        #region Public Methods

        public ApplicationDbContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(ConnectionString, assembly => assembly.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)).Options;
            return new ApplicationDbContext(options);
        }

        #endregion

    }
}
