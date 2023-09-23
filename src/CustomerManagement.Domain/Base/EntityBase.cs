namespace CustomerManagement.Domain.Base
{
    public abstract class EntityBase : IEntityBase
    {
        public EntityBase()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
    }
}
