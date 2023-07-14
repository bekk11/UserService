using System.Security.Cryptography;

namespace NewUserService.Utils;

public class PasswordHasher
{
    public static byte[] GenerateSalt()
    {
        byte[] salt = new byte[16];

        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(salt);
        }

        return salt;
    }
    public static byte[] HashPassword(string password, byte[] salt)
    {
        using (var deriveBytes = new Rfc2898DeriveBytes(password, salt, 10000))
        {
            return deriveBytes.GetBytes(32); // Replace 32 with the desired hash length in bytes
        }
    }
}