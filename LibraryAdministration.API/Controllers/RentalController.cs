using AutoMapper;
using LibraryAdministration.API.ViewModels;
using LibraryAdministration.Application.Models;
using LibraryAdministration.Application.Services.Abstractions;
using LibraryAdministration.Contracts.Requests.Rentals;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace LibraryAdministration.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentalController : ControllerBase
    {
        private readonly IRentalService _rentalService;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public RentalController( IRentalService rentalService, IConfiguration configuration, IMapper mapper)
        {
            _rentalService = rentalService;
            _configuration = configuration;
            _mapper = mapper;
        }

        /// <summary>
        /// Inserts new rental for the logged in user
        /// </summary>
        /// <param name="request">RentPeriod is in days</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] InsertRentalRequest request)
        {
            if (request is null) throw new ValidationException($"Request {typeof(InsertRentalRequest)} is null");

            if (request.BookIds.GroupBy(x => x).Where(g => g.Count() > 1).Select(g => g.Key).Count() > 0) throw new ValidationException("Cannot rent the same book twice");

            var maximumRentPeriod = int.Parse(_configuration["BusinessLogic:MaximumRentPeriodInDays"]);
            if (request.RentPeriod > maximumRentPeriod) throw new ValidationException($"Rent period cannot be greated than {maximumRentPeriod}");

            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _rentalService.RentBooks(currentUserId, request.BookIds, request.RentPeriod);

            return Ok();
        }

        /// <summary>
        /// Get all user rentals based on the logged in user
        /// </summary>
        /// <returns>List of rentals</returns>
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<Rental>>> GetUserRentals()
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<RentalDto> rentalList = await _rentalService.GetUserRentals(currentUserId);
            var response = _mapper.Map<List<Rental>>(rentalList);
            return Ok(response);
        }

        /// <summary>
        /// Complete a rental for the logged in user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [Route("{id:int}")]
        public async Task<IActionResult> CompleteRental(int id)
        {
            await _rentalService.CompleteRental(id);
            return Ok();
        }
    }
}
