using System.ComponentModel.DataAnnotations;

namespace LibraryAdministration.Contracts.Requests.Books
{
    public class InsertBookRequest
    {
        [Required]
        public string Title { get; set; }
        public int Quantity { get; set; } = 1;
        [Required]
        public string AuthorFirstName { get; set; }
        [Required]
        public string AuthorLastName { get; set; }
        public byte[]? ImageContent { get; set; }
    }
}
