using owasp10.A03.business.Entities;

namespace owasp10.A03.business.Data;

public interface ISqLiteRepository<T> where T : Entity
{
    Task<T> GetAsync(int id);
    Task CreateAsync(T entity);
    Task DeleteAsync(T entity);
    Task UpdateAsync(T entity);
}
