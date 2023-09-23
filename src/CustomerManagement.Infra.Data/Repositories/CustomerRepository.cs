using CustomerManagement.Domain;
using CustomerManagement.Domain.Interfaces.Repositories;
using CustomerManagement.Infra.Data.Context;

namespace CustomerManagement.Infra.Data.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly AppDbContext _appDbContext;
        public CustomerRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}
