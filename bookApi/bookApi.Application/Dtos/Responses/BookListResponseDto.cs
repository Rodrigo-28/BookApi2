namespace bookApi.Application.Dtos.Responses
{
    public class BookListResponseDto
    {
        public BookResponseDto Book { get; set; }
        public UserBookResponseDto? UserBook { get; set; }

    }
}
