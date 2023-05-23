using LibraryAdministration.DataAccess.Entities;

namespace LibraryAdministration.DataAccess.Repositories.Abstractions
{
    public interface IBookRepository : IRepository<Book>
    {
        void Update(Book book);
        Task Save();
        Task<List<Book>> GetAllFull();
        Task<List<Book>> GetAllAvailableBulk(List<int> ids);
    }
}
