using BookWave.Entity.Entities;

namespace BookWave.Repository.Abstract;
public interface IAuthorRepository : IGenericRepository<Author>
{
    Task<Author?> GetAuthorWithBooksAsync(int id);
    IQueryable<Author?> GetAuthorWithBooksAsync();
    IQueryable<Author?> GetAuthorWithQuotesAsync();
}