namespace BookWave.Dto.BookDtos;
public record UpdateBookDto(
    string Name,
    string Description,
    string ImageUrl,
    double Rating,
    int AuthorId,
    int PublisherId
    );