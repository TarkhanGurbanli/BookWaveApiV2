using BookWave.Dto.AuthDtos;
using BookWave.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BookWave.WebAPI.Controllers;
public class AuthsController(IAuthService service) : CustomBaseController
{

    [HttpPost("register")]
    [ProducesResponseType(typeof(RegistrationResponse), 200)]
    public async Task<IActionResult> Register([FromBody] RegisterDto request)
        => Ok(await service.RegisterUserAsync(request));

    [HttpPost("login")]
    [ProducesResponseType(typeof(LoginResponse), 200)]
    public async Task<IActionResult> Login([FromBody] LoginDto request)
        => Ok(await service.LoginUserAsync(request));

    [HttpPatch("change-password/{token}")]
    public async Task<IActionResult> ChangePassword(
        [FromHeader(Name = "Authorization")] string token,
        [FromBody] ChangePasswordDto request)
    {
        await service.ChangePasswordAsync(token, request);
        return NoContent(); 
    }

    [HttpPatch("change-username/{token}")]
    public async Task<IActionResult> ChangeUsername(
        [FromHeader(Name = "Authorization")] string token,
        [FromBody] ChangeUsernameDto request)
    {
        await service.ChangeUsernameAsync(token, request);
        return NoContent();
    }

    [HttpPatch("change-role/{userId:int}")]
    public async Task<IActionResult> ChangeRole(int userId)
    {
       await service.ChangeUserRoleAsync(userId);
        return NoContent();
    }
}
