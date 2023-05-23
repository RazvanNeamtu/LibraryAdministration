using LibraryAdministration.DataAccess.Entities;

namespace LibraryAdministration.Application.Models
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Quantity { get; set; }
        public List<AuthorDto> Authors { get; set; }
    }
}
