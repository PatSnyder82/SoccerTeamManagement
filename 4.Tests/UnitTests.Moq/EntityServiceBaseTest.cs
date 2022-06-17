using System.Threading;
using System.Net.Mime;
using System;
using System.Reflection;
using Xunit;
using System.Linq;
using Core.Models.Lookups;
using Services.Services;
using Services.Abstractions;
using Moq;
using Microsoft.EntityFrameworkCore;
using Infrastructure;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace UnitTests.Moq {
    public class EntityServiceBaseTest {
        
        private readonly ICountryService _sut;

        public EntityServiceBaseTest()
        {

        }
        
        [Fact]
        public void Add()
        {
            //Arrange
            var data = new List<Country> { getCountry()}.AsQueryable();
            var mockSet = GetDbSet<Country>(data);
            var mockContext = GetContext(mockSet.Object);
            var service = GetService(mockContext.Object);

            //Act
            var result1 = service.Create(getCountry()).Result;
            var result2 = service.Create(null).Result;

            //Assert
            Assert.True(result1);
            Assert.False(result2);
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

        public Mock<DbSet<T>> GetDbSet<T>(IQueryable<T> TestData) where T : class
        {
            var MockSet = new Mock<DbSet<T>>();
            MockSet.As<IAsyncEnumerable<T>>().Setup(x => x.GetAsyncEnumerator(CancellationToken.None)).Returns(new TestAsyncEnumerator<T>(TestData.GetEnumerator()));
            MockSet.As<IQueryable<T>>().Setup(x => x.Provider).Returns(new TestAsyncQueryProvider<T>(TestData.Provider));
            MockSet.As<IQueryable<T>>().Setup(x => x.Expression).Returns(TestData.Expression);
            MockSet.As<IQueryable<T>>().Setup(x => x.ElementType).Returns(TestData.ElementType);
            MockSet.As<IQueryable<T>>().Setup(x => x.GetEnumerator()).Returns(TestData.GetEnumerator());
            return MockSet;
        }

        public Mock<ApplicationDbContext> GetContext(DbSet<Country> set) {
            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(x => x.Set<Country>()).Returns(set);

            return mockContext;
        }

        public CountryService GetService(ApplicationDbContext context) {
            var logger = LoggerFactory.Create(x => x.SetMinimumLevel(LogLevel.Trace).AddConsole()).CreateLogger("");
            return new CountryService(context, logger);
        }
    }
}