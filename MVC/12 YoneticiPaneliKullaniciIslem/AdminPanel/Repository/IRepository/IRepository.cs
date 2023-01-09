using System.Linq.Expressions;

namespace AdminPanel.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);

        T GetFirstOrDefault(Expression<Func<T, bool>>? filter =null,
            string? includeProperties =null );
        
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null,
            string? includeProperties = null);

        void Update(T entity);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);

    }
}
