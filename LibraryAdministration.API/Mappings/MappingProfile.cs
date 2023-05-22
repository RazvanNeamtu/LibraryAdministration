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
            CreateMap<AuthorDto, Author>()
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.Id));
            CreateMap<BookDto, Book>()
                .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.Authors))
                .ForMember(dest => dest.BookId, opt => opt.MapFrom(src => src.Id));

            //requests
            CreateMap<RegistrationRequest, UserInfoDto>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.CNP, opt => opt.MapFrom(src => src.CNP));
        }
    }
}
