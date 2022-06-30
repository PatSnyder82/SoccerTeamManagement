using AutoFixture;
using Core.Models.Lookups;

namespace UnitTests.EF.Fixtures
{
    public class StateServiceFixture : TestFixtureBase
    {
        #region Constructor

        public StateServiceFixture()
        {
            _context.AddRange(
                new State { Value = "bob", Alpha2Code = "bob", IsDisabled = false, Text = "bob" },
                new State { Value = "bob", Alpha2Code = "bob", IsDisabled = false, Text = "bob" });

            _context.SaveChanges();
        }

        #endregion Constructor
    }
}