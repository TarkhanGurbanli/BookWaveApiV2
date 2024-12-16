using BookWave.Entity.Base;

namespace BookWave.Entity.Entities;
public class BookCategory : BaseEntity
{
    public int BookId { get; set; }
    public Book Book { get; set; } = default!;
    public int CategoryId { get; set; }
    public Category Category { get; set; } = default!;
}