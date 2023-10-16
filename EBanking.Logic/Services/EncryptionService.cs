using System.Security.Cryptography;

namespace EBanking.Logic.Services;

public class EncryptionService : IEncryptionService
{
    private readonly int _iterations;
    private readonly int _hashSize;
    private readonly int _saltSize;
    private readonly char _composeSeparator;

    public EncryptionService(int workFactor, int hashSize, int saltSize, char composeSeparator)
    {
        _iterations = workFactor >= 8
            ? (int)Math.Pow(2, workFactor)
            : throw new ArgumentOutOfRangeException(
                nameof(workFactor),
                workFactor,
                $"{nameof(workFactor)} must be greater or equal to 8");

        _hashSize = hashSize >= 8
            ? hashSize
            : throw new ArgumentOutOfRangeException(
                nameof(hashSize),
                hashSize,
                $"{nameof(hashSize)} must be greater or equal to 8");

        _saltSize = saltSize >= 8
            ? saltSize
            : throw new ArgumentOutOfRangeException(
                nameof(saltSize),
                saltSize,
                $"{nameof(saltSize)} must be greater or equal to 8");

        if (char.IsAsciiLetterOrDigit(composeSeparator) || composeSeparator is '+' or '/' or '=')
            throw new ArgumentOutOfRangeException(
                nameof(composeSeparator),
                composeSeparator,
                $"{composeSeparator} must not be a base 64 character");

        if (char.IsControl(composeSeparator))
            throw new ArgumentOutOfRangeException(
                nameof(composeSeparator),
                composeSeparator,
                $"{composeSeparator} must be a printable character");

        _composeSeparator = composeSeparator;
    }

    public IEncryptionService Encrypt(string str, out string hash, out string salt)
    {
        var saltBytes = RandomNumberGenerator.GetBytes(_saltSize);
        var hashBytes = Rfc2898DeriveBytes.Pbkdf2(str, saltBytes, _iterations, HashAlgorithmName.SHA512, _hashSize);
        hash = Convert.ToBase64String(hashBytes);
        salt = Convert.ToBase64String(saltBytes);
        return this;
    }

    public string Compose(string hash, string salt) => hash + _composeSeparator + salt;

    public IEncryptionService Decompose(string str, out string hash, out string salt)
    {
        var strs = str.Split(_composeSeparator);
        hash = strs[0];
        salt = strs[1];
        return this;
    }

    public bool Verify(string str, string hash, string salt)
    {
        var saltBytes = Convert.FromBase64String(salt);
        var hashBytes = Convert.FromBase64String(hash);
        var hashBytesStr = Rfc2898DeriveBytes.Pbkdf2(str, saltBytes, _iterations, HashAlgorithmName.SHA512, _hashSize);
        return ConstantTimeEquals(hashBytes, hashBytesStr);
    }

    private static bool ConstantTimeEquals(byte[] a, byte[] b)
    {
        if (a.Length != b.Length)
            return false;

        byte result = 0;
        for (int i = 0; i < a.Length; i++)
            result |= (byte)(a[i] ^ b[i]);

        return result == 0;
    }
}
