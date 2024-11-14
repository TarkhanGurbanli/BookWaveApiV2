using BookWave.Entity.Entities;
using BookWave.Repository.Abstract;
using BookWave.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWave.Repository.Concrete;
public class WishlistRepository(AppDbContext context) : GenericRepository<Wishlist>(context), IWishlistRepository
{
}
