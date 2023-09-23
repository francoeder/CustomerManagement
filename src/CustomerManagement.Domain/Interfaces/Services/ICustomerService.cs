namespace CustomerManagement.Domain.Interfaces.Services
{
    public interface ICustomerService : IService<Customer>
    {
        Task<IEnumerable<Customer>> GetAllFiltered(string? companyName = null);
    }
}
