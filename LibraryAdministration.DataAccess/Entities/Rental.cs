using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAdministration.DataAccess.Entities
{
    public class Rental
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime RentalStartDate { get; set; }
        public DateTime? RentalEndDate { get; set; }
        /// <summary>
        /// In days
        /// </summary>
        [Required]
        public int RentalPeriod { get; set; }
        public ICollection<Book> Books { get; set; }
        [Required]
        [ForeignKey("UserInfo")]
        public int UserInfoId { get; set; }
        public UserInfo UserInfo { get; set; }
    }
}