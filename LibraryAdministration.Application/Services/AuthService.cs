using LibraryAdministration.Application.Services.Abstractions;
using LibraryAdministration.DataAccess.Repositories.Abstractions;

namespace LibraryAdministration.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public AuthService(IAuthRepository authRepository, IUserRepository userRepository, ITokenService tokenService)
        {
            _authRepository = authRepository;
            _userRepository = userRepository;
            _tokenService = tokenService;

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

        public async Task<(string, string, string)> Login(string email, string password)
        {
            var identityUser = await _authRepository.GetUserByEmail(email);
            if (identityUser is null) 
                throw new Exception("Bad Credentials");

            var isPasswordValid = await _authRepository.IsPasswordValid(identityUser, password);

            if(!isPasswordValid)
                throw new Exception("Bad Credentials");

            var user = await _userRepository.GetFirstOrDefault(user => user.Email == email);
            if (user is null)
                throw new UnauthorizedAccessException();

            var accessToken = _tokenService.GetToken(user);
            await _userRepository.Save();

            return (user.UserName, user.Email, accessToken);
        }
    }
}
