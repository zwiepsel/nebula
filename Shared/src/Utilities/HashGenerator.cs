using System.Security.Cryptography;
using System.Text;

namespace Nebula.Shared.Utilities;

public static class HashGenerator
{
    public static string Sha1(int input)
    {
        return Sha1(input.ToString());
    }

    public static string Sha1(int? input)
    {
        return Sha1(input.ToString() ?? "");
    }

    public static string Sha1(string input)
    {
        return Hash(SHA1.Create(), input);
    }

    public static string Sha256(int input)
    {
        return Sha256(input.ToString());
    }

    public static string Sha256(string input)
    {
        return Hash(SHA256.Create(), input);
    }

    private static string Hash(HashAlgorithm hashAlgorithm, string input)
    {
        var inputBytes = Encoding.ASCII.GetBytes(input);
        var hashBytes = hashAlgorithm.ComputeHash(inputBytes);

        var hash = new StringBuilder();

        foreach (var hashByte in hashBytes) hash.Append(hashByte.ToString("X2"));

        return hash.ToString();
    }
}