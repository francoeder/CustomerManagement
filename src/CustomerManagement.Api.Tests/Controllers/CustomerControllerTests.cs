using AutoFixture;
using CustomerManagement.Api.Tests.Controllers.Fixtures;
using CustomerManagement.Application.Constants;
using CustomerManagement.Application.Requests.Customer;
using CustomerManagement.Application.Responses.Base;
using CustomerManagement.Domain;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CustomerManagement.Api.Tests.Controllers
{
    public class CustomerControllerTests : IClassFixture<CustomerControllerFixture>
    {
        private readonly CustomerControllerFixture _fixture;

        public CustomerControllerTests(CustomerControllerFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task GetById_WhenCustomerNotExists_ShouldReturnNotFoundWithCorrectMessages()
        {
            // Arrange
            var controller = _fixture.GetInstance();
            var id = _fixture.Fixture.Create<Guid>();

            Customer? customerNotFound = null;
            _fixture.CustomerServiceMock
                .Setup(service => service.GetById(It.IsAny<Guid>()))
                .ReturnsAsync(customerNotFound);

            // Act
            var result = await controller.GetById(id) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(404, result.StatusCode);

            Assert.NotNull(result.Value);
            Assert.Equal(ValidationMessages.Customer.CustomerNotFound, ((Response<string>)result.Value).Data);
        }

        [Fact]
        public async Task Update_WhenCustomerNotExists_ShouldReturnNotFoundWithCorrectMessages()
        {
            // Arrange
            var controller = _fixture.GetInstance();
            var id = _fixture.Fixture.Create<Guid>();
            var request = _fixture.Fixture.Build<UpdateCustomerRequest>()
                .With(request => request.Email, "bruce@waynecorp.com")
                .With(request => request.PhoneNumber, "1-800-426-8477")
                .Create();

            Customer? customerNotFound = null;
            _fixture.CustomerServiceMock
                .Setup(service => service.GetById(It.IsAny<Guid>()))
                .ReturnsAsync(customerNotFound);

            // Act
            var result = await controller.Update(id, request) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(404, result.StatusCode);

            Assert.NotNull(result.Value);
            Assert.Equal(ValidationMessages.Customer.CustomerNotFound, ((Response<string>)result.Value).Data);
        }

        [Fact]
        public async Task Delete_WhenCustomerNotExists_ShouldReturnNotFoundWithCorrectMessages()
        {
            // Arrange
            var controller = _fixture.GetInstance();
            var id = _fixture.Fixture.Create<Guid>();

            Customer? customerNotFound = null;
            _fixture.CustomerServiceMock
                .Setup(service => service.GetById(It.IsAny<Guid>()))
                .ReturnsAsync(customerNotFound);

            // Act
            var result = await controller.Delete(id) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(404, result.StatusCode);

            Assert.NotNull(result.Value);
            Assert.Equal(ValidationMessages.Customer.CustomerNotFound, ((Response<string>)result.Value).Data);
        }
    }
}
