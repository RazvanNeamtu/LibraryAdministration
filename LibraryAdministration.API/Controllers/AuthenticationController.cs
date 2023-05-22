﻿using AutoMapper;
using LibraryAdministration.Application.Models;
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
        private readonly IMapper _mapper;

        public AuthenticationController(IAuthService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Register new user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequest request)
        {
            if (request is null) throw new Exception(); //TODO: Error handling

            var userInfo = _mapper.Map<UserInfoDto>(request);

            (var isSuccess, var message) = await _service.RegisterUser(request.Username, request.Password, request.Email, userInfo);

            return isSuccess ? StatusCode(StatusCodes.Status201Created, message) : (IActionResult)StatusCode(StatusCodes.Status417ExpectationFailed, message);
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="request"></param>
        /// <returns>User credentials (username and email) and the authentication token</returns>
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<AuthenticationResponse>> Login([FromBody] AuthenticationRequest request)
        {
            if (request is null) throw new Exception(); //TODO: Error handling

            (var username, var email, var token) = await _service.LoginByEmail(request.Email, request.Password);

            return Ok(new AuthenticationResponse
            {
                Username = username,
                Email = email,
                Token = token
            });
        }
    }
}
