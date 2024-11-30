namespace BookWave.Entity.Dtos.BookDtos;
public record UpdateBookDto(
    string Name,
    string Description,
    string ImageUrl,
    double Rating,
    int AuthorId,
    int PublisherId
    );