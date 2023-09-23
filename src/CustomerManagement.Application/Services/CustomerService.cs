using CustomerManagement.Domain;
using CustomerManagement.Domain.Interfaces.Repositories;
using CustomerManagement.Domain.Interfaces.Services;

namespace CustomerManagement.Application.Services
{
    public class CustomerService : Service<Customer>, ICustomerService
    {
        public CustomerService(
            ICustomerRepository repository) : base(repository)
        {
        }
    }
}
