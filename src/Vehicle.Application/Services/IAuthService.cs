namespace Vehicle.Application.Services;

public interface IAuthService
{
    string GenerateToken(int userId, string login);
    string HashPassword(string password);
    bool VerifyPassword(string password, string hash);
}
