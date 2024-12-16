using BookWave.Entity.Base;

namespace BookWave.Entity.Entities;
public class Book : BaseEntity
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string ImageUrl { get; set; } = default!;
    public double Rating { get; set; } = default!;
    public int PageNumber { get; set; } = default!;
    public int AuthorId { get; set; }
    public Author Author { get; set; } = default!;
    public int PublisherId { get; set; }
    public Publisher Publisher { get; set; } = default!;
    public List<BookCategory> BookCategories { get; set; } = default!;
    public List<BookTag> BookTags { get; set; } = default!;
    public List<Comment> Comments { get; set; } = default!;
    public List<Favorite> Favorites { get; set; } = default!;
    public List<Wishlist> Wishlists { get; set; } = default!;
    public List<Quote>? Quotes { get; set; }
}