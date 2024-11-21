using Newtonsoft.Json;
using System.Text;

namespace BookWave.Service.Utils;
public class JwtUtil
{
    public T DecodeToken<T>(string authHeader) where T : class
    {
        if (string.IsNullOrWhiteSpace(authHeader) || !authHeader.StartsWith("Bearer "))
            throw new ArgumentException("Invalid Authorization header.");

        string token = authHeader.Substring(7);
        var payload = DecodePayload(token);

        return JsonConvert.DeserializeObject<T>(payload)
               ?? throw new InvalidOperationException("Failed to deserialize JWT payload.");
    }

    private string DecodePayload(string token)
    {
        var tokenParts = token.Split('.');
        if (tokenParts.Length != 3)
            throw new ArgumentException("Invalid JWT token.");

        return Encoding.UTF8.GetString(Base64UrlDecode(tokenParts[1]));
    }

    private static byte[] Base64UrlDecode(string input)
    {
        string paddedInput = input.Replace('-', '+').Replace('_', '/');
        paddedInput = paddedInput.PadRight(paddedInput.Length + (4 - paddedInput.Length % 4) % 4, '=');
        return Convert.FromBase64String(paddedInput);
    }
}

