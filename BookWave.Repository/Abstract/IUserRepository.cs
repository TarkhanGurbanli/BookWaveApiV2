using BookWave.Entity.Entities;

namespace BookWave.Repository.Abstract;
public interface IUserRepository : IGenericRepository<User>
{
    Task<User?> GetUserByEmailOrUsernameAsync(string emailOrUsername);
    Task<User?> GetUserByUsernameAsync(string username);
}