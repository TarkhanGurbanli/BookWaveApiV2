using System.ComponentModel.DataAnnotations;

namespace BookWave.Dto.AuthDtos;
public class RegisterDto
{
    public required string Username { get; set; } = string.Empty;
    [EmailAddress]
    public required string Email { get; set; } = string.Empty;
    public required string Password { get; set; } = string.Empty;
    [Compare(nameof(Password))]
    public required string ConfirmPassword { get; set; } = string.Empty;
}