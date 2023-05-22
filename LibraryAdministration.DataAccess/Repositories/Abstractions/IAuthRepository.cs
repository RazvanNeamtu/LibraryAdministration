using Microsoft.AspNetCore.Identity;

namespace LibraryAdministration.DataAccess.Repositories.Abstractions
{
    public interface IAuthRepository
    {
        Task<IdentityUser?> GetUserByEmail(string email);
        Task<IdentityUser?> GetUserByUsername(string username);
        Task<bool> UserExistsByEmail(string email);
        Task<IdentityResult> InsertUser(IdentityUser user);
        Task<bool> IsPasswordValid(IdentityUser user, string password);
    }
}