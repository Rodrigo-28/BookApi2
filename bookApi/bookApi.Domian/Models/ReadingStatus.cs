using System.ComponentModel.DataAnnotations.Schema;

namespace bookApi.Domian.Models
{
    [Table("reading_statuses")]

    public class ReadingStatus
    {
        [Column("reding_status_id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }

        public ICollection<UserBook> UserBooks { get; set; } = new List<UserBook>();
    }
}
