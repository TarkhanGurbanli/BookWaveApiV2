namespace BookWave.Repository.UOW;
public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}
