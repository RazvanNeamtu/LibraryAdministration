﻿using AutoMapper;
using LibraryAdministration.Contracts.Requests.Rentals;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAdministration.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentalController : ControllerBase
    {
        private readonly IMapper _mapper;
        public RentalController(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Inserts new rental
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] InsertRentalRequest request)
        {

            return Ok();
        }
    }
}