using CustomerManagement.Application.Constants;
using CustomerManagement.Application.Requests.Customer;
using FluentValidation;

namespace CustomerManagement.Application.Validators.Customer
{
    public class AddCustomerRequestValidator : AbstractValidator<AddCustomerRequest>
    {
        public AddCustomerRequestValidator()
        {
            RuleFor(request => request.CompanyName).NotEmpty().WithMessage(ValidationMessages.Customer.CompanyNameEmpty);
            RuleFor(request => request.Email)
                .NotEmpty().WithMessage(ValidationMessages.Customer.EmailEmpty)
                .EmailAddress().WithMessage(ValidationMessages.Customer.EmailInvalidFormat);
            RuleFor(request => request.PhoneNumber).NotEmpty().WithMessage(ValidationMessages.Customer.PhoneNumberEmpty);
        }
    }
}
