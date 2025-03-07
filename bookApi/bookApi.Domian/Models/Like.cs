using System.ComponentModel.DataAnnotations.Schema;

namespace bookApi.Domian.Models
{
    [Table("likes")]

    public class Like : BaseModel
    {
        [Column("user_id")]
        public int UserId { get; set; }
        public User User { get; set; }

        [Column("review_id")]
        public int ReviewId { get; set; }
        public Review Review { get; set; }
    }
}
