namespace Learn.GraphQL.ApplicationService.Interface;
public interface IBaseRepository<T>
{
    Task<long> AddAsync(T entity);

    Task<bool> DeleteAsync(long id);

    Task<bool> UpdateAsync(long id, T entity);

    Task<T> GetByIdAsync(int id);
    
    Task<List<T>> GetAllAsync();
}
