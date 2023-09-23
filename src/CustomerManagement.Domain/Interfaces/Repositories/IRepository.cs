namespace CustomerManagement.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> GetById(Guid id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Update(TEntity entity);
        Task Delete(TEntity entity);
        Task SaveChangesAsync();
    }
}
