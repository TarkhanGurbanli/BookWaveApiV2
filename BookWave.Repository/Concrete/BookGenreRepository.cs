using BookWave.Entity.Entities;
using BookWave.Repository.Abstract;
using BookWave.Repository.Context;

namespace BookWave.Repository.Concrete;
public class BookGenreRepository(AppDbContext context) : GenericRepository<BookGenre>(context), IBookGenreRepository
{
}