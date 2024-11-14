using BookWave.Entity.Base;

namespace BookWave.Entity.Entities;
public class Comment : BaseEntity
{
    public string Text { get; set; } = default!;
    public int AppUserId { get; set; }
    public AppUser AppUser { get; set; } = default!;
    public int BookId { get; set; }
    public Book Book { get; set; } = default!;
    public int BlogId { get; set; }
    public Blog Blog { get; set; } = default!;
}