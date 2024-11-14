namespace BookWave.Dto.AuthorDtos;
public record GetAuthorWithQuotes(
    int Id,
    string Name,
    int QuoteId,
    string Text,
    string BookName
    );