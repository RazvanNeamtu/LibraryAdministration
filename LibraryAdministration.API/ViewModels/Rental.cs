namespace LibraryAdministration.API.ViewModels
{
    public class Rental
    {
        public int RentalId { get; set; }
        public List<RentalBook> Books { get; set; }
        public DateTime RentDate { get; set; }
        public int InitialRentalPeriod { get; set; }
        public int RemainingPeriod { get; set; }
    }
}
