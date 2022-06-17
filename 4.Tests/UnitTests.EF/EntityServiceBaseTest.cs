using Xunit;
using System.Linq;
using Core.Models.Lookups;
using Services.Services;
using Services.Abstractions;

namespace UnitTests.EF {
    public class EntityServiceBaseTest : IClassFixture<TestDatabaseFixture>{
        
        private readonly ICountryService _sut;

        public EntityServiceBaseTest(TestDatabaseFixture testDatabaseFixture)
        {
            var context = testDatabaseFixture.CreateContext();
            _sut = new CountryService(context, null);
        }
        
        [Fact]
        public void Add()
        {
            //Arrange
            var filterColumn = "Value";
            var filterQuery = "United States999";
            var totalCount = _sut.GetAll().Result.Count();
            var countryCount = _sut.GetAll(null,null,filterColumn, filterQuery).Result.Count();

            //Act
            var result1 = _sut.Create(getCountry(filterQuery)).Result;
            var result2 = _sut.GetAll(null, null, filterColumn, filterQuery).Result.Count();

            //Assert
            Assert.True(result1);
        }

        public static Country getCountry(string value = "United States") {

            return new Country {
                Text = value,
                Value = value,
                SortOrder = 1,
                IsDisabled = false,
                Alpha2Code = value,
                Alpha3Code = value
            };
        }
    }
}