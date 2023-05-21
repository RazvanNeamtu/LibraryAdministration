using LibraryAdministration.DataAccess.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace LibraryAdministration.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _dbContext;
        internal DbSet<T> dbSet;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            this.dbSet = _dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public Task<T> GetFirstOrDefault(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return query.FirstOrDefaultAsync();
        }

        public Task<List<T>> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToListAsync();
        }

        public T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveMultiple(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }
}
