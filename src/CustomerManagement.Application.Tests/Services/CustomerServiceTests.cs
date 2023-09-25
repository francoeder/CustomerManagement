using AutoFixture;
using CustomerManagement.Application.Constants;
using CustomerManagement.Application.Requests.Customer;
using CustomerManagement.Application.Tests.Services.Fixtures;
using CustomerManagement.Domain;
using Moq;

namespace CustomerManagement.Application.Tests.Services
{
    public class CustomerServiceTests : IClassFixture<CustomerServiceFixture>
    {
        private readonly CustomerServiceFixture _fixture;

        public CustomerServiceTests(CustomerServiceFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task GetCustomerById_WhenCustomerNotExists_ShouldReturnNullWithCorrectMessage()
        {
            // Arrange
            var service = _fixture.GetInstance();
            var id = _fixture.Fixture.Create<Guid>();

            Customer? customerNotFound = null;
            _fixture.CustomerRepositoryMock
                .Setup(repository => repository.GetById(It.IsAny<Guid>()))
                .ReturnsAsync(customerNotFound);

            var messageToVerify = string.Empty;
            _fixture.NotifierMock
                .Setup(notifier => notifier.AddNotification(It.IsAny<string>()))
                .Callback<string>(notificationMessage => messageToVerify = notificationMessage);

            // Act
            var result = await service.GetCustomerById(id);

            // Assert
            Assert.Null(result);
            Assert.Equal(ValidationMessages.Customer.CustomerNotFound, messageToVerify);
        }

        [Fact]
        public async Task Update_WhenCustomerNotExists_ShouldReturnNullWithCorrectMessage()
        {
            // Arrange
            var service = _fixture.GetInstance();
            var id = _fixture.Fixture.Create<Guid>();
            var request = _fixture.Fixture.Build<UpdateCustomerRequest>()
                .With(request => request.Age, 18)
                .With(request => request.ResponsiblePersonName, "Bruce Wayne")
                .With(request => request.Email, "bruce@waynecorp.com")
                .With(request => request.PhoneNumber, "1-800-426-8477")
                .Create();

            Customer? customerNotFound = null;
            _fixture.CustomerRepositoryMock
                .Setup(repository => repository.GetById(It.IsAny<Guid>()))
                .ReturnsAsync(customerNotFound);

            var messageToVerify = string.Empty;
            _fixture.NotifierMock
                .Setup(notifier => notifier.AddNotification(It.IsAny<string>()))
                .Callback<string>(notificationMessage => messageToVerify = notificationMessage);

            // Act
            var result = await service.Update(id, request);

            // Assert
            Assert.Null(result);
            Assert.Equal(ValidationMessages.Customer.CustomerNotFound, messageToVerify);
        }

        [Fact]
        public async Task Delete_WhenCustomerNotExists_ShouldReturnNotFoundWithCorrectMessages()
        {
            // Arrange
            var service = _fixture.GetInstance();
            var id = _fixture.Fixture.Create<Guid>();

            Customer? customerNotFound = null;
            _fixture.CustomerRepositoryMock
                .Setup(repository => repository.GetById(It.IsAny<Guid>()))
                .ReturnsAsync(customerNotFound);

            var messageToVerify = string.Empty;
            _fixture.NotifierMock
                .Setup(notifier => notifier.AddNotification(It.IsAny<string>()))
                .Callback<string>(notificationMessage => messageToVerify = notificationMessage);

            // Act
            await service.Delete(id);

            // Assert
            Assert.Equal(ValidationMessages.Customer.CustomerNotFound, messageToVerify);
        }
    }
}
