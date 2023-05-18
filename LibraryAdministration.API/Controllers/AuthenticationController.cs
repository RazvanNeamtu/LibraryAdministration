using LibraryAdministration.Application.Services.Abstractions;
using LibraryAdministration.Contracts.Requests.Authentication;
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
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequest request)
        {
            if (request is null) throw new Exception(); //TODO: Error handling

            (var isSuccess, var message) = await _service.RegisterUser(request.Username, request.Password, request.Email);

            return isSuccess ? StatusCode(StatusCodes.Status201Created, message) : (IActionResult)StatusCode(StatusCodes.Status417ExpectationFailed, message);
        }
    }
}
