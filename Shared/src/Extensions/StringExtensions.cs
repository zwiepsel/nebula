using System.Linq;
using System.Text;

namespace Nebula.Shared.Extensions;

public static class StringExtensions
{
    public static string FirstCharToUpper(this string input)
    {
        return input.First().ToString().ToUpper() + input.Substring(1);
    }

    public static string SplitPascalCase(this string input)
    {
        if (string.IsNullOrEmpty(input)) return input;

        var value = new StringBuilder(input.Length + 5);

        for (var i = 0; i < input.Length; ++i)
        {
            var currentChar = input[i];

            if (char.IsUpper(currentChar))
                if (i > 1 && !char.IsUpper(input[i - 1]) || i + 1 < input.Length && !char.IsUpper(input[i + 1]))
                    value.Append(' ');

            if (!Equals('.', currentChar) || i + 1 == input.Length || !char.IsUpper(input[i + 1])) value.Append(currentChar);
        }

        return value.ToString().Trim();
    }

    public static string? TruncateWithEllipsis(this string? value, int length, string ellipsis = "...")
    {
        if (value != null && value.Length > length && length > ellipsis.Length)
            return value.Substring(0, length - ellipsis.Length) + ellipsis;

        return value;
    }

    public static bool IsNullOrEmpty(this string? value)
    {
        return value == null || 0u >= (uint)value.Length;
    }

    public static bool IsNullOrWhitespace(this string? value)
    {
        if (value == null) return true;

        for (var i = 0; i < value.Length; i++)
            if (!char.IsWhiteSpace(value[i]))
                return false;

        return true;
    }
}