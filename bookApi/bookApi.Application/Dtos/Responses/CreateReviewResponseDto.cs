namespace bookApi.Application.Dtos.Responses
{
    public class CreateReviewResponseDto
    {
        public int Id { get; set; }
        public required string UserId { get; set; }
        public required string Content { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
