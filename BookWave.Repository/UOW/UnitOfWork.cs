using BookWave.Repository.Context;

namespace BookWave.Repository.UOW;
public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task<int> SaveChangesAsync()
        => await context.SaveChangesAsync();
}