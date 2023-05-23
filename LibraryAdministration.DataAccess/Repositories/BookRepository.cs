using LibraryAdministration.DataAccess.Context;
using LibraryAdministration.DataAccess.Entities;
using LibraryAdministration.DataAccess.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace LibraryAdministration.DataAccess.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private readonly ApplicationDbContext _applicationContext;
        public BookRepository(ApplicationDbContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public Task<List<Book>> GetAllFull()
        {
            return _applicationContext.Books.Include(book => book.Authors).ToListAsync();
        }

        public Task Save()
        {
            return _applicationContext.SaveChangesAsync();
        }

        public void Update(Book book)
        {
            _applicationContext.Update(book);
        }

        public Task<List<Book>> GetAllAvailableBulk(List<int> ids)
        {
            return _applicationContext.Books.Where(b => ids.Contains(b.Id) && b.Quantity > 0).ToListAsync();
        }
    }
}
