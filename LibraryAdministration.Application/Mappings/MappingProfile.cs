using AutoMapper;
using LibraryAdministration.Application.Models;
using LibraryAdministration.DataAccess.Entities;

namespace LibraryAdministration.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, AuthorDto>();
            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.Authors.ToList()));
            CreateMap<Book, RentalBookDto>();
            CreateMap<Rental, RentalDto>()
                .ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.Books.ToList()));

            CreateMap<UserInfo, UserInfoDto>();
        }
    }
}
