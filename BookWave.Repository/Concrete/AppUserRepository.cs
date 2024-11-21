using BookWave.Entity.Entities;
using BookWave.Repository.Abstract;
using BookWave.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace BookWave.Repository.Concrete;
public class AppUserRepository(AppDbContext context) : GenericRepository<AppUser>(context), IAppUserRepository
{
    public async Task<AppUser?> GetUserByEmailOrUsernameAsync(string emailOrUsername)
    {
        return await context.AppUsers
            .FirstOrDefaultAsync(u => u.Email == emailOrUsername || u.Username == emailOrUsername);
    }

    public async Task<AppUser?> GetUserByUsernameAsync(string username)
        => await context.Set<AppUser>()
        .FirstOrDefaultAsync(u => u.Username == username);
}
