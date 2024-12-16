using BookWave.Entity.Base;

namespace BookWave.Entity.Entities;
public class Tag : BaseEntity
{
    public string Name { get; set; } = default!;
    public List<BookTag> BookTags { get; set; }
}