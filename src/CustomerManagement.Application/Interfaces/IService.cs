namespace CustomerManagement.Application.Interfaces
{
    public interface IService<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> GetById(Guid id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Update(TEntity entity);
        Task Delete(TEntity entity);
        Task SaveChangesAsync();
    }
}
