namespace BookWave.Entity.Dtos.AuthorDtos;
public record AuthorDto(
    int Id,
    string Name,
    string Nationality,
    string Biography,
    string ImageUrl
    );