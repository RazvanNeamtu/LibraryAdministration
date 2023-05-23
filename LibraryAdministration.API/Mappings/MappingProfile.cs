using AutoMapper;
using LibraryAdministration.API.ViewModels;
using LibraryAdministration.Application.Models;
using LibraryAdministration.Contracts.Requests.Authentication;

namespace LibraryAdministration.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserInfoDto, UserInfo>();
            CreateMap<AuthorDto, Author>()
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.Id));
            CreateMap<BookDto, Book>()
                .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.Authors))
                .ForMember(dest => dest.BookId, opt => opt.MapFrom(src => src.Id));
            CreateMap<RentalBookDto, RentalBook>()
                .ForMember(dest => dest.BookId, opt => opt.MapFrom(src => src.Id));
            CreateMap<RentalDto, Rental>()
                .ForMember(dest => dest.RentalId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.RentDate, opt => opt.MapFrom(src => src.RentalStartDate))
                .ForMember(dest => dest.RentalId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.RemainingPeriod, opt => opt.MapFrom(src => CalculateRemainingDays(src.RentalStartDate, src.RentalPeriod)))
                .ForMember(dest => dest.InitialRentalPeriod, opt => opt.MapFrom(src => src.RentalPeriod));

            //requests
            CreateMap<RegistrationRequest, UserInfoDto>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.CNP, opt => opt.MapFrom(src => src.CNP));
        }

        private int CalculateRemainingDays(DateTime rentDate, int initialRentalPeriod)
        {
            DateTime currentDate = DateTime.UtcNow;
            TimeSpan elapsedPeriod = currentDate - rentDate;

            return initialRentalPeriod - (int)elapsedPeriod.TotalDays;
        }
    }

}
