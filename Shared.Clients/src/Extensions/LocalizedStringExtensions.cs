using Microsoft.Extensions.Localization;

namespace Nebula.Shared.Clients.Extensions;

public static class LocalizedStringExtensions
{
    public static string ToLower(this LocalizedString localizedString)
    {
        return localizedString.ToString().ToLower();
    }
}