using System.Text;

namespace EBanking.Logic;

internal static class Encryption
{
    public static string SHA512(string str)
    {
        Span<byte> bytes = stackalloc byte[Encoding.Unicode.GetByteCount(str)];
        Encoding.Unicode.GetBytes(str, bytes);
        Span<byte> encrypted = stackalloc byte[System.Security.Cryptography.SHA512.HashSizeInBytes];
        System.Security.Cryptography.SHA512.HashData(bytes, encrypted);
        return Encoding.Unicode.GetString(encrypted);
    }
}
