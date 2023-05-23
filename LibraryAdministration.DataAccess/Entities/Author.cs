using System.ComponentModel.DataAnnotations;

namespace LibraryAdministration.DataAccess.Entities
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
