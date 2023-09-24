using AutoFixture;
using CustomerManagement.Application.Constants;
using CustomerManagement.Application.Requests.Customer;
using CustomerManagement.Application.Tests.Base;

namespace CustomerManagement.Application.Tests.Requests
{
    public class UpdateCustomerRequestTests : IClassFixture<BaseFixture>
    {
        private readonly BaseFixture _fixture;

        public UpdateCustomerRequestTests(BaseFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void IsValid_WhenPropertiesAreEmpty_ShouldReturnFalseWithCorrectMessages()
        {
            // Arrange
            var request = _fixture.Fixture.Build<UpdateCustomerRequest>()
                .Without(request => request.Email)
                .Without(request => request.PhoneNumber)
                .Create();

            // Act
            var isValid = request.IsValid();
            var errorMessages = request.GetErrors();

            // Assert
            Assert.False(isValid);

            Assert.Collection(errorMessages,
                error => Assert.Equal(ValidationMessages.Customer.EmailEmpty, error.ErrorMessage),
                error => Assert.Equal(ValidationMessages.Customer.PhoneNumberEmpty, error.ErrorMessage));
        }

        [Fact]
        public void IsValid_WhenEmailHasWrongFormat_ShouldReturnFalseWithCorrectMessages()
        {
            // Arrange
            var request = _fixture.Fixture.Build<UpdateCustomerRequest>()
                .With(request => request.Email, "some weird string that is not an email")
                .Create();

            // Act
            var isValid = request.IsValid();
            var errorMessages = request.GetErrors();

            // Assert
            Assert.False(isValid);

            Assert.Collection(errorMessages,
                error => Assert.Equal(ValidationMessages.Customer.EmailInvalidFormat, error.ErrorMessage));
        }

        [Fact]
        public void IsValid_WhenAllPropertiesAreCorrect_ShouldReturnTrue()
        {
            // Arrange
            var request = _fixture.Fixture.Build<UpdateCustomerRequest>()
                .With(request => request.Email, "batman@waynecorp.com")
                .With(request => request.PhoneNumber, "1-800-426-8478")
                .Create();

            // Act
            var isValid = request.IsValid();

            // Assert
            Assert.True(isValid);
        }
    }
}
