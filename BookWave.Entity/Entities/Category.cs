using BookWave.Entity.Base;

namespace BookWave.Entity.Entities;
public class Category : BaseEntity
{
    public string Name { get; set; } = default!;
    public List<BookCategory> BookCategories { get; set; } = default!;
}