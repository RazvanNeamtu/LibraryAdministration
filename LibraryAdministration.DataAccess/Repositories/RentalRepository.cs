using LibraryAdministration.DataAccess.Context;
using LibraryAdministration.DataAccess.Entities;
using LibraryAdministration.DataAccess.Repositories.Abstractions;

namespace LibraryAdministration.DataAccess.Repositories
{
    public class RentalRepository : Repository<Rental>, IRentalRepository
    {
        private readonly ApplicationDbContext _applicationContext;
        public RentalRepository(ApplicationDbContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
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
