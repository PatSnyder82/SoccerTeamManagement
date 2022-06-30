using AutoFixture;
using Services.Abstractions;
using Services.Services;
using UnitTests.EF.Fixtures;

namespace UnitTests.EF
{
    public class ServiceTestBase
    {
        #region Properties

        protected readonly ISoccerManagementService Sut;

        protected readonly Fixture AutoFixture;

        #endregion Properties

        #region Constructor

        public ServiceTestBase(TestFixtureBase fixture)
        {
            Sut = new SoccerManagementService(fixture.Context, fixture.LoggerFactory);
            AutoFixture = fixture.AutoFixture;
        }

        #endregion Constructor
    }
}