using Microsoft.AspNetCore.Identity;

namespace LibraryAdministration.DataAccess.Repositories.Abstractions
{
    public interface IUserRepository : IRepository<IdentityUser>
    {
        void Update(IdentityUser user);
        Task Save();
    }
}
