using bookApi.Domian.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookApi.Domian.Models
{
    public class TimestampedModel : BaseModel, ITimestampedModel
    {
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
