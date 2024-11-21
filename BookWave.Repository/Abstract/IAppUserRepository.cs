using BookWave.Entity.Entities;

namespace BookWave.Repository.Abstract;
public interface IAppUserRepository : IGenericRepository<AppUser>
{
    Task<AppUser?> GetUserByEmailOrUsernameAsync(string emailOrUsername);
    Task<AppUser?> GetUserByUsernameAsync(string username);
}
