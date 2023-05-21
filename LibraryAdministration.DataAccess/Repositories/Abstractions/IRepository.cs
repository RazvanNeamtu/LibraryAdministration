using System.Linq.Expressions;

namespace LibraryAdministration.DataAccess.Repositories.Abstractions
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        T GetById(int id);
        Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Remove(T entity);
        void RemoveMultiple(IEnumerable<T> entities);
    }
}
