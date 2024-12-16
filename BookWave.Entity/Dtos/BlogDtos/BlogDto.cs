namespace BookWave.Entity.Dtos.BlogDtos;

public record BlogDto(int Id, string Title, string Content, List<string> ImageKeys, DateTime CreatedDate, DateTime UpdatedDate);
