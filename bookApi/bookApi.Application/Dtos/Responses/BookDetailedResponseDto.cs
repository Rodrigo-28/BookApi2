namespace bookApi.Application.Dtos.Responses
{
    public class BookDetailedResponseDto
    {
        public BookResponseDto Book { get; set; }
        public UserBookResponseDto? UserBook { get; set; }
    }
}
