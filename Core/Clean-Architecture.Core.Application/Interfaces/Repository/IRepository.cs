


namespace Clean_Architecture.Core.Application.Interfaces.Repository;

public interface IRepository<T, KT>
{
    Task<T?> GetByIdAsync(KT id, bool trackable = true);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task RemoveAsync(T entity);

    Task<int> SaveAsync();
}
