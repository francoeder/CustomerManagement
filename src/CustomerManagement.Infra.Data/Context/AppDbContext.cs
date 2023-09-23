using CustomerManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
