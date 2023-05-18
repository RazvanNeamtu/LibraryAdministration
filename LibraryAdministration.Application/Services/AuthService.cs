using LibraryAdministration.Application.Services.Abstractions;
using LibraryAdministration.DataAccess.Repositories.Abstractions;

namespace LibraryAdministration.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<(bool, string)> RegisterUser(string username, string password, string email)
        {
            if (await _authRepository.UserExistsByEmail(email))
                return (false, "User already exists"); //TODO: add resx

            var response = await _authRepository.InsertUser(username, password, email);
         
            if (!response.Succeeded)
                return (false, response.Errors.ToString() ?? "Unexpected error when trying to save user");

            return (true, "User saved successfully!");
        }
    }
}
