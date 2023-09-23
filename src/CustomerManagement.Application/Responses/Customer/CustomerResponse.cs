namespace CustomerManagement.Application.Responses.Customer
{
    public class CustomerResponse
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
