namespace CustomerManagement.Application.Constants
{
    public static class ValidationMessages
    {
        public static class Customer
        {
            public const string CustomerNotFound = "Customer not found!";

            public const string CompanyNameEmpty = "CompanyName is mandatory";
            public const string EmailEmpty = "Email is mandatory";
            public const string ResponsiblePersonNameMaxLength = "ResponsiblePersonName can have a maximum of 100 characters";
            public const string AgeUnderagePerson = "The person responsible must be of legal age (18)";
            public const string PhoneNumberEmpty = "PhoneNumber is mandatory";

            public const string EmailInvalidFormat = "Invalid email format";
        }
    }
}
