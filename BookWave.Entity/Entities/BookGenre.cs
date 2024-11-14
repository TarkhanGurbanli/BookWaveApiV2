using BookWave.Entity.Base;

namespace BookWave.Entity.Entities;
public class BookGenre : BaseEntity
{
    public int BookId { get; set; }
    public Book Book { get; set; } = default!;
    public int GenreId { get; set; }
    public Genre Genre { get; set; } = default!;
}