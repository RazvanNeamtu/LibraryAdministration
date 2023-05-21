using AutoMapper;
using LibraryAdministration.Application.Models;
using LibraryAdministration.Application.Services.Abstractions;
using LibraryAdministration.DataAccess.Entities;
using LibraryAdministration.DataAccess.Repositories.Abstractions;

namespace LibraryAdministration.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        private readonly IAuthorService _authorService;

        public BookService(IBookRepository bookRepository, IAuthorRepository authorRepository, IMapper mapper, IFileService fileService, IAuthorService authorService)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _mapper = mapper;
            _fileService = fileService;
            _authorService = authorService;
        }

        public async Task DeleteById(int id)
        {
            var bookEntity = _bookRepository.GetById(id);
            if (bookEntity is null) throw new Exception("Book not found"); //todo: resx? err handling?
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

        public BookDto GetById(int id)
        {
            var bookEntity = _bookRepository.GetById(id);
            if (bookEntity is null) throw new Exception("Book not found");//todo: resx? err handling?
            var book = _mapper.Map<BookDto>(bookEntity);
            return book;
        }

        public async Task Insert(string title, int quantity, IEnumerable<Tuple<string, string>> authorsDto, byte[]? imageContent, string? imageName)
        {
            var bookEntity = await _bookRepository.GetFirstOrDefault(book => book.Title.ToUpper() == title.ToUpper());
            if (bookEntity != null) throw new Exception("Book already exists");//todo: resx? err handling? //todo: maybe mask the error? 

            bookEntity = new Book { Title = title, Quantity = quantity };

            var authors = await _authorService.RetrieveAuthors(authorsDto);

            bookEntity.Authors = new List<Author>();
            bookEntity.Authors = bookEntity.Authors.Concat(authors).ToList();

            if (imageContent != null)
            {
                var image = await _fileService.UploadImage(imageContent, imageName, bookEntity.Title);
                bookEntity.ImageId = image.Id;
                bookEntity.Image = image;
            }
            _bookRepository.Add(bookEntity);
            await _bookRepository.Save();
        }

        public Task Update(int id, string title, int quantity, string authorFirstName, string authorLastName, byte[]? imageContent)
        {
            //var bookEntity = _bookRepository.GetById(id);
            //if (bookEntity is null) throw new Exception();
            throw new NotImplementedException();
        }
    }
}
