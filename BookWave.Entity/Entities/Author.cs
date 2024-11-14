using BookWave.Entity.Base;

namespace BookWave.Entity.Entities;
public class Author : BaseEntity
{
    public string Name { get; set; } = default!;
    public string Nationality { get; set; } = default!;
    public string Biography { get; set; } = default!;
    public string ImageUrl { get; set; } = default!;
    public List<Book>? Books { get; set; }
    public List<Quote>? Quotes { get; set; }
}