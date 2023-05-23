
namespace LibraryAdministration.Application.Models
{
    public class RentalDto
    {
        public int Id { get; set; }
        public DateTime RentalStartDate { get; set; }
        public int RentalPeriod { get; set; }
        public List<RentalBookDto> Books { get; set; }
        public UserInfoDto UserInfo { get; set; }
    }
}
