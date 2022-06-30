using AutoFixture;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace UnitTests.EF.Fixtures
{
    public class TestFixtureBase : IDisposable
    {
        #region Properties

        private readonly string _connectionString = @"Server=(localdb)\mssqllocaldb;Trusted_Connection=True;Database=";

        protected readonly ApplicationDbContext _context;

        protected readonly Fixture _autoFixture;

        #endregion Properties

        #region Constructor

        public TestFixtureBase()
        {
            _connectionString += this.GetType().Name;
            _context = CreateContext(_connectionString);

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            _autoFixture = ConfigureAutoFixture();
        }

        #endregion Constructor

        #region Private Methods

        private ApplicationDbContext CreateContext(string connectionString)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(connectionString, assembly => assembly
                .MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)).Options;
            return new ApplicationDbContext(options);
        }

        private Fixture ConfigureAutoFixture()
        {
            var autoFixture = new Fixture();

            autoFixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            autoFixture.Behaviors.Add(new OmitOnRecursionBehavior());

            return autoFixture;
        }

        #endregion Private Methods

        #region Public Methods

        public Fixture AutoFixture
        { get { return _autoFixture; } private set { } }

        public ApplicationDbContext Context
        { get { return _context; } private set { } }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        public LoggerFactory LoggerFactory
        { get { return new LoggerFactory(); } set { } }

        #endregion Public Methods
    }
}