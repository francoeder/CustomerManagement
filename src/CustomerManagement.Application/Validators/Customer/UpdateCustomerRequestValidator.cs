using CustomerManagement.Application.Constants;
using CustomerManagement.Application.Requests.Customer;
using FluentValidation;

namespace CustomerManagement.Application.Validators.Customer
{
    public class UpdateCustomerRequestValidator : AbstractValidator<UpdateCustomerRequest>
    {
        public UpdateCustomerRequestValidator()
        {
            RuleFor(request => request.Email)
                .NotEmpty().WithMessage(ValidationMessages.Customer.EmailEmpty)
                .EmailAddress().WithMessage(ValidationMessages.Customer.EmailInvalidFormat);
            RuleFor(request => request.PhoneNumber).NotEmpty().WithMessage(ValidationMessages.Customer.PhoneNumberEmpty);
        }
    }
}
