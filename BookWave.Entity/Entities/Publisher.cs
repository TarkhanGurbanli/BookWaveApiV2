using BookWave.Entity.Base;

namespace BookWave.Entity.Entities;
public class Publisher : BaseEntity
{
    public string Name { get; set; } = default!;
    public List<Book>? Books { get; set; }
}