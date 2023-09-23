using CustomerManagement.Domain.Base;

namespace CustomerManagement.Domain
{
    public class Customer : EntityBase
    {
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}