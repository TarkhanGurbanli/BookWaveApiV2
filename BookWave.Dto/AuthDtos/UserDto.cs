namespace BookWave.Dto.AuthDtos;
public class UserDto
{
    public required string UsernameOrEmail { get; set; }
    public required string Password { get; set; }
}
