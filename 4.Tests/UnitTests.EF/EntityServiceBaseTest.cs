using Xunit;
using System.Linq;
using Core.Models.Lookups;
using Services.Services;
using Services.Abstractions;
using Microsoft.Extensions.Logging;

namespace UnitTests.EF {
    public class EntityServiceBaseTest : IClassFixture<TestDatabaseFixture>{
        
        private readonly ICountryService _sut;
        private readonly ISoccerManagementService _uow;

        public EntityServiceBaseTest(TestDatabaseFixture testDatabaseFixture)
        {
            var context = testDatabaseFixture.CreateContext();
            _sut = new CountryService(context, null);
            _uow = new SoccerManagementService(context, new LoggerFactory());
            
        }
        
        [Fact]
        public void Create()
        {
            //Arrange
            var filterColumn = "Value";
            var filterQuery = "United States999";

            var totalCount = _uow.Countries.GetAll().Result.Count();
            var countryCount = _uow.Countries.GetAll(null, null, filterColumn, filterQuery).Result.Count();

            //Act
            var result1 = _uow.Countries.Create(getCountry(filterQuery)).Result;
            _uow.SaveChangesAsync().Wait(); 

            var result2 = _uow.Countries.GetAll(null, null, filterColumn, filterQuery).Result.Count();
            var result3 = _uow.Countries.GetAll().Result.Count();
            var result4 = _uow.Countries.Create(null).Result;
            _uow.SaveChangesAsync().Wait();

            //Assert
            //1. Is the return value from the base create method what is expected...true?
            Assert.True(result1);
            //2. Is there one more instance of the specific country we inserted
            Assert.Equal(countryCount + 1, result2);
            //3. Is there one more country overall
            Assert.Equal(totalCount + 1, result3);
            //4. When we submit a null value is the expected return value returned....false?
            Assert.False(result4);
        }

        [Fact]
        public async void GetAll()
        {
            //Arrange
            //Act
            var result1 = _uow.Countries.GetAll().Result;
            var result2 = _uow.Countries.Delete(result1.FirstOrDefault().Id).Result;
            _uow.SaveChangesAsync().Wait();
            var result3 = _uow.Countries.GetAll().Result;

            //Assert
            //1.Were value returned?
            Assert.NotEmpty(result1);
            //2.Was the delete successful and did it return the expected return type....true?
            Assert.True(result2);
            //3.Is the count of entities one less after the delete?
            Assert.Equal(result1.Count() - 1, result3.Count());

        }


        [Fact]
        public async void GetTable()
        {

        }

        [Fact]
        public async void Delete()
        {

        }

        [Fact]
        public async void GetById()
        {

        }

        [Fact]
        public async void Upsert()
        {

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