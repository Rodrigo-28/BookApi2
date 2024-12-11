namespace bookApi.Application.Dtos.Request
{
    public class CreateBookDto
    {
        public required string Title { get; set; }
        public required string Author { get; set; }
        public int? PublishYear { get; set; }
        public string? Description { get; set; }
        public string? CoverUrl { get; set; }
        public int? PageCount { get; set; }
        public List<int>? GenreIds { get; set; }
    }
}
