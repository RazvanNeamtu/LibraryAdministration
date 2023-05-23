using LibraryAdministration.DataAccess.Context;
using LibraryAdministration.DataAccess.Entities;
using LibraryAdministration.DataAccess.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibraryAdministration.DataAccess.Repositories
{
    public class RentalRepository : Repository<Rental>, IRentalRepository
    {
        private readonly ApplicationDbContext _applicationContext;

        public RentalRepository(ApplicationDbContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public List<Rental> GetAllByFilter(Expression<Func<Rental, bool>> filter)
        {
            return _applicationContext.Rentals.Where(filter).ToList();
        }

        public Task<Rental?> GetFullById(int id)
        {
            return _applicationContext.Rentals.Where(rental => rental.Id == id && rental.RentalEndDate == null).Include(rental => rental.Books).FirstOrDefaultAsync();
        }

        public Task<int> GetNumberOfRentedBooksForUser(int userInfoId)
        {
            return _applicationContext.Rentals
                .Where(rental => rental.UserInfoId == userInfoId && rental.RentalEndDate == null)
                .SelectMany(r => r.Books)
                .CountAsync();
        }

        public Task<List<Rental>> GetUserActiveRentals(int userInfoId)
        {
            return _applicationContext.Rentals.Where(rental => rental.UserInfoId == userInfoId && rental.RentalEndDate == null).Include(rental => rental.Books).ToListAsync();
        }

        public Task<bool> IsBookRented(int userInfoId, int bookId)
        {
            return _applicationContext.Rentals
               .AnyAsync(rental => rental.UserInfoId == userInfoId 
               && rental.RentalEndDate == null 
               && rental.Books.Any(book => book.Id == bookId));
        }

        public Task Save()
        {
            return _applicationContext.SaveChangesAsync();
        }

        public void Update(Rental rental)
        {
            _applicationContext.Update(rental);
        }
    }
}
