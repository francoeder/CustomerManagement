using CustomerManagement.Application.Constants;
using CustomerManagement.Application.Requests.Customer;
using FluentValidation;

namespace CustomerManagement.Application.Validators.Customer
{
    public class UpdateCustomerRequestValidator : AbstractValidator<UpdateCustomerRequest>
    {
        public UpdateCustomerRequestValidator()
        {
            RuleFor(request => request.ResponsiblePersonName)
                .MaximumLength(100).WithMessage(ValidationMessages.Customer.ResponsiblePersonNameMaxLength);
            RuleFor(request => request.Age).GreaterThanOrEqualTo(18).WithMessage(ValidationMessages.Customer.AgeUnderagePerson);
            RuleFor(request => request.Email)
                .NotEmpty().WithMessage(ValidationMessages.Customer.EmailEmpty)
                .EmailAddress().WithMessage(ValidationMessages.Customer.EmailInvalidFormat);
            RuleFor(request => request.PhoneNumber).NotEmpty().WithMessage(ValidationMessages.Customer.PhoneNumberEmpty);
        }
    }
}
