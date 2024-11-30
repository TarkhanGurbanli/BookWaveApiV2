namespace BookWave.Entity.Dtos.AuthorDtos;
public record CreateAuthorDto(
    string Name,
    string Nationality,
    string Biography,
    string ImageUrl
    );