using System;

namespace Nebula.Shared.Extensions;

public static class DateTimeExtensions
{
    public static string FormatDate(this DateTime dateTime, bool convertFromUtc = true)
    {
        return dateTime != DateTime.MinValue ? ToLocal(dateTime, convertFromUtc).ToString("dd-MMM-yyyy") : "";
    }

    public static string FormatDate(this DateTime? dateTime, bool convertFromUtc = false)
    {
        return dateTime != null ? ToLocal(dateTime.Value, convertFromUtc).ToString("dd-MMM-yyyy") : "-";
    }

    public static string FormatDateTime(this DateTime dateTime, bool convertFromUtc = true)
    {
        return dateTime != DateTime.MinValue ? ToLocal(dateTime, convertFromUtc).ToString("dd-MMM-yyyy HH:mm:ss") : "";
    }

    public static string FormatDateTime(this DateTime? dateTime, bool convertFromUtc = true)
    {
        return dateTime != null ? ToLocal(dateTime.Value, convertFromUtc).ToString("dd-MMM-yyyy HH:mm:ss") : "-";
    }

    private static DateTime ToLocal(this DateTime dateTime, bool convertFromUtc)
    {
        return convertFromUtc
            ? TimeZoneInfo.ConvertTimeFromUtc(dateTime, TimeZoneInfo.FindSystemTimeZoneById(TimeZoneInfo.Local.Id))
            : dateTime;
    }

    public static DateTime StartOfDay(this DateTime date)
    {
        return date.Date;
    }

    public static DateTime EndOfDay(this DateTime date)
    {
        return date.Date.AddDays(1).AddTicks(-1);
    }

    public static int ToAge(this DateTime dateTime, bool convertFromUtc = true)
    {
        var today = ToLocal(DateTime.UtcNow, convertFromUtc);
        var age = today.Year - dateTime.Year;

        if (today < dateTime.AddYears(age)) age--;

        return age;
    }

    public static int DaysSinceNow(this DateTime? dateTime, bool convertFromUtc = true)
    {
        return dateTime == null ? 0 : DaysSinceNow(dateTime.Value, convertFromUtc);
    }

    public static int DaysSinceNow(this DateTime dateTime, bool convertFromUtc = true)
    {
        var today = ToLocal(DateTime.UtcNow, convertFromUtc);

        return (today - dateTime).Days;
    }
}