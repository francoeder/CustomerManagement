using CustomerManagement.Domain;
using CustomerManagement.Domain.Interfaces.Repositories;
using CustomerManagement.Domain.Interfaces.Services;

namespace CustomerManagement.Application.Services
{
    public class CustomerService : Service<Customer>, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(
            ICustomerRepository repository) : base(repository)
        {
            _customerRepository = repository;
        }

        public async Task<IEnumerable<Customer>> GetAllFiltered(string companyName = null)
        {
            return await _customerRepository.GetAllFiltered(companyName);
        }
    }
}
