using LibraryAdministration.DataAccess.Context;
using LibraryAdministration.DataAccess.Entities;
using LibraryAdministration.DataAccess.Repositories.Abstractions;

namespace LibraryAdministration.DataAccess.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        private readonly ApplicationDbContext _applicationContext;
        public AuthorRepository(ApplicationDbContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public Task Save()
        {
            return _applicationContext.SaveChangesAsync();
        }

        public void Update(Author author)
        {
            _applicationContext.Update(author);
        }
    }
}
