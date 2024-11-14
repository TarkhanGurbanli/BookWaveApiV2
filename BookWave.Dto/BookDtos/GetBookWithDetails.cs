using BookWave.Dto.CommentDtos;

namespace BookWave.Dto.BookDtos;
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