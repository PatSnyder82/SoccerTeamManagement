using AutoFixture;
using Core.Models.Lookups;

namespace UnitTests.EF.Fixtures
{
    public class CountryServiceFixture : TestFixtureBase
    {
        #region Constructor

        public CountryServiceFixture()
        {
            _context.AddRange(
                new Country { Value = "bob", Alpha2Code = "bob", Alpha3Code = "bob", IsDisabled = false, Text = "bob" },
                new Country { Value = "bob", Alpha2Code = "bob", Alpha3Code = "bob", IsDisabled = false, Text = "bob" });

            _context.SaveChanges();
        }

        #endregion Constructor
    }
}