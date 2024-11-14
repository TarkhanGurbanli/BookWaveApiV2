namespace BookWave.Dto.AuthorDtos;
public record UpdateAuthorDto(
    string Name,
    string Nationality,
    string Biography,
    string ImageUrl
    );