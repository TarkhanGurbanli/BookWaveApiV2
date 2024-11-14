using BookWave.Entity.Base;

namespace BookWave.Entity.Entities;
public class Favorite : BaseEntity
{
    public int AppUserId { get; set; }
    public AppUser AppUser { get; set; } = default!;
    public int BookId { get; set; }
    public Book Book { get; set; } = default!;
}