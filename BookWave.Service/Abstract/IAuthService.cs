using BookWave.Dto.AuthDtos;
using BookWave.Service.Result;

namespace BookWave.Service.Abstract;
public interface IAuthService
{
    Task<RegistrationResponse> RegisterUserAsync(RegisterDto request);
    Task<LoginResponse> LoginUserAsync(LoginDto request);
    Task<ServiceResult> ChangePasswordAsync(string authHeader, ChangePasswordDto dto);
    Task<ServiceResult> ChangeUsernameAsync(string authHeader, ChangeUsernameDto dto);
    Task<ServiceResult> ChangeUserRoleAsync(int userId);
}
