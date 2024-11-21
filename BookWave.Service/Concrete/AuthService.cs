using AutoMapper;
using BookWave.Dto.AuthDtos;
using BookWave.Entity.Entities;
using BookWave.Entity.Enums;
using BookWave.Repository.Abstract;
using BookWave.Repository.UOW;
using BookWave.Service.Abstract;
using BookWave.Service.Result;
using BookWave.Service.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace BookWave.Service.Concrete;
public class AuthService(IAppUserRepository repository, IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration, JwtUtil jwtUtil) : IAuthService
{
    public async Task<ServiceResult> ChangePasswordAsync(string authHeader, ChangePasswordDto dto)
    {
        if (string.IsNullOrEmpty(authHeader))
            return ServiceResult.Fail("Authorization header is missing.", HttpStatusCode.BadRequest);

        var user = await GetUserFromAuthHeaderAsync(authHeader);
        if (user == null)
            return ServiceResult.Fail("User not found.", HttpStatusCode.NotFound);

        if (string.IsNullOrWhiteSpace(dto.CurrentPassword) || string.IsNullOrWhiteSpace(dto.NewPassword))
            return ServiceResult.Fail("Current and new passwords are required.", HttpStatusCode.BadRequest);

        if (!VerifyPassword(dto.CurrentPassword, user.Password))
            return ServiceResult.Fail("Current password is incorrect.", HttpStatusCode.Unauthorized);

        user.Password = HashPassword(dto.NewPassword);

        try
        {
            await UpdateUserAsync(user);
            return ServiceResult.Success(HttpStatusCode.OK);
        }
        catch (Exception ex)
        {
            // Loglama yapılabilir
            return ServiceResult.Fail($"An error occurred while updating the password: {ex.Message}", HttpStatusCode.InternalServerError);
        }
    }


    public async Task<ServiceResult> ChangeUsernameAsync(string authHeader, ChangeUsernameDto dto)
    {
        var user = await GetUserFromAuthHeaderAsync(authHeader);
        if (user == null) return ServiceResult.Fail("User not found.", HttpStatusCode.NotFound);

        if (await repository.GetUserByUsernameAsync(dto.NewUsername) != null)
            return ServiceResult.Fail("Username already taken.", HttpStatusCode.Conflict);

        user.Username = dto.NewUsername;
        await UpdateUserAsync(user);

        return ServiceResult.Success(HttpStatusCode.OK);
    }

    public async Task<LoginResponse> LoginUserAsync(LoginDto request)
    {
        var user = await repository.GetUserByEmailOrUsernameAsync(request.EmailOrUsername);
        if (user == null) return new LoginResponse(false, "User not found.");

        if (!VerifyPassword(request.Password, user.Password))
            return new LoginResponse(false, "Invalid password.");

        string token = GenerateJwtToken(user);
        return new LoginResponse(true, "Login successful.", token);
    }

    public async Task<RegistrationResponse> RegisterUserAsync(RegisterDto request)
    {
        if (await repository.GetUserByEmailOrUsernameAsync(request.Email) != null)
            return new RegistrationResponse(false, "User with this email already exists.");

        var newUser = mapper.Map<AppUser>(request);
        newUser.Password = HashPassword(request.Password);
        newUser.Role = Role.User;

        await repository.AddAsync(newUser);
        await unitOfWork.SaveChangesAsync();

        return new RegistrationResponse(true, "Registration successful.");
    }

    public async Task<ServiceResult> ChangeUserRoleAsync(int userId)
    {
        var user = await repository.GetByIdAsync(userId);
        if (user == null) return ServiceResult.Fail("User not found.", HttpStatusCode.NotFound);

        user.Role = user.Role == Role.User ? Role.Admin : Role.User;
        await UpdateUserAsync(user);

        return ServiceResult.Success(HttpStatusCode.OK);
    }

    private async Task<AppUser?> GetUserFromAuthHeaderAsync(string authHeader)
    {
        if (string.IsNullOrEmpty(authHeader)) return null;

        try
        {
            var jwtModel = jwtUtil.DecodeToken<JwtModel>(authHeader);
            return await repository.GetByIdAsync(jwtModel.NameId);
        }
        catch
        {
            return null;
        }
    }

    private bool VerifyPassword(string plainTextPassword, string hashedPassword)
        => BCrypt.Net.BCrypt.Verify(plainTextPassword, hashedPassword);

    private string HashPassword(string password)
        => BCrypt.Net.BCrypt.HashPassword(password);

    private async Task UpdateUserAsync(AppUser user)
    {
        repository.Update(user);
        await unitOfWork.SaveChangesAsync();
    }

    private string GenerateJwtToken(AppUser user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(configuration["Jwt:Key"]!);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}