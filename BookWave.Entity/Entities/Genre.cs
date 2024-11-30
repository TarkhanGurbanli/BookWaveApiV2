using BookWave.Entity.Base;

namespace BookWave.Entity.Entities;
public class Genre : BaseEntity
{
    public string Name { get; set; } = default!;
    public List<BookGenre> BookGenres { get; set; } = default!;
}