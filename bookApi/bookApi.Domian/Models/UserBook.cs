using System.ComponentModel.DataAnnotations.Schema;

namespace bookApi.Domian.Models
{
    [Table("user_book")]

    public class UserBook
    {
        [Column("user_id")]

        public int UserId { get; set; }
        public User User { get; set; }
        [Column("book_id")]

        public int BookId { get; set; }
        public Book Book { get; set; }
        [Column("reading_status")]
        public int ReadingStatusId { get; set; }
        public ReadingStatus ReadingStatus { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [Column("rating")]
        public float Rating { get; set; } = 0.0f;
    }
}
