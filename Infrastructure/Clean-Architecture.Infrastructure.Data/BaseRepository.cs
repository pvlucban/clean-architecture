using Clean_Architecture.Core.Application.Interfaces.Repository;
using Clean_Architecture.Core.Domain;

namespace Clean_Architecture.Infrastructure.Data;

public abstract class BaseRepository<TEntity, KT> where TEntity : class
{
    private readonly ApplicationDBContext _applicationDBContext;
    public BaseRepository(ApplicationDBContext applicationDBContext)
    {
        _applicationDBContext = applicationDBContext;
    }

    public async Task AddAsync(TEntity entity)
    {
        await _applicationDBContext.Set<TEntity>().AddAsync(entity);
    }

    public async Task<TEntity?> GetByIdAsync(KT id, bool trackable = true)
    {
        return await _applicationDBContext.Set<TEntity>().FindAsync(id);
    }

    public Task RemoveAsync(TEntity entity)
    {
        _applicationDBContext.Set<TEntity>().Remove(entity);
        return Task.CompletedTask;
    }

    public async Task<int> SaveAsync()
    {
        return await _applicationDBContext.SaveChangesAsync();
    }

    public Task UpdateAsync(TEntity entity)
    {
        _applicationDBContext.Set<TEntity>().Update(entity);
        return Task.CompletedTask;
    }
}
