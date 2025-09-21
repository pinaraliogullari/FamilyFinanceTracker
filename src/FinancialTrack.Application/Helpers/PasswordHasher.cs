using System.Security.Cryptography;
using System.Text;

namespace FinancialTrack.Application.Helpers;

public static class PasswordHasher
{
    public static string CreateHashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(password);
        var hash = sha256.ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }
    public static bool Verify(string password, string hashedPassword)
    {
        var hashOfInput = CreateHashPassword(password);
        return hashOfInput == hashedPassword;
    }
    
}