using System.Linq.Expressions;

namespace LibraryAdministration.DataAccess.Repositories.Abstractions
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        T GetFirstOrDefault(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Remove(T entity);
        void RemoveMultiple(IEnumerable<T> entities);
    }
}
