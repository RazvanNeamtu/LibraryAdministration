using LibraryAdministration.DataAccess.Entities;

namespace LibraryAdministration.DataAccess.Repositories.Abstractions
{
    public interface IAuthorRepository : IRepository<Author>
    {
        void Update(Author author);
        Task Save();
    }
}
