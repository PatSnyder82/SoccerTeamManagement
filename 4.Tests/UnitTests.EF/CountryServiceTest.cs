using AutoFixture;
using Core.Models.Lookups;
using Infrastructure;
using Microsoft.Extensions.Logging;
using Services.Abstractions;
using Services.Services;
using System.Linq;
using UnitTests.EF.Setup;
using Xunit;

namespace UnitTests.EF
{
    public class CountryTest : IClassFixture<TestDatabaseFixture>
    {
        //_sut = system under test
        private readonly ISoccerManagementService _sut;
        private readonly Fixture _autoFixture;

        public CountryTest(TestDatabaseFixture testDatabaseFixture)
        {
            // Create the unit of work object using the test context.  This could be moved into the TestDatabaseSetup but since were not using a unit of work type approach
            // I decided to leave it here.  Our System under test (_sut) here would be the implementation of ICountryService.
            _sut = new SoccerManagementService(testDatabaseFixture.CreateContext(), new LoggerFactory());

            _autoFixture = new Fixture();

            // Needed to prevent circular references...
            _autoFixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            _autoFixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }


        /// <summary>
        /// Testing the Create method of ServiceBase through the derived Country class. 
        /// </summary>
        [Fact]
        public void Create()
        {
            ///********************************
            ///ARRANGE
            ///********************************
                
                // Cache the initial number of countries in the database so we can later use this to verify if any have been created/added
                var initialCount = _sut.Countries.GetAll().Result.Count();
                // Create an instance of country using anonymous data provided by autofixture
                var country = _autoFixture.Build<Country>().Without(x => x.Id).Without(x => x.States).Create();

            ///********************************
            ///ACT
            ///********************************

                // Initiate the creation of the country object.  Save the boolean return value to determine if the action was successful or not
                var result1 = _sut.Countries.Create(country).Result;
                // Commit changes to the database for persistence
                _sut.SaveChangesAsync().Wait();
                // How many countries are in the database overall?
                var result2 = _sut.Countries.GetAll().Result.Count();
                // What result do we get when we submit a null value for creation?
                var result3 = _sut.Countries.Create(null).Result;
                // Commit all the above in a single transaction
                _sut.SaveChangesAsync().Wait();

            ///********************************
            ///ASSERT
            ///********************************
                //1. Is the return value from the base create method what is expected...true?
                Assert.True(result1);
                //2. Is there one more country overall
                Assert.Equal(initialCount + 1, result2);
                //3. When we submit a null value is the expected return value returned....false?
                Assert.False(result3);
        }

        /// <summary>
        /// Test the search functionality backed into the GetAll method of the Service Base.  In this particular test 
        /// the focus is on searching via the Text column.
        /// </summary>
        /// <param name="filterColumn"></param>
        /// <param name="filterQuery"></param>
        [Theory]
        [InlineData("Text", "SOMETHING to query")]
        [InlineData("Text", "BLAH")]
        [InlineData("Text", "22n33n")]
        public async void SearchTextColumn(string filterColumn, string filterQuery)
        {
            ///********************************
            ///ARRANGE
            ///********************************
                // Cache the number of countries meeting our query criteria so we can later use this to verify if any new ones exist
                var initialFilterCount = _sut.Countries.GetAll(null, null, filterColumn, filterQuery).Result.Count();
                // Create an instance of country using the input query data
                var country = _autoFixture.Build<Country>().With(x => x.Text, filterQuery).Without(x => x.Id).Without(x => x.States).Create();

            ///********************************
            ///ACT
            ///********************************
                // Initiate the creation of the country object.  Save the boolean return value to determine if the action was successful or not
                var result1 = _sut.Countries.Create(country).Result;
                // Commit changes to the database for persistence
                _sut.SaveChangesAsync().Wait();

                // How many records exist now meeting the query criteria?
                var result2 = _sut.Countries.GetAll(null, null, filterColumn, filterQuery).Result.Count();
                // Commit the query
                _sut.SaveChangesAsync().Wait();

            ///********************************
            ///ASSERT
            ///********************************
                //1. Is the return value from the base create method what is expected...true?
                Assert.True(result1);
                //2. Is there one more instance of the specific country we inserted
                Assert.Equal(initialFilterCount + 1, result2);
        }

        [Theory]
        [InlineData("Value", "SOMETHING to query")]
        [InlineData("Value", "BLAH")]
        [InlineData("Value", "22n33n")]
        public async void SearchValueColumn(string filterColumn, string filterQuery)
        {
            //ARRANGE
            var initialFilterCount = _sut.Countries.GetAll(null, null, filterColumn, filterQuery).Result.Count();
            var country = _autoFixture.Build<Country>().With(x => x.Value, filterQuery).Without(x => x.Id).Without(x => x.States).Create();

            //ACT
            var result1 = _sut.Countries.Create(country).Result;
            _sut.SaveChangesAsync().Wait();

            var result2 = _sut.Countries.GetAll(null, null, filterColumn, filterQuery).Result.Count();
            _sut.SaveChangesAsync().Wait();

            //ASSERT
            Assert.True(result1);
            Assert.Equal(initialFilterCount + 1, result2);
        }

        [Theory]
        [InlineData("ValueValue", "SOMETHING to query")]
        public async void SearchNonexistentColumn(string filterColumn, string filterQuery)
        {
            //ARRANGE
            var initialFilterCount = _sut.Countries.GetAll(null, null, filterColumn, filterQuery).Result.Count();

            //ACT
            var result2 = _sut.Countries.GetAll(null, null, filterColumn, filterQuery).Result.Count();
            _sut.SaveChangesAsync().Wait();

            //ASSERT
            Assert.Equal(initialFilterCount, result2);
        }

        [Fact]
        public async void GetAll()
        {
            //Arrange
            //Act
            var result1 = _sut.Countries.GetAll().Result;
            var result2 = _sut.Countries.Delete(result1.FirstOrDefault().Id).Result;
            _sut.SaveChangesAsync().Wait();

            var result3 = _sut.Countries.GetAll().Result;

            //Assert
            Assert.NotEmpty(result1);
            Assert.True(result2);
            Assert.Equal(result1.Count() - 1, result3.Count());

        }

        [Fact]
        public async void GetTable()
        {
            //Arrange
            var result1 = _sut.Countries.GetAll().Result;

            //Act
            var result2 = _sut.Countries.GetTable().Result;

            //Assert
            Assert.Equal(result1.Count(), result2?.TotalCount);
            Assert.Equal(0, result2?.PageIndex);
            Assert.Equal(10, result2?.PageSize);
            Assert.Equal(result2?.PageSize, result2?.Data.Count());
            Assert.False(result2.HasPreviousPage);
            Assert.True(result2?.TotalPages >= (result2?.TotalCount / result2?.PageSize));

            if (result2?.TotalCount > result2?.PageSize)
                Assert.True(result2?.HasNextPage);
        }

        [Fact]
        public async void Delete()
        {
            //Arrange
            //Act
            var result1 = _sut.Countries.GetAll().Result;
            var id = result1.FirstOrDefault().Id;
            var result2 = _sut.Countries.Delete(result1.FirstOrDefault().Id).Result;
            _sut.SaveChangesAsync().Wait();

            var result3 = _sut.Countries.GetAll().Result;

            //Assert
            Assert.NotEmpty(result1);
            Assert.True(result2);
            Assert.Equal(result1.Count() - 1, result3.Count());
        }

        [Fact]
        public async void DeleteNonExistentId()
        {
            //Arrange
            //Act
            var result1 = _sut.Countries.GetAll("id", "DESC").Result;
            var result2 = _sut.Countries.Delete(result1.FirstOrDefault().Id+1).Result;
            _sut.SaveChangesAsync().Wait();

            var result3 = _sut.Countries.GetAll().Result;

            //Assert
            Assert.NotEmpty(result1);
            Assert.False(result2);
            Assert.Equal(result1.Count(), result3.Count());
        }

        [Fact]
        public async void GetById()
        {
            //Arrange
            var result1 = _sut.Countries.GetAll("id", "DESC").Result;

            //Act
            var result2 = _sut.Countries.GetById(result1.FirstOrDefault().Id - 1).Result;

            //Assert
            Assert.NotEmpty(result1);
            Assert.NotNull(result2);
        }

        [Fact]
        public async void GetByInvalidId()
        {
            //Arrange
            var result1 = _sut.Countries.GetAll("id", "DESC").Result;

            //Act
            var result2 = _sut.Countries.GetById(result1.FirstOrDefault().Id +1).Result;

            //Assert
            Assert.NotEmpty(result1);
            Assert.Null(result2);
        }

        [Theory]
        [InlineData("NewText")]
        [InlineData("")]
        public async void Upsert(string textValue)
        {
            //Arrange
            var result1 = _sut.Countries.GetAll("id", "DESC").Result;
            var country = _sut.Countries.GetById(result1.FirstOrDefault().Id - 1).Result;
            country.Text = textValue;

            //Act
            var result2 = _sut.Countries.Upsert(country).Result;
            _sut.SaveChangesAsync().Wait();

            var result3 = _sut.Countries.GetById(country.Id).Result.Text;

            //Assert
            Assert.NotEmpty(result1);
            Assert.True(result2);
            Assert.Equal(textValue, result3);
        }

        [Fact]
        public async void UpsertNullValue()
        {
            //Arrange
            var result1 = _sut.Countries.GetAll("id", "DESC").Result;

            //Act
            var result2 = _sut.Countries.Upsert(null).Result;
            _sut.SaveChangesAsync().Wait();

            //Assert
            Assert.NotEmpty(result1);
            Assert.False(result2);
        }

        [Fact]
        public async void UpsertNewObject()
        {
            //Arrange
            var result1 = _sut.Countries.GetAll().Result;
            var country = _autoFixture.Build<Country>().Without(x => x.Id).Without(x => x.States).Create();
            
            //Act
            var result2 = _sut.Countries.Upsert(country).Result;
            _sut.SaveChangesAsync().Wait();

            var result3 = _sut.Countries.GetAll().Result;

            //Assert
            Assert.NotEmpty(result1);
            Assert.True(result2);
            Assert.Equal(result1.Count() + 1, result3.Count());
        }
    }
}