using LibraryAdministration.DataAccess.Entities;

namespace LibraryAdministration.DataAccess.Repositories.Abstractions
{
    public interface IRentalRepository : IRepository<Rental>
    {
        void Update(Rental rental);
        Task Save();
        List<Rental> GetAllByFilter(System.Linq.Expressions.Expression<Func<Rental, bool>> filter);
        Task<int> GetNumberOfRentedBooksForUser(int userInfoId);
        Task<bool> IsBookRented(int userInfoId, int bookId);
        Task<List<Rental>> GetUserActiveRentals(int currentUserId);
        Task<Rental?> GetFullById(int id);
    }
}
