namespace BookWave.Entity.Dtos.AuthorDtos;
public record GetAuthorWithQuotes(
    int Id,
    string Name,
    int QuoteId,
    string Text,
    string BookName
    );