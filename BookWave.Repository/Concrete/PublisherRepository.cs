using BookWave.Entity.Entities;
using BookWave.Repository.Abstract;
using BookWave.Repository.Context;

namespace BookWave.Repository.Concrete;
public class PublisherRepository(AppDbContext context) : GenericRepository<Publisher>(context), IPubLisherRepository
{
}