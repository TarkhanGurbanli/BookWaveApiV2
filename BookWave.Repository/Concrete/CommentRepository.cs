using BookWave.Entity.Entities;
using BookWave.Repository.Abstract;
using BookWave.Repository.Context;

namespace BookWave.Repository.Concrete;
public class CommentRepository(AppDbContext context) : GenericRepository<Comment>(context), ICommentRepository
{
}