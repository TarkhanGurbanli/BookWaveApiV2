namespace BookWave.Entity.Dtos.QuoteDtos;
public record CreateQuoteDto(
    string Text,
    int AuthorId,
    int BookId
    );