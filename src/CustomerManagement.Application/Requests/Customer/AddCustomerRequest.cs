namespace CustomerManagement.Application.Requests.Customer
{
    public class AddCustomerRequest
    {
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
