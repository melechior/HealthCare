using System.Globalization;

namespace HealthCare.Infrastructures.Shared.Helpers;

public static class DateConverter
{
    public static bool? IsNumber(this string? value)
    {
        if (value == null)
        {
            return null;
        }

        try
        {
            var int64 = Convert.ToInt64(value);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public static DateTime? JalaliToGregorianDate(this string jalaliDate)
    {
        if (string.IsNullOrEmpty(jalaliDate))
        {
            return null;
        }

        string[] dateSplit;
        dateSplit = jalaliDate.Split(jalaliDate.IndexOf('-') != -1 ? '-' : '/');

        var p = new PersianCalendar();
        return new DateTime(Convert.ToInt32(dateSplit[0]), Convert.ToInt32(dateSplit[1]),
            Convert.ToInt32(dateSplit[2]), p);
    }

    public static string GeorgianDateToPersianDate(this DateTime dateTime, char separator)
    {
        var p = new PersianCalendar();
        return
            $"{p.GetYear(dateTime):0000}{separator}{p.GetMonth(dateTime):00}{separator}{p.GetDayOfMonth(dateTime):00}";
    }

    public static string GeorgianDateToPersianDate(this DateTime? dateTime)
    {
        if (!dateTime.HasValue) return null;
        var p = new PersianCalendar();

        return
            $"{p.GetYear(dateTime.Value):0000}/{p.GetMonth(dateTime.Value):00}/{p.GetDayOfMonth(dateTime.Value):00}";
    }

    public static string GeorgianDateToPersianDate(this DateTime dateTime)
    {
        var p = new PersianCalendar();

        return
            $"{p.GetYear(dateTime):0000}/{p.GetMonth(dateTime):00}/{p.GetDayOfMonth(dateTime):00}";
    }

    public static string GeorgianDateToPersianDate(this DateTime? dateTime, char separator)
    {
        if (!dateTime.HasValue) return null;
        var p = new PersianCalendar();

        return
            $"{p.GetYear(dateTime.Value):0000}{separator}{p.GetMonth(dateTime.Value):00}{separator}{p.GetDayOfMonth(dateTime.Value):00}";
    }

    public static string GeorgianDateTimeToPersianDateTime(this DateTime dateTime)
    {
        var p = new PersianCalendar();

        return
            $"{p.GetYear(dateTime):0000}/{p.GetMonth(dateTime):00}/{p.GetDayOfMonth(dateTime):00}-{p.GetHour(dateTime):00}:{p.GetMinute(dateTime):00}";
    }

    public static string GeorgianDateTimeToPersianDateTime(this DateTime dateTime, char separator)
    {
        var p = new PersianCalendar();

        return
            $"{p.GetYear(dateTime):0000}{separator}{p.GetMonth(dateTime):00}{separator}{p.GetDayOfMonth(dateTime):00}{separator}{p.GetHour(dateTime):00}{separator}{p.GetMinute(dateTime):00}";
    }

    public static string GeorgianDateTimeToPersianDateTime(this DateTime? dateTime)
    {
        if (!dateTime.HasValue) return null;
        var p = new PersianCalendar();

        return
            $"{p.GetYear(dateTime.Value):0000}/{p.GetMonth(dateTime.Value):00}/{p.GetDayOfMonth(dateTime.Value):00}-{p.GetHour(dateTime.Value):00}:{p.GetMinute(dateTime.Value):00}";
    }

    public static string GeorgianDateTimeToPersianDateTime(this DateTime? dateTime, char separator)
    {
        if (!dateTime.HasValue) return null;
        var p = new PersianCalendar();

        return
            $"{p.GetYear(dateTime.Value):0000}{separator}{p.GetMonth(dateTime.Value):00}{separator}{p.GetDayOfMonth(dateTime.Value):00}{separator}{p.GetHour(dateTime.Value):00}{separator}{p.GetMinute(dateTime.Value):00}";
    }

    public static int GetPersianYearFromGeorgianDate(this DateTime dateTime)
    {
        var p = new PersianCalendar();
        return p.GetYear(dateTime);
    }

    public static int GetPersianMonthFromGeorgianDate(this DateTime dateTime)
    {
        var p = new PersianCalendar();
        return p.GetMonth(dateTime);
    }

    public static int GetPersianDayFromGeorgianDate(this DateTime dateTime)
    {
        var p = new PersianCalendar();
        return p.GetDayOfMonth(dateTime);
    }

    public static string CorrectNationalId(this string nationalId)
    {
        var nationalLen = nationalId.Trim().Length;
        if (nationalLen >= 10) return nationalId.Trim();
        for (var i = 0; i < 10 - nationalLen; i++)
        {
            nationalId = "0" + nationalId;
        }

        return nationalId;
    }

    public static string CorrectNationalId(this int nationalId)
    {
        var nationalLen = nationalId.ToString().Trim().Length;
        var nationalIdString = nationalId.ToString().Trim();
        if (nationalLen >= 10) return nationalIdString;
        for (var i = 0; i < 10 - nationalLen; i++)
        {
            nationalIdString = "0" + nationalIdString;
        }

        return nationalIdString;
    }

    public static TimeSpan GetTimeSpan(this DateTime dateTime)
    {
        return TimeSpan.FromTicks(dateTime.Ticks);
    }
}