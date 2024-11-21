namespace BookWave.Dto.AuthDtos;
public record RegistrationResponse(
    bool Flag,
    string Message = null!
    );