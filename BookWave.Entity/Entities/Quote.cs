using BookWave.Entity.Base;

namespace BookWave.Entity.Entities;
public class Quote : BaseEntity
{
    public string Text { get; set; } = default!;
    public int AuthorId { get; set; }
    public Author Author { get; set; } = default!;
    public int BookId { get; set; }
    public Book Book { get; set; } = default!;
}