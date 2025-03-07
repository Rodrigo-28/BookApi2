namespace bookApi.Application.Dtos.Responses
{
    public class CommentDto
    {
        public int Id { get; set; }
        public required string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
