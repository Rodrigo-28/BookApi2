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
            // ─── Genre & ReadingStatus ──────────────────────────────────────
            CreateMap<CreateGenreDto, Genre>();
            CreateMap<Genre, GenreResponseDto>();

            CreateMap<ReadingStatus, ReadingStatusResponseDto>();

            // ─── User & Authentication ────────────────────────────────────
            CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUserDto, User>();
            CreateMap<User, UserResponseDto>();

            CreateMap<SignInDto, CreateUserDto>()
                .ForMember(d => d.Password, o => o.MapFrom(s => s.Password1))
                .ForMember(d => d.RoleId, o => o.MapFrom(_ => 2));

            CreateMap<LoginRequestDto, LoginResponseDto>();

            // ─── Book & UserBook ─────────────────────────────────────────
            CreateMap<CreateBookDto, Book>();
            CreateMap<UpdateBookDto, Book>();
            CreateMap<Book, BookResponseDto>();

            CreateMap<UserBook, UserBookResponseDto>()
                .ForMember(d => d.Status, o => o.MapFrom(src => new ReadingStatusResponseDto
                {
                    Id = src.ReadingStatus.Id,
                    Name = src.ReadingStatus.Name
                }));

            // ─── Proyecciones de BookResponse ─────────────────────────────

            // Mapea BookResponse → BookResponseDto
            CreateMap<BookResponse, BookResponseDto>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Book.Id))
                .ForMember(d => d.Title, o => o.MapFrom(s => s.Book.Title))
                .ForMember(d => d.Author, o => o.MapFrom(s => s.Book.Author))
                .ForMember(d => d.PublishYear, o => o.MapFrom(s => s.Book.PublishYear ?? 0))
                .ForMember(d => d.Description, o => o.MapFrom(s => s.Book.Description))
                .ForMember(d => d.CoverUrl, o => o.MapFrom(s => s.Book.CoverUrl))
                .ForMember(d => d.PageCount, o => o.MapFrom(s => s.Book.PageCount ?? 0))
                .ForMember(d => d.Genres, o => o.MapFrom(s =>
                    s.Book.BookGenres.Select(bg => new GenreResponseDto
                    {
                        Id = bg.Genre.Id,
                        Name = bg.Genre.Name
                    })));

            // Envuelve el anterior en BookListResponseDto
            CreateMap<BookResponse, BookListResponseDto>()
                .ForMember(d => d.Book, o => o.MapFrom(s => s));

            // Detalle completo, incluye UserBook
            CreateMap<BookResponse, BookDetailedResponseDto>()
                .ForMember(d => d.Book, o => o.MapFrom(s => s))
                .ForMember(d => d.UserBook, o => o.MapFrom(s => s.UserBook));

            // ─── Paginación genérica ───────────────────────────────────────
            CreateMap<GenericListResponse<BookResponse>, GenericListResponse<BookListResponseDto>>()
                .ForMember(d => d.Data, o => o.MapFrom(s => s.Data));
            CreateMap<GenericListResponse<BookResponse>, GenericListResponse<BookDetailedResponseDto>>()
                .ForMember(d => d.Data, o => o.MapFrom(s => s.Data));

            CreateMap<GenericListResponse<Comment>, GenericListResponse<CommentResponseDto>>()
                .ForMember(d => d.Data, o => o.MapFrom(s => s.Data));
            CreateMap<GenericListResponse<UserBook>, GenericListResponse<UserBookResponseDto>>()
                .ForMember(d => d.Data, o => o.MapFrom(s => s.Data));

            // ─── Comments, Likes & Reviews ────────────────────────────────
            CreateMap<CreateCommentDto, Comment>();
            CreateMap<UpdateCommentDto, Comment>();

            CreateMap<Comment, CommentResponseDto>()
                .ForMember(d => d.Username, o => o.MapFrom(s => s.User.Username));

            CreateMap<Like, LikeResponseDto>();

            CreateMap<CreateReviewDto, Review>();
            CreateMap<UpdateReviewDto, Review>();

            CreateMap<Review, CreateReviewResponseDto>();
            CreateMap<Review, ReviewResponseDto>()
                .ForMember(d => d.Username, o => o.MapFrom(s => s.User.Username))
                .ForMember(d => d.CommentsCount, o => o.MapFrom(s => s.Comments.Count))
                .ForMember(d => d.LikesCount, o => o.MapFrom(s => s.Likes.Count));

        }
    }
}
