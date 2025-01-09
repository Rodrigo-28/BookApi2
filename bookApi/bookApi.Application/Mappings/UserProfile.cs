using AutoMapper;
using bookApi.Application.Dtos.Request;
using bookApi.Application.Dtos.Responses;
using bookApi.Domian.Common;
using bookApi.Domian.Models;

namespace bookApi.Application.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            //Genre
            CreateMap<Genre, GenreResponseDto>();

            // userbook
            CreateMap<User, UserResponseDto>();
            //

            CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUserDto, User>();
            //books
            CreateMap<CreateBookDto, Book>();

            CreateMap<Book, BookResponseDto>();
            CreateMap<BookResponse, BookListResponseDto>();
            CreateMap<ReadingStatus, ReadingStatusResponseDto>();
            // CreateMap<ShelveBookDto, UserBook>();

            CreateMap<GenericListResponse<BookResponse>, GenericListResponse<BookListResponseDto>>();
            CreateMap<GenericListResponse<Book>, GenericListResponse<BookResponseDto>>();
            //CreateMap<Book, BookResponseDto>()
            //      .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.BookGenres.Select(bg => bg.Genre).ToList()));
            CreateMap<Book, BookResponseDto>()
            .ForMember(dest => dest.Genres,
                opt => opt.MapFrom(src => src.BookGenres.Select(bg => new GenreResponseDto
                {
                    Id = bg.Genre.Id,
                    Name = bg.Genre.Name
                }).ToList()));

            //genres
            CreateMap<BookGenre, GenreResponseDto>()
                  .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Genre.Id))
                  .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Genre, GenreResponseDto>();
            //bookuser
            CreateMap<UserBook, UserBookResponseDto>()
               .ForMember(dest => dest.Status, opt => opt.MapFrom(src => new ReadingStatusResponseDto
               {
                   Id = src.ReadingStatus.Id,
                   Name = src.ReadingStatus.Name,
               }));

            CreateMap<GenericListResponse<UserBook>, GenericListResponse<UserBookResponseDto>>()
            .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data));

        }
    }
}
