namespace Nebula.Clients.FCB.Apps.Portal.Shared.Extensions;

public static class DecimalExtensions
{
    public static string FormatMoney(this decimal? value)
    {
        return value != null ? DoFormatMoney(value.Value) : "-";
    }

    public static string FormatMoney(this decimal value)
    {
        return DoFormatMoney(value);
    }

    private static string DoFormatMoney(decimal value)
    {
        return $"${value:#,##0.00}";
    }
}