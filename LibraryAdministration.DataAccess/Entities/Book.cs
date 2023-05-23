using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace LibraryAdministration.DataAccess.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Quantity { get; set; }
        public ICollection<Author> Authors { get; set; }
        public ICollection<Rental> Rentals { get; set; }
        [ForeignKey("Image")]
        public int? ImageId { get; set; }
        public Image? Image { get; set; }
    }
}
