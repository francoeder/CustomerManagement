using AutoMapper;
using CustomerManagement.Application.Constants;
using CustomerManagement.Application.Interfaces;
using CustomerManagement.Application.Notifications;
using CustomerManagement.Application.Requests.Customer;
using CustomerManagement.Application.Responses.Customer;
using CustomerManagement.Domain;
using CustomerManagement.Domain.Interfaces.Repositories;

namespace CustomerManagement.Application.Services
{
    public class CustomerService : Service<Customer>, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly INotifier _notifier;
        private readonly IMapper _mapper;

        public CustomerService(
            ICustomerRepository repository,
            INotifier notifier,
            IMapper mapper) : base(repository)
        {
            _customerRepository = repository;
            _notifier = notifier;
            _mapper = mapper;
        }

        public async Task<CustomerResponse> Add(AddCustomerRequest request)
        {
            if (!request.IsValid())
            {
                _notifier.AddNotifications(request.GetErrors());
                return null;
            }

            var customer = _mapper.Map<Customer>(request);
            await Add(customer);
            await SaveChangesAsync();

            var response = _mapper.Map<CustomerResponse>(customer);
            return response;
        }

        public async Task<CustomerResponse> GetCustomerById(Guid id)
        {
            var customer = await _customerRepository.GetById(id);
            if (customer == null)
            {
                _notifier.AddNotification(ValidationMessages.Customer.CustomerNotFound);
                return null;
            }

            var response = _mapper.Map<CustomerResponse>(customer);
            return response;
        }

        public async Task<List<CustomerResponse>> GetAllFiltered(string companyName = null)
        {
            var filteredResult = await _customerRepository.GetAllFiltered(companyName);
            return _mapper.Map<List<CustomerResponse>>(filteredResult);
        }

        public async Task<CustomerResponse> Update(Guid id, UpdateCustomerRequest request)
        {
            if (!request.IsValid())
            {
                _notifier.AddNotifications(request.GetErrors());
                return null;
            }

            var customer = await _customerRepository.GetById(id);
            if (customer == null)
            {
                _notifier.AddNotification(ValidationMessages.Customer.CustomerNotFound);
                return null;
                
            }

            _mapper.Map(request, customer);
            await Update(customer);
            await SaveChangesAsync();

            var response = _mapper.Map<CustomerResponse>(customer);
            return response;
        }
    
        public async Task Delete(Guid id)
        {
            var customer = await _customerRepository.GetById(id);
            if (customer == null)
            {
                _notifier.AddNotification(ValidationMessages.Customer.CustomerNotFound);
                return;
            }

            await Delete(customer);
            await SaveChangesAsync();
        }
    }
}
