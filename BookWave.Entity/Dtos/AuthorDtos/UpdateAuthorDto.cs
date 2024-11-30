namespace BookWave.Entity.Dtos.AuthorDtos;
public record UpdateAuthorDto(
    string Name,
    string Nationality,
    string Biography,
    string ImageUrl
    );