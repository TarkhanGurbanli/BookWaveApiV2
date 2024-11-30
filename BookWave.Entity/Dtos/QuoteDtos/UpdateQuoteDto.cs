namespace BookWave.Entity.Dtos.QuoteDtos;
public record UpdateQuoteDto(
    string Text,
    int AuthorId,
    int BookId
    );