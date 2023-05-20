using LibraryAdministration.Application.Services.Abstractions;
using LibraryAdministration.Contracts.Requests.Authentication;
using LibraryAdministration.Contracts.Responses.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAdministration.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthenticationController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequest request)
        {
            if (request is null) throw new Exception(); //TODO: Error handling

            (var isSuccess, var message) = await _service.RegisterUser(request.Username, request.Password, request.Email);

            return isSuccess ? StatusCode(StatusCodes.Status201Created, message) : (IActionResult)StatusCode(StatusCodes.Status417ExpectationFailed, message);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<AuthenticationResponse>> Login([FromBody] AuthenticationRequest request)
        {
            (var username, var email, var token) = await _service.Login(request.Email, request.Password);

            return Ok(new AuthenticationResponse
            {
                Username = username,
                Email = email,
                Token = token
            });
        }
    }
}
