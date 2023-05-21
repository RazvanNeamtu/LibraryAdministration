using AutoMapper;
using LibraryAdministration.API.ViewModels;
using LibraryAdministration.Application.Models;

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
        }
    }
}
