using LibraryAdministration.Application.Models;

namespace LibraryAdministration.Application.Services.Abstractions
{
    public interface IRentalService
    {
        Task CompleteRental(int id);
        Task<List<RentalDto>> GetUserRentals(string currentUserId);
        Task RentBooks(string identityUserId, List<int> bookIds, int? rentPeriod);
    }
}
