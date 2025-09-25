using ProjectManagementApi.Repositories;

namespace ProjectManagementApi.Services;

public class Service<T> : IService<T> where T : class
{
    protected readonly IRepository<T> _repository;

    public Service(IRepository<T> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<T> CreateAsync(T entity)
    {
        await _repository.AddAsync(entity);
        return entity;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        await _repository.UpdateAsync(entity);
        return entity;
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}
