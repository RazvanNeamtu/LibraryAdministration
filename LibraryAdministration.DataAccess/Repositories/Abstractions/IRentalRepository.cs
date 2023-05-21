using LibraryAdministration.DataAccess.Entities;

namespace LibraryAdministration.DataAccess.Repositories.Abstractions
{
    public interface IRentalRepository : IRepository<Rental>
    {
        void Update(Rental rental);
        Task Save();
    }
}
