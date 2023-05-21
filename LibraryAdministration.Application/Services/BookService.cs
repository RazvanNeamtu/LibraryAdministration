using AutoMapper;
using LibraryAdministration.Application.Models;
using LibraryAdministration.Application.Services.Abstractions;
using LibraryAdministration.DataAccess.Entities;
using LibraryAdministration.DataAccess.Repositories.Abstractions;
using Microsoft.Extensions.Configuration;

namespace LibraryAdministration.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public BookService(IBookRepository bookRepository, IConfiguration configuration, IAuthorRepository authorRepository, IMapper mapper, IFileService fileService)
        {
            _bookRepository = bookRepository;
            _configuration = configuration;
            _authorRepository = authorRepository;
            _mapper = mapper;
            _fileService = fileService;

        }

        public async Task DeleteById(int id)
        {
            var bookEntity = _bookRepository.GetById(id);
            if (bookEntity is null) throw new Exception();
            _bookRepository.Remove(bookEntity);
            await _bookRepository.Save();
        }

        public async Task<List<BookDto>> GetAll(bool includeAuthors)
        {
            List<Book> bookEntities;
            if (includeAuthors) bookEntities = await _bookRepository.GetAllFull();
            else bookEntities = await _bookRepository.GetAll();
            var books = _mapper.Map<List<BookDto>>(bookEntities);
            return books;
        }

        public async Task<BookDto> GetById(int id)
        {
            var bookEntity = _bookRepository.GetById(id);
            if (bookEntity is null) throw new Exception();
            var book = _mapper.Map<BookDto>(bookEntity);
            return book;
        }

        public async Task Insert(string title, int quantity, IEnumerable<Tuple<string, string>> authorsDto, byte[]? imageContent, string? imageName)
        {
            var bookEntity = await _bookRepository.GetFirstOrDefault(book => book.Title.ToUpper() == title.ToUpper());
            if (bookEntity != null) throw new Exception("Book already exists");

            var book = new Book { Title = title, Quantity = quantity };

            var authors = await RetrieveAuthors(authorsDto);

            book.Authors = new List<Author>();
            book.Authors = book.Authors.Concat(authors).ToList();

            if (imageContent != null)
            {
                var image = await _fileService.UploadImage(imageContent, imageName, book.Title);
                book.ImageId = image.Id;
                book.Image = image;
            }
            _bookRepository.Add(book);
            await _bookRepository.Save();
        }

        public Task Update(int id, string title, int quantity, string authorFirstName, string authorLastName, byte[]? imageContent)
        {
            //var bookEntity = _bookRepository.GetById(id);
            //if (bookEntity is null) throw new Exception();
            throw new NotImplementedException();
        }

        private async Task<List<Author>> RetrieveAuthors(IEnumerable<Tuple<string, string>> authors)
        {
            var authorList = new List<Author>();
            foreach (var author in authors)
            {
                var existingAuthor = await _authorRepository.GetFirstOrDefault(a => a.FirstName.ToUpper() == author.Item1.ToUpper()
                                                                                     && a.LastName.ToUpper() == author.Item2.ToUpper());

                if (existingAuthor is null)
                {
                    existingAuthor = new Author { FirstName = author.Item1, LastName = author.Item2 };
                    _authorRepository.Add(existingAuthor);
                }

                authorList.Add(existingAuthor);
            }

            return authorList;
        }
    }
}
