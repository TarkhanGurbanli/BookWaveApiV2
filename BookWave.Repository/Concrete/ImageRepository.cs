using BookWave.Entity.Entities;
using BookWave.Repository.Abstract;
using BookWave.Repository.Context;

namespace BookWave.Repository.Concrete;
public class ImageRepository(AppDbContext context) : GenericRepository<Image>(context), IImageRepository
{
}
