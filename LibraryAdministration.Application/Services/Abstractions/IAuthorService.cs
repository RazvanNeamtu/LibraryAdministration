using LibraryAdministration.Application.Models;
using LibraryAdministration.DataAccess.Entities;

namespace LibraryAdministration.Application.Services.Abstractions
{
    public interface IAuthorService
    {
        Task DeleteById(int id);
        Task<List<AuthorDto>> GetAll();
        AuthorDto GetById(int id);
        Task Insert(string firstName, string lastName);
        Task Update(int id, string firstName, string lastName);
        Task<List<Author>> RetrieveAuthors(IEnumerable<Tuple<string, string>> authors);
    }
}
