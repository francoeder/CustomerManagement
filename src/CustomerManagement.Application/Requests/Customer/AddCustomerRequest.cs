using CustomerManagement.Application.Validators.Customer;
using FluentValidation.Results;

namespace CustomerManagement.Application.Requests.Customer
{
    public class AddCustomerRequest
    {
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        private readonly AddCustomerRequestValidator _validator;

        public AddCustomerRequest()
        {
            _validator = new AddCustomerRequestValidator();
        }

        public bool IsValid() => _validator.Validate(this).IsValid;
        public List<ValidationFailure> GetErrors() => _validator.Validate(this).Errors;
    }
}
