using Microsoft.AspNetCore.Identity;
namespace server.Services;

public class PasswordService
{
    private readonly IPasswordHasher<object> _passwordHasher;

    public PasswordService()
    {
        _passwordHasher = new PasswordHasher<object>();
    }

    public string HashPassword(string password)
    {
        return _passwordHasher.HashPassword(new object(), password);
    }

    public bool VerifyPassword(string password, string hashedPassword)
    {
        return _passwordHasher.VerifyHashedPassword(new object(), hashedPassword, password) == PasswordVerificationResult.Success;
    }
}
