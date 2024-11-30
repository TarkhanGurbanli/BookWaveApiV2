namespace BookWave.Entity.Dtos.QuoteDtos;
public record QuoteDto(
    int Id,
    string Text,
    int AuthorId,
    int BookId
    );