using CustomerManagement.Domain;
using CustomerManagement.Domain.Interfaces.Repositories;
using CustomerManagement.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.Infra.Data.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly AppDbContext _appDbContext;
        public CustomerRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Customer>> GetAllFiltered(string companyName = null)
        {
            var query = DbSet.AsNoTracking();

            if (companyName != null)
            {
                query = query.Where(customer => customer.CompanyName.StartsWith(companyName));
            }

            return await query.ToListAsync();
        }
    }
}
