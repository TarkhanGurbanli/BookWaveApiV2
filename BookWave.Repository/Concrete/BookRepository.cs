using BookWave.Entity.Entities;
using BookWave.Repository.Abstract;
using BookWave.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace BookWave.Repository.Concrete;
public class BookRepository(AppDbContext context) : GenericRepository<Book>(context), IBookRepository
{
    public async Task<Book?> GetBookWithDetails(int bookId)
    {
        var book = await context.Books
           .Include(b => b.Author)
           .Include(b => b.Publisher)
           .Include(b => b.BookGenres)
               .ThenInclude(bg => bg.Genre)
           .Include(b => b.Comments)
               .ThenInclude(c => c.User)
           .FirstOrDefaultAsync(b => b.Id == bookId);

        if (book is null)
            return null;

        return book;
    }
}