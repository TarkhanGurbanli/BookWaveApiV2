using BookWave.Entity.Entities;
using BookWave.Repository.Abstract;
using BookWave.Repository.Context;

namespace BookWave.Repository.Concrete;
public class GenreRepository(AppDbContext context) : GenericRepository<Category>(context), IGenreRepository
{
}