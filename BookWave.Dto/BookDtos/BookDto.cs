namespace BookWave.Dto.BookDtos;
public record BookDto(
    int Id,
    string Name,
    string Description,
    string ImageUrl,
    double Rating,
    int AuthorId,
    int PublisherId
    );
/*
    public List<BookGenre> BookGenres { get; set; } = default!;
    public List<Comment> Comments { get; set; } = default!;
    public List<Favorite> Favorites { get; set; } = default!;
    public List<Wishlist> Wishlists { get; set; } = default!;
    public List<Quote>? Quotes { get; set; }
 */