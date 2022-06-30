using AutoFixture;
using Core.Models.Lookups;
using System.Linq;
using UnitTests.EF.Fixtures;
using Xunit;

namespace UnitTests.EF
{
    public class StateServiceTest : ServiceTestBase, IClassFixture<StateServiceFixture>
    {
        #region Constructor

        public StateServiceTest(StateServiceFixture fixture) : base(fixture)
        {
        }

        #endregion Constructor

        #region Tests

        [Fact]
        public void Create()
        {
            //Arrange
            var initialCount = Sut.States.GetAll().Result.Count();
            var state = AutoFixture.Build<State>().With(x => x.CountryId, 237).Without(x => x.Id).Without(x => x.Country).Create();

            ///Act
            var result1 = Sut.States.Create(state).Result;
            Sut.SaveChangesAsync().Wait();

            var result2 = Sut.States.GetAll().Result.Count();
            var result3 = Sut.States.Create(null).Result;
            Sut.SaveChangesAsync().Wait();

            ///Assert
            Assert.True(result1);
            Assert.Equal(initialCount + 1, result2);
            Assert.False(result3);
        }

        [Theory]
        [InlineData("Text", "SOMETHING to query")]
        [InlineData("Text", "BLAH")]
        [InlineData("Text", "22n33n")]
        public async void SearchTextColumn(string filterColumn, string filterQuery)
        {
            ///Arrange
            var initialFilterCount = Sut.States.GetAll(null, null, filterColumn, filterQuery).Result.Count();
            var state = AutoFixture.Build<State>().With(x => x.Text, filterQuery).Without(x => x.Id).Without(x => x.Country).Create();

            ///Act
            var result1 = Sut.States.Create(state).Result;
            Sut.SaveChangesAsync().Wait();

            var result2 = Sut.States.GetAll(null, null, filterColumn, filterQuery).Result.Count();
            Sut.SaveChangesAsync().Wait();

            ///Assert
            Assert.True(result1);
            Assert.Equal(initialFilterCount + 1, result2);
        }

        [Theory]
        [InlineData("Value", "SOMETHING to query")]
        [InlineData("Value", "BLAH")]
        [InlineData("Value", "22n33n")]
        public async void SearchValueColumn(string filterColumn, string filterQuery)
        {
            //Arrange
            var initialFilterCount = Sut.States.GetAll(null, null, filterColumn, filterQuery).Result.Count();
            var state = AutoFixture.Build<State>().With(x => x.Value, filterQuery).With(x => x.CountryId, 237).Without(x => x.Id).Without(x => x.Country).Create();

            //Act
            var result1 = Sut.States.Create(state).Result;
            Sut.SaveChangesAsync().Wait();

            var result2 = Sut.States.GetAll(null, null, filterColumn, filterQuery).Result.Count();
            Sut.SaveChangesAsync().Wait();

            //Assert
            Assert.True(result1);
            Assert.Equal(initialFilterCount + 1, result2);
        }

        [Theory]
        [InlineData("ValueValue", "SOMETHING to query")]
        public async void SearchNonexistentColumn(string filterColumn, string filterQuery)
        {
            //Arrange
            var initialFilterCount = Sut.States.GetAll(null, null, filterColumn, filterQuery).Result.Count();

            //Act
            var result2 = Sut.States.GetAll(null, null, filterColumn, filterQuery).Result.Count();
            Sut.SaveChangesAsync().Wait();

            //Assert
            Assert.Equal(initialFilterCount, result2);
        }

        [Fact]
        public async void GetAll()
        {
            //Arrange
            //Act
            var result1 = Sut.States.GetAll().Result;
            var result2 = Sut.States.Delete(result1.FirstOrDefault().Id).Result;
            Sut.SaveChangesAsync().Wait();

            var result3 = Sut.States.GetAll().Result;

            //Assert
            Assert.NotEmpty(result1);
            Assert.True(result2);
            Assert.Equal(result1.Count() - 1, result3.Count());
        }

        [Fact]
        public async void GetTable()
        {
            //Arrange
            var result1 = Sut.States.GetAll().Result;

            //Act
            var result2 = Sut.States.GetTable().Result;

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
            var result1 = Sut.States.GetAll().Result;
            var id = result1.FirstOrDefault().Id;
            var result2 = Sut.States.Delete(result1.FirstOrDefault().Id).Result;
            Sut.SaveChangesAsync().Wait();

            var result3 = Sut.States.GetAll().Result;

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
            var result1 = Sut.States.GetAll("id", "DESC").Result;
            var result2 = Sut.States.Delete(result1.FirstOrDefault().Id + 1).Result;
            Sut.SaveChangesAsync().Wait();

            var result3 = Sut.States.GetAll().Result;

            //Assert
            Assert.NotEmpty(result1);
            Assert.False(result2);
            Assert.Equal(result1.Count(), result3.Count());
        }

        [Fact]
        public async void GetById()
        {
            //Arrange
            var result1 = Sut.States.GetAll("id", "DESC").Result;

            //Act
            var result2 = Sut.States.GetById(result1.FirstOrDefault().Id - 1).Result;

            //Assert
            Assert.NotEmpty(result1);
            Assert.NotNull(result2);
        }

        [Fact]
        public async void GetByInvalidId()
        {
            //Arrange
            var result1 = Sut.States.GetAll("id", "DESC").Result;

            //Act
            var result2 = Sut.States.GetById(result1.FirstOrDefault().Id + 1).Result;

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
            var result1 = Sut.States.GetAll("id", "DESC").Result;
            var country = Sut.States.GetById(result1.FirstOrDefault().Id - 1).Result;
            country.Text = textValue;

            //Act
            var result2 = Sut.States.Upsert(country).Result;
            Sut.SaveChangesAsync().Wait();

            var result3 = Sut.States.GetById(country.Id).Result.Text;

            //Assert
            Assert.NotEmpty(result1);
            Assert.True(result2);
            Assert.Equal(textValue, result3);
        }

        [Fact]
        public async void UpsertNullValue()
        {
            //Arrange
            var result1 = Sut.States.GetAll("id", "DESC").Result;

            //Act
            var result2 = Sut.States.Upsert(null).Result;
            Sut.SaveChangesAsync().Wait();

            //Assert
            Assert.NotEmpty(result1);
            Assert.False(result2);
        }

        [Fact]
        public async void UpsertNewObject()
        {
            //Arrange
            var result1 = Sut.States.GetAll().Result;
            var state = AutoFixture.Build<State>().With(x => x.CountryId, 237).Without(x => x.Id).Without(x => x.Country).Create();

            //Act
            var result2 = Sut.States.Upsert(state).Result;
            Sut.SaveChangesAsync().Wait();

            var result3 = Sut.States.GetAll().Result;

            //Assert
            Assert.NotEmpty(result1);
            Assert.True(result2);
            Assert.Equal(result1.Count() + 1, result3.Count());
        }

        #endregion Tests
    }
}