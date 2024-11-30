using BookWave.Entity.Entities;
using BookWave.Repository.Abstract;
using BookWave.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace BookWave.Repository.Concrete;
public class AuthorRepository(AppDbContext context) : GenericRepository<Author>(context), IAuthorRepository
{
    public Task<Author?> GetAuthorWithBooksAsync(int id)
    {
        return context.Author
            .Include(x => x.Books!)
                .ThenInclude(b => b.Publisher)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public IQueryable<Author?> GetAuthorWithBooksAsync()
    {
        return context.Author
            .Include(x => x.Books!)
                .ThenInclude(b => b.Publisher)
            .AsQueryable();
    }

    public IQueryable<Author?> GetAuthorWithQuotesAsync()
    {
        return context.Author
            .Include(x => x.Quotes!)
                .ThenInclude(b => b.Book)
            .AsQueryable();
    }
}