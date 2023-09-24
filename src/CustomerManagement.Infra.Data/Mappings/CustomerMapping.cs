using CustomerManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerManagement.Infra.Data.Mappings
{
    public class CustomerMapping : EntityBaseMapping<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            base.Configure(builder);
            builder.ToTable(nameof(Customer), "system");

            builder.Property(c => c.ResponsiblePersonName).HasMaxLength(100);
        }
    }
}
