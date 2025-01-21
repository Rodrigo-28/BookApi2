using System.ComponentModel.DataAnnotations.Schema;

namespace bookApi.Domian.Models
{
    [Table("comments")]

    public class Comment
    {
        [Column("comment_id")]
        public int Id { get; set; }

        [Column("content")]
        public required string Content { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [Column("user_id")]
        public int UserId { get; set; }
        public User User { get; set; }

        [Column("review_id")]
        public int ReviewId { get; set; }
        public Review Review { get; set; }
    }
}
