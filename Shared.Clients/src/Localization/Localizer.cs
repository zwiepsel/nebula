using Microsoft.Extensions.Localization;
using Nebula.Shared.Clients.Resources;

namespace Nebula.Shared.Clients.Localization;

public class Localizer<T> : ILocalizer<T> where T : class
{
    private readonly IStringLocalizer<Translations> coreStringLocalizer;
    private readonly IStringLocalizer<T> stringLocalizer;

    public Localizer(IStringLocalizer<T> stringLocalizer, IStringLocalizer<Translations> coreStringLocalizer)
    {
        this.stringLocalizer = stringLocalizer;
        this.coreStringLocalizer = coreStringLocalizer;
    }

    public virtual LocalizedString this[string name]
    {
        get
        {
            var value = stringLocalizer[name];

            return name != value ? value : coreStringLocalizer[name];
        }
    }

    public LocalizedString this[string name, params object[] arguments]
    {
        get
        {
            var value = stringLocalizer[name, arguments];

            return name != value ? value : coreStringLocalizer[name, arguments];
        }
    }
}