namespace CustomerManagement.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<IEnumerable<Customer>> GetAllFiltered(string? companyName = null);
    }
}
