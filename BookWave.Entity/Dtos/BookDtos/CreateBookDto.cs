namespace BookWave.Entity.Dtos.BookDtos;
public record CreateBookDto(
    string Name,
    string Description,
    string ImageUrl,
    double Rating,
    int AuthorId,
    int PublisherId
    );