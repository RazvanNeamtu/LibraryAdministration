using System.ComponentModel.DataAnnotations;

namespace LibraryAdministration.Contracts.Requests.Rentals
{
    public class InsertRentalRequest
    {
        /// <summary>
        /// In days
        /// </summary>
        public int? RentPeriod { get; set; }
        [Required]
        [MaxLength(6)]
        public List<int> BookIds { get; set; }
    }
}
