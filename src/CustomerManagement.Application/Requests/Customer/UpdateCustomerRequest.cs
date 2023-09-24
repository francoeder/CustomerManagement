using CustomerManagement.Application.Validators.Customer;
using FluentValidation.Results;

namespace CustomerManagement.Application.Requests.Customer
{
    public class UpdateCustomerRequest
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        private readonly UpdateCustomerRequestValidator _validator;

        public UpdateCustomerRequest()
        {
            _validator = new UpdateCustomerRequestValidator();
        }

        public bool IsValid() => _validator.Validate(this).IsValid;
        public List<ValidationFailure> GetErrors() => _validator.Validate(this).Errors;
    }
}
