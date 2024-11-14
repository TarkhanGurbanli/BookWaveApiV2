namespace BookWave.Dto.BookDtos;
public record CreateBookDto(
    string Name,
    string Description,
    string ImageUrl,
    double Rating,
    int AuthorId,
    int PublisherId
    );