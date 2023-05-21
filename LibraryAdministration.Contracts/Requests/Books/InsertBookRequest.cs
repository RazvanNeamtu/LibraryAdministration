using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace LibraryAdministration.Contracts.Requests.Books
{
    public class InsertBookRequest
    {
        [Required]
        public string Title { get; set; }
        public int Quantity { get; set; } = 1;
        public List<InsertBookRequestAuthor> Authors { get; set; }
        [AllowNull]
        public byte[]? ImageContent { get; set; }
    }

    public class InsertBookRequestAuthor
    {
        [Required]
        public string AuthorFirstName { get; set; }
        [Required]
        public string AuthorLastName { get; set; }
    }
}
