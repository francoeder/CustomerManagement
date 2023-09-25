using AutoFixture;
using CustomerManagement.Api.Tests.Controllers.Fixtures;
using CustomerManagement.Application.Requests.Customer;
using Microsoft.AspNetCore.Mvc;

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
        public async Task GetById_WhenThereAreNotifications_ShouldReturnBadRequest()
        {
            // Arrange
            var controller = _fixture.GetInstance();
            var id = _fixture.Fixture.Create<Guid>();

            _fixture.NotifierMock
                .Setup(notifier => notifier.HasNotification())
                .Returns(true);

            // Act
            var result = await controller.GetById(id) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public async Task Update_WhenThereAreNotifications_ShouldReturnBadRequest()
        {
            // Arrange
            var controller = _fixture.GetInstance();
            var id = _fixture.Fixture.Create<Guid>();
            var request = _fixture.Fixture.Create<UpdateCustomerRequest>();

            _fixture.NotifierMock
                .Setup(notifier => notifier.HasNotification())
                .Returns(true);

            // Act
            var result = await controller.Update(id, request) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public async Task Delete_WhenThereAreNotifications_ShouldReturnBadRequest()
        {
            // Arrange
            var controller = _fixture.GetInstance();
            var id = _fixture.Fixture.Create<Guid>();

            _fixture.NotifierMock
                .Setup(notifier => notifier.HasNotification())
                .Returns(true);

            // Act
            var result = await controller.Delete(id) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
        }
    }
}
