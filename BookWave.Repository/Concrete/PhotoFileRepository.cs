using BookWave.Entity.Entities;
using BookWave.Repository.Abstract;
using BookWave.Repository.Context;

namespace BookWave.Repository.Concrete;
public class PhotoFileRepository(AppDbContext context) : GenericRepository<PhotoFile>(context), IPhotoFileRepository
{
}