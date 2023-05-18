using LibraryAdministration.DataAccess.Context;
using LibraryAdministration.DataAccess.Repositories.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace LibraryAdministration.DataAccess.Repositories
{
    public class UserRepository : Repository<IdentityUser>, IUserRepository
    {
        private readonly UsersContext _usersContext;
        public UserRepository(UsersContext usersContext) : base(usersContext)
        {
            _usersContext = usersContext;
        }

        public Task Save()
        {
            return _usersContext.SaveChangesAsync();
        }

        public void Update(IdentityUser user)
        {
            _usersContext.Update(user);
        }
    }
}
