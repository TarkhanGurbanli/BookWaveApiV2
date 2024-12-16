using BookWave.Entity.Entities;

namespace BookWave.Entity.Dtos.BlogDtos;

public record CreateBlogDto(string Title, string Content, int UserId, List<PhotoFile>? Images);
