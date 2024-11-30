using BookWave.Entity.Entities;

namespace BookWave.Repository.Abstract;
public interface IBookRepository : IGenericRepository<Book>
{
    Task<Book?> GetBookWithDetails(int bookId);
}