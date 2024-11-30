using BookWave.Entity.Dtos.CommentDtos;

namespace BookWave.Entity.Dtos.BookDtos;
public record GetBookWithDetails(
     int Id,
    string Name,
    string Description,
    string ImageUrl,
    double Rating,
    string AuthorName,
    string PublisherName,
    List<string> BookGenreNames,
    List<CommentDto> Comments
    );