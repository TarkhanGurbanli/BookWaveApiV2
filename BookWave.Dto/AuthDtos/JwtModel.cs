namespace BookWave.Dto.AuthDtos;
public class JwtModel
{
    public int NameId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty; 
}
