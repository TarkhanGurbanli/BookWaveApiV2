namespace BookWave.Dto.AuthorDtos;
public record CreateAuthorDto(
    string Name,
    string Nationality,
    string Biography,
    string ImageUrl
    );