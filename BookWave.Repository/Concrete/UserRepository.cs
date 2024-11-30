using BookWave.Entity.Entities;
using BookWave.Repository.Abstract;
using BookWave.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace BookWave.Repository.Concrete;
public class UserRepository(AppDbContext context) : GenericRepository<User>(context), IUserRepository
{
    public async Task<User?> GetUserByEmailOrUsernameAsync(string emailOrUsername)
    {
        return await context.Users
            .FirstOrDefaultAsync(u => u.Email == emailOrUsername || u.Username == emailOrUsername);
    }

    public async Task<User?> GetUserByUsernameAsync(string username)
        => await context.Set<User>()
        .FirstOrDefaultAsync(u => u.Username == username);
}