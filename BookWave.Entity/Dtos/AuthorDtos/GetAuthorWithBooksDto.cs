namespace BookWave.Entity.Dtos.AuthorDtos;
public record GetAuthorWithBooksDto(
    int Id,
    string Name,
    int BookId,
    string BookName,
    string ImageUrl,
    double Rating,
    string PublisherName
    );