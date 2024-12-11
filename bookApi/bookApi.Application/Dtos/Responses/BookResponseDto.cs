namespace bookApi.Application.Dtos.Responses
{
    public class BookResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublishYear { get; set; }
        public string Description { get; set; }
        public string CoverUrl { get; set; }
        public int PageCount { get; set; }
        public List<GenreResponseDto> Genres { get; set; }

    }
}
