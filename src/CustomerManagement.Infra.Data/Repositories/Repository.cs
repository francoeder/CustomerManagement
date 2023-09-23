using CustomerManagement.Domain.Interfaces.Repositories;
using CustomerManagement.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.Infra.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected AppDbContext DbContext;
        protected DbSet<TEntity> DbSet;

        public Repository(AppDbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<TEntity>();
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            var result = await DbSet.AddAsync(entity);
            return result.Entity;
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            await Task.Run(() => DbSet.Update(entity));
            return entity;
        }

        public async Task Delete(TEntity entity)
        {
            if (DbContext.Entry(entity).State == EntityState.Detached)
                DbSet.Attach(entity);

            await Task.Run(() => DbSet.Remove(entity));
        }

        public async Task SaveChangesAsync()
        {
            await DbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            DbContext.Dispose();
            GC.SuppressFinalize(this);
        }
        
    }
}
