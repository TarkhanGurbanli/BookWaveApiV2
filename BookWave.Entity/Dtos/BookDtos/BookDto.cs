namespace BookWave.Entity.Dtos.BookDtos;
public record BookDto(
    int Id,
    string Name,
    string Description,
    string ImageUrl,
    double Rating,
    int AuthorId,
    int PublisherId
    );