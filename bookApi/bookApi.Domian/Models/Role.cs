using System.ComponentModel.DataAnnotations.Schema;

namespace bookApi.Domian.Models
{
    [Table("roles")]
    public class Role
    {
        [Column("role_id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
