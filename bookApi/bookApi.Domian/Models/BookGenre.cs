using System.ComponentModel.DataAnnotations.Schema;

namespace bookApi.Domian.Models
{

    [Table("book_genre")]
    public class BookGenre
    {
        [Column("book_id")]
        public int BookId { get; set; }
        public Book Book { get; set; }
        [Column("genre_id")]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
