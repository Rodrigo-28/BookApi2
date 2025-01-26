using bookApi.Domian.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookApi.Domian.Models
{
    public class SoftDeletableModel : TimestampedModel, ISoftDeletable
    {
        [Column("deleted")]
        public bool Deleted { get; set; }
    }
}
