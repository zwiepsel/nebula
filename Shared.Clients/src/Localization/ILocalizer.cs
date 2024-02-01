using Microsoft.Extensions.Localization;

namespace Nebula.Shared.Clients.Localization;

// ReSharper disable once UnusedTypeParameter
public interface ILocalizer<T> where T : class
{
    public LocalizedString this[string name] { get; }
    public LocalizedString this[string name, params object[] arguments] { get; }
}