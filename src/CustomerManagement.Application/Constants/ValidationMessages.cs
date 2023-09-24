namespace CustomerManagement.Application.Constants
{
    public static class ValidationMessages
    {
        public static class Customer
        {
            public const string CustomerNotFound = "Customer not found!";

            public const string CompanyNameEmpty = "CompanyName is mandatory";
            public const string EmailEmpty = "Email is mandatory";
            public const string PhoneNumberEmpty = "PhoneNumber is mandatory";

            public const string EmailInvalidFormat = "Invalid email format";
        }
    }
}
