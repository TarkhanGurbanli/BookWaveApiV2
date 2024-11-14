namespace BookWave.Dto.QuoteDtos;
public record UpdateQuoteDto(
    string Text,
    int AuthorId,
    int BookId
    );