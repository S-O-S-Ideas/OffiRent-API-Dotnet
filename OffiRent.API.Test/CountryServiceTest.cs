using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using OffiRent.API.Domain.Models;
using OffiRent.API.Domain.Repositories;
using OffiRent.API.Domain.Services.Communications;
using OffiRent.API.Services;

namespace OffiRent.API.Test
{
    public class CountryServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetAllAsyncWhenNoCountriesReturnsEmptyCollection()
        {
            // Arrange
            var mockCountryRepository = GetDefaultICountryRepositoryInstance();
            mockCountryRepository.Setup(r => r.ListAsync())
                .ReturnsAsync(new List<Country>());

            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var service = new CountryService(
                mockCountryRepository.Object,
                mockUnitOfWork.Object);

            // Act
            List<Country> countries = (List<Country>)await service.ListAsync();
            var countriesCount = countries.Count;

            // Assert
            countriesCount.Should().Equals(0);
        }

        [Test]
        public async Task GetByIdAsyncWhenInvalidIdReturnsCountryNotFoundReResponse()
        {
            // Arrange
            var mockCountryRepository = GetDefaultICountryRepositoryInstance();
            var countryId = 1;
            mockCountryRepository.Setup(r => r.GetSingleByIdAsync(countryId))
                .Returns(Task.FromResult<Country>(null));
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var service = new CountryService(
                mockCountryRepository.Object,
                mockUnitOfWork.Object);


            // Act
            CountryResponse response = await service.GetBySingleIdAsync(countryId);
            var message = response.Message;

            // Assert
            message.Should().Be("Country not found");
        }
        private Mock<ICountryRepository> GetDefaultICountryRepositoryInstance()
        {
            return new Mock<ICountryRepository>();
        }


        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
