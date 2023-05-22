using LibraryAdministration.DataAccess.Context;
using LibraryAdministration.DataAccess.Entities;
using LibraryAdministration.DataAccess.Repositories.Abstractions;

namespace LibraryAdministration.DataAccess.Repositories
{
    public class UserRepository : Repository<UserInfo>, IUserRepository
    {
        private readonly ApplicationDbContext _applicationContext;
        public UserRepository(ApplicationDbContext usersContext) : base(usersContext)
        {
            _applicationContext = usersContext;
        }

        public Task Save()
        {
            return _applicationContext.SaveChangesAsync();
        }

        public void Update(UserInfo user)
        {
            _applicationContext.Update(user);
        }
    }
}
