namespace bookApi.Application.Dtos.Request
{
    public class CreateReviewDto
    {
        public required int BookId { get; set; }
        public required string Content { get; set; }
    }
}
