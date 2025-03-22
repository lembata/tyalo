using System.Security.Cryptography;
using System.Text;

namespace Tyalo.Services;

public class Password
{
    public static byte[] GenerateSalt()
    {
        return RandomNumberGenerator.GetBytes(32);
    }

    public static byte[] Hash(string password, IReadOnlyCollection<byte> salt)
    {
        var passwordBytes = Encoding.UTF8.GetBytes(password);
        using SHA256 mySHA256 = SHA256.Create() ;
        var hash = mySHA256.ComputeHash(salt.Concat(passwordBytes).ToArray().Concat(salt).ToArray());
        return hash;
    }

    public static bool Verify(string password, IReadOnlyCollection<byte> salt, IReadOnlyCollection<byte> hash)
    {
        byte[] newHash = Hash(password, salt);
        return newHash.SequenceEqual(hash);
    }
}