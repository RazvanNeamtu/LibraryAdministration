using LibraryAdministration.DataAccess.Repositories.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace LibraryAdministration.DataAccess.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        public AuthRepository(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public Task<IdentityUser?> GetUserByEmail(string email)
        {
            return _userManager.FindByEmailAsync(email);
        }

        public Task<IdentityUser?> GetUserByUsername(string username)
        {
            return _userManager.FindByNameAsync(username);
        }

        public async Task<bool> UserExistsByEmail(string email)
        {
            var existingUser = await GetUserByEmail(email);
            return existingUser != null;
        }

        public Task<IdentityResult> InsertUser(IdentityUser user, string password)
        {
            return _userManager.CreateAsync(user, password);
        }

        public Task<bool> IsPasswordValid(IdentityUser user, string password)
        {
            return _userManager.CheckPasswordAsync(user, password);
        }
    }
}
