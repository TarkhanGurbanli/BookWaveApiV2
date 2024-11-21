namespace BookWave.Dto.AuthDtos;
public record LoginResponse(
    bool Flag,
    string Message = null!,
    string Token = null!
    );