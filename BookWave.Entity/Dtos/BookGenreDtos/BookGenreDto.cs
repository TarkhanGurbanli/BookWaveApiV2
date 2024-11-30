namespace BookWave.Entity.Dtos.BookGenreDtos;
public record BookGenreDto(
    int Id,
    int BookId,
    int GenreId
    );