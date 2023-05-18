using Microsoft.AspNetCore.Identity;

namespace LibraryAdministration.DataAccess.Repositories.Abstractions
{
    public interface IAuthRepository
    {
        Task<bool> UserExistsByEmail(string email);
        Task<IdentityResult> InsertUser(string username, string password, string email);
    }
}