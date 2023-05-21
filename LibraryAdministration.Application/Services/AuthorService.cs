using AutoMapper;
using LibraryAdministration.Application.Models;
using LibraryAdministration.Application.Services.Abstractions;
using LibraryAdministration.DataAccess.Entities;
using LibraryAdministration.DataAccess.Repositories.Abstractions;

namespace LibraryAdministration.Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task DeleteById(int id)
        {
            var authorEntity = _authorRepository.GetById(id);
            if (authorEntity is null) throw new Exception("Author not found");//todo: resx? err handling?
            _authorRepository.Remove(authorEntity);
            await _authorRepository.Save();
        }

        public async Task<List<AuthorDto>> GetAll()
        {
            var authorEntities = await _authorRepository.GetAll();
            var authors = _mapper.Map<List<AuthorDto>>(authorEntities);
            return authors;
        }

        public AuthorDto GetById(int id)
        {
            var authorEntity = _authorRepository.GetById(id);
            if (authorEntity is null) throw new Exception("Author not found");//todo: resx? err handling?
            var author = _mapper.Map<AuthorDto>(authorEntity);
            return author;
        }

        public async Task Insert(string firstName, string lastName)
        {
            var authorEntity = await GetAuthorByName(firstName, lastName);
            if (authorEntity != null) throw new Exception("Author already exists"); //todo: maybe mask the error? 

            authorEntity = new Author { FirstName = firstName, LastName = lastName };
            _authorRepository.Add(authorEntity);

            await _authorRepository.Save();

        }

        public async Task Update(int id, string firstName, string lastName)
        {
            var authorEntity = _authorRepository.GetById(id);
            if (authorEntity is null) throw new Exception("Author doesn't existst"); //todo: maybe mask the error? 

            authorEntity.FirstName = firstName;
            authorEntity.LastName = lastName;
            _authorRepository.Update(authorEntity);

            await _authorRepository.Save();
        }

        public async Task<List<Author>> RetrieveAuthors(IEnumerable<Tuple<string, string>> authors)
        {
            var authorList = new List<Author>();
            foreach (var author in authors)
            {
                var existingAuthor = await GetAuthorByName(author.Item1, author.Item2);

                if (existingAuthor is null)
                {
                    existingAuthor = new Author { FirstName = author.Item1, LastName = author.Item2 };
                    _authorRepository.Add(existingAuthor);
                }

                authorList.Add(existingAuthor);
            }

            return authorList;
        }

        private Task<Author> GetAuthorByName(string firstName, string lastName)
        {
            return _authorRepository.GetFirstOrDefault(a => a.FirstName.ToUpper() == firstName.ToUpper() && a.LastName.ToUpper() == lastName.ToUpper());
        }
    }
}
