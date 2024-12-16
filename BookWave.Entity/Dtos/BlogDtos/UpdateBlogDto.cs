using BookWave.Entity.Entities;

namespace BookWave.Entity.Dtos.BlogDtos;

public record UpdateBlogDto(string Title, string Content, List<PhotoFile>? Images);
