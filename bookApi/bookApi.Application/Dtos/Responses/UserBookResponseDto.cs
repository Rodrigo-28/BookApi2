namespace bookApi.Application.Dtos.Responses
{
    public class UserBookResponseDto
    {
        public required ReadingStatusResponseDto Status { get; set; }
        public float Rating { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
