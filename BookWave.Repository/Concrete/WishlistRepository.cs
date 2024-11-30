using BookWave.Entity.Entities;
using BookWave.Repository.Abstract;
using BookWave.Repository.Context;

namespace BookWave.Repository.Concrete;
public class WishlistRepository(AppDbContext context) : GenericRepository<Wishlist>(context), IWishlistRepository
{
}