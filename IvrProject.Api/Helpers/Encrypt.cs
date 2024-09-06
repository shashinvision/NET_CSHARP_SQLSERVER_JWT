using System;
using System.Security.Cryptography;
using System.Text;
using System.Linq.Expressions;


namespace SQL_SERVER_API.Helpers;

public static class EncryptString
{
    public static string EncryptPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        var encryptedPassword = Convert.ToBase64String(bytes);
        return encryptedPassword;
    }

    public static bool VerifyPassword(string password, string hashedPassword)
    {
        using var sha256 = SHA256.Create();
        var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        var hashedInput = Convert.ToBase64String(bytes);
        return hashedInput == hashedPassword;
    }

}
