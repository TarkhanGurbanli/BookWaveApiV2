using BookWave.Entity.Base;

namespace BookWave.Entity.Entities;
public class Comment : BaseEntity
{
    public string Text { get; set; } = default!;
    public int UserId { get; set; }
    public User User { get; set; } = default!;
    public int BookId { get; set; }
    public Book Book { get; set; } = default!;
    public int BlogId { get; set; }
    public Blog Blog { get; set; } = default!;
}