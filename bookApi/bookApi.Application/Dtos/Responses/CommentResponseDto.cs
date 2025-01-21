namespace bookApi.Application.Dtos.Responses
{
    public class CommentResponseDto
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public int ReviewId { get; set; }
        public required string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
