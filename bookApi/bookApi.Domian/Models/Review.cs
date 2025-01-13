using System.ComponentModel.DataAnnotations.Schema;

namespace bookApi.Domian.Models
{
    [Table("reviews")]

    public class Review
    {
        [Column("review_id")]
        public int Id { get; set; }

        [Column("content")]
        public string Content { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;


        [Column("user_id")]

        public int UserId { get; set; }
        public User User { get; set; } //Nav property


        [Column("book_id")]

        public int BookId { get; set; }
        public Book Book { get; set; } //Nav property


        // public int CommentsCount => Comments?.Count ?? 0; // Calculate comments count dynamically
        public int LikesCount => Likes?.Count ?? 0; // Calculate likes count dynamically
                                                    // public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Like> Likes { get; set; } = new List<Like>();
    }
}
