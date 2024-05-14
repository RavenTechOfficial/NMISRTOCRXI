using System.Linq.Expressions;

namespace ServiceLayer.Services.IRepositories
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        Task<T> Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false);
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null, bool tracked = false);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}