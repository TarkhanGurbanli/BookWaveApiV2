using BookWave.Entity.Base;

namespace BookWave.Entity.Entities;
public class Favorite : BaseEntity
{
    public int UserId { get; set; }
    public User User { get; set; } = default!;
    public int BookId { get; set; }
    public Book Book { get; set; } = default!;
}