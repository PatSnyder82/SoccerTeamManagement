using Microsoft.EntityFrameworkCore;
using Core.Models.Lookups;
using Infrastructure;

namespace UnitTests.EF {

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
                            new Country { Alpha2Code = "22" },
                            new Country { Alpha2Code = "33"});

                        context.SaveChanges();
                    }

                    _databaseInitialized = true;
                }
            }
        }

        public ApplicationDbContext CreateContext() {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(ConnectionString, assembly => assembly.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)).Options;
            var context = new ApplicationDbContext(options);

            return context;
        }
    }
}
