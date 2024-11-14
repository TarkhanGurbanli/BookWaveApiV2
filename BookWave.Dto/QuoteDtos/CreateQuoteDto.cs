namespace BookWave.Dto.QuoteDtos;
public record CreateQuoteDto(
    string Text,
    int AuthorId,
    int BookId
    );