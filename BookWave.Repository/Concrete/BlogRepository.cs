using BookWave.Entity.Entities;
using BookWave.Repository.Abstract;
using BookWave.Repository.Context;

namespace BookWave.Repository.Concrete;
public class BlogRepository(AppDbContext context) : GenericRepository<Blog>(context), IBlogRepository
{
}