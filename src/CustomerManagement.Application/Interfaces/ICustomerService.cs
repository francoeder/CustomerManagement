using CustomerManagement.Application.Requests.Customer;
using CustomerManagement.Application.Responses.Customer;
using CustomerManagement.Domain;

namespace CustomerManagement.Application.Interfaces
{
    public interface ICustomerService : IService<Customer>
    {
        Task<List<CustomerResponse>> GetAllFiltered(string companyName = null);
        Task<CustomerResponse> Add(AddCustomerRequest request);
        Task<CustomerResponse> GetCustomerById(Guid id);
        Task<CustomerResponse> Update(Guid id, UpdateCustomerRequest request);
        Task Delete(Guid id);
    }
}
