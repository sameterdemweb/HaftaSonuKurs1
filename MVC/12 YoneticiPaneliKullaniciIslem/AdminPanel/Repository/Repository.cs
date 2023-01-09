using AdminPanel.Identity;
using AdminPanel.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdminPanel.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AdminPanelContext _context;

        internal DbSet<T> _dbSet;

        public Repository(AdminPanelContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();  
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = _dbSet;

            if (filter!=null)
            {//x=>x.id =1
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                // "Product, Order"
                foreach(var item in includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }

            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
            {//x=>x.id =1
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                // "Product, Order"
                foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }

            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);

        }
    }
}
