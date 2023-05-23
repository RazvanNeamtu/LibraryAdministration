using AutoMapper;
using LibraryAdministration.Application.Models;
using LibraryAdministration.Application.Services.Abstractions;
using LibraryAdministration.DataAccess.Entities;
using LibraryAdministration.DataAccess.Repositories.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace LibraryAdministration.Application.Services
{
    public class RentalService : IRentalService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRentalRepository _rentalRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IConfiguration _configuration;
        private readonly ILogger<RentalService> _logger;
        private readonly IMapper _mapper;

        public RentalService(IUserRepository userRepository, IRentalRepository rentalRepository, IBookRepository bookRepository, IConfiguration configuration, ILogger<RentalService> logger, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _userRepository = userRepository;
            _rentalRepository = rentalRepository;
            _configuration = configuration;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task CompleteRental(int id)
        {
            var rental = await _rentalRepository.GetFullById(id);
            if (rental is null) throw new Exception("Rental not found");
            
            rental.RentalEndDate = DateTime.UtcNow;

            foreach(var book in rental.Books)
            {
                book.Quantity++;
            }

            _rentalRepository.Update(rental);
            await _rentalRepository.Save();
        }

        public async Task<List<RentalDto>> GetUserRentals(string identityUserId)
        {
            var userInfo = await GetUserInfoByIdentityUserId(identityUserId);
            var rentalList = await _rentalRepository.GetUserActiveRentals(userInfo.Id);
            var rentals = _mapper.Map<List<RentalDto>>(rentalList);
            return rentals;
        }

        public async Task RentBooks(string identityUserId, List<int> userSelectedBookIds, int? rentPeriod)
        {
            _logger.LogDebug($"User {identityUserId} is starting the rent process");
            var userInfo = await GetUserInfoByIdentityUserId(identityUserId);

            var rentalPeriod = rentPeriod ?? int.Parse(_configuration["BusinessLogic:MaximumRentPeriodInDays"]);
            var maximumBooksPerUser = int.Parse(_configuration["BusinessLogic:MaximumRentedBooksPerUser"]);
            var rentalDate = DateTime.UtcNow;

            var activeRentedBooksCount = await _rentalRepository.GetNumberOfRentedBooksForUser(userInfo.Id);

            if (userSelectedBookIds.Count() > maximumBooksPerUser - activeRentedBooksCount)
                throw new Exception($"You can't rent that many books. Limit is {maximumBooksPerUser} and you have actively rented {activeRentedBooksCount}");

            var books = await _bookRepository.GetAllAvailableBulk(userSelectedBookIds);

            var booksToBeRented = new List<Book>();

            foreach (var bookId in userSelectedBookIds)
            {
                var book = books.FirstOrDefault(book => book.Id == bookId);
                if (book is null)
                    throw new Exception($"Book with id {bookId} is not in stock");

                var bookAlreadyRentedByUser = await _rentalRepository.IsBookRented(userInfo.Id, bookId);
                if (bookAlreadyRentedByUser) throw new Exception($"You have already rented book with id {bookId}");

                book.Quantity--;
                if (book.Quantity < 0)
                {
                    _logger.LogInformation($"Book with id {book.Id} would have been resulted in negative quantity");
                    throw new Exception("Something went wrong"); //extra check
                }

                booksToBeRented.Add(book);
            }

            var rental = new Rental { RentalPeriod = rentalPeriod, RentalStartDate = DateTime.UtcNow, UserInfoId = userInfo.Id };
            rental.Books = new List<Book>();
            rental.Books = rental.Books.Concat(booksToBeRented).ToList();

            _rentalRepository.Add(rental);
            await _rentalRepository.Save();
            _logger.LogInformation($"Created new rental with id {rental.Id}");
        }

        private async Task<UserInfo> GetUserInfoByIdentityUserId(string identityUserId)
        {
            var userInfo = await _userRepository.GetUserInfoByIdentityUserId(identityUserId);
            if (userInfo is null) throw new Exception("User info not found");
            return userInfo;
        }
    }
}
