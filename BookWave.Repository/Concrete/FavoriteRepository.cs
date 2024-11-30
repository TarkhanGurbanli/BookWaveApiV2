using BookWave.Entity.Entities;
using BookWave.Repository.Abstract;
using BookWave.Repository.Context;

namespace BookWave.Repository.Concrete;
public class FavoriteRepository(AppDbContext context) : GenericRepository<Favorite>(context), IFavoriteRepository
{
}