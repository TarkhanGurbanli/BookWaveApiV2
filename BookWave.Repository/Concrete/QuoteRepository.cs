using BookWave.Entity.Entities;
using BookWave.Repository.Abstract;
using BookWave.Repository.Context;

namespace BookWave.Repository.Concrete;
public class QuoteRepository(AppDbContext context) : GenericRepository<Quote>(context), IQuoteRepository
{
}