namespace bookApi.Application.Dtos.Responses
{
    public class ReviewResponseDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Content { get; set; }
        public int CommentsCount { get; set; }
        public int LikesCount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
