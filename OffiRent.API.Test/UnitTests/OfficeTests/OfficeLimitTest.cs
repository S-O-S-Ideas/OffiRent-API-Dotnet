using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using OffiRent.API.Domain.Models;
using OffiRent.API.Domain.Repositories;
using OffiRent.API.Domain.Services.Communications;
using OffiRent.API.Services;
using Ubiety.Dns.Core.Records.General;

namespace OffiRent.API.Test
{
    public class OfficeServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task AddAsync_WhenRecievesNullObject_ReturnsException()
        {
            // Arrange
            var mockOfficeRepository = GetDefaultIOfficeRepositoryInstance();
            var mockAccountRepository = GetDefaultIAccountRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var service = new OfficeService(mockOfficeRepository.Object, mockUnitOfWork.Object, mockAccountRepository.Object);

            Account account = new Account
            {
                Id = 100,
                Email = "test@gmail.com",
                Password = "test1234",
                Identification = "72901831",
                FirstName = "testing",
                LastName = "tests",
                PhoneNumber = "920837182",
                IsPremium = false,
            };
            Office nullOffice = null;

            mockAccountRepository.Setup(ar => ar.GetSingleByIdAsync(account.Id)).ReturnsAsync(account);
            mockOfficeRepository.Setup(or => or.AddAsync(nullOffice)).Returns(() => Task.FromResult<Office>(null));

            // Act
            
            var response = service.SaveAsync(nullOffice).Result;

            // Assert
            Assert.AreEqual("An error ocurred while saving the office: Object reference not set to an instance of an object.", response.Message);

            
        }

        

        private Mock<IOfficeRepository> GetDefaultIOfficeRepositoryInstance()
        {
            return new Mock<IOfficeRepository>();
        }

        private Mock<IAccountRepository> GetDefaultIAccountRepositoryInstance()
        {
            return new Mock<IAccountRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }

    }
}