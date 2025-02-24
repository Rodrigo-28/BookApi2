using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookApi.Domian.Models
{
    [Table("books")]

    public class Book : SoftDeletableModel
    {
        [Column("book_id")]
        public int Id { get; set; }

        [Column("title")]
        [Required]
        public string Title { get; set; }

        [Column("author")]
        [Required]
        public string Author { get; set; }

        [Column("publish_year")]
        public int? PublishYear { get; set; }

        [Column("description")]
        [Required]
        public string? Description { get; set; }

        [Column("cover_url")]
        public string? CoverUrl { get; set; }

        [Column("pages")]
        public int? PageCount { get; set; }

        //[Column("created_at")]
        //public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        //[Column("deleted")]
        //public bool Deleted { get; set; } = false;
        //navigation properties
        public ICollection<BookGenre> BookGenres { get; set; } = new List<BookGenre>();
        public ICollection<UserBook> UserBooks { get; set; } = new List<UserBook>(); // Many-to-Many 
        // Many-to-Many 

    }
}
