using LibraryAdministration.Application.Models;
using LibraryAdministration.Application.Services.Abstractions;
using LibraryAdministration.DataAccess.Entities;
using LibraryAdministration.DataAccess.Repositories.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace LibraryAdministration.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly ILogger<AuthService> _logger;

        public AuthService(IAuthRepository authRepository, IUserRepository userRepository, ITokenService tokenService, ILogger<AuthService> logger)
        {
            _authRepository = authRepository;
            _userRepository = userRepository;
            _tokenService = tokenService;
            _logger = logger;
        }

        public async Task<(bool, string)> RegisterUser(string username, string password, string email, UserInfoDto info)
        {
            if (await _authRepository.UserExistsByEmail(email))
                return (false, "User already exists");

            var user = new IdentityUser
            {
                Email = email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = username,
            };

            var response = await _authRepository.InsertUser(user, password);

            _logger.LogInformation($"Created new identity user with id {user.Id}");

            if (!response.Succeeded)
                return (false, response.Errors.ToString() ?? "Unexpected error when trying to save user"); 

            if (info != null)
            {
                var userInfo = new UserInfo { CNP = info.CNP, FirstName = info.FirstName, LastName = info.LastName, IdentityUser = user };
                _userRepository.Add(userInfo);
                await _userRepository.Save();
                _logger.LogInformation($"Inserted user information for identity user with id {user.Id}");
            }

            return (true, "User saved successfully!");
        }

        public async Task<(string, string, string)> LoginByEmail(string email, string password)
        {
            var identityUser = await _authRepository.GetUserByEmail(email);
            return await Login(identityUser, password);
        }

        public async Task<(string, string, string)> LoginByUsername(string username, string password)
        {
            _logger.LogDebug($"User {username} is performing a login");
            var identityUser = await _authRepository.GetUserByUsername(username);
            return await Login(identityUser, password);
        }

        private async Task<(string, string, string)> Login(IdentityUser? identityUser, string password)
        {
            if (identityUser is null)
                throw new Exception("Bad Credentials");
            _logger.LogDebug($"User {identityUser.Id} is performing a login");

            var isPasswordValid = await _authRepository.IsPasswordValid(identityUser, password);

            if (!isPasswordValid)
                throw new Exception("Bad Credentials");

            //var userInfo = await _userRepository.GetFirstOrDefault(user => user.IdentityUserId == identityUser.Id);

            var accessToken = _tokenService.GetToken(identityUser);
            await _userRepository.Save();

            _logger.LogDebug($"User {identityUser.Id} logged in successfully!");
            return (identityUser.UserName, identityUser.Email, accessToken);
        }
    }
}
