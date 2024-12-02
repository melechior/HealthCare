using System.Text.RegularExpressions;

namespace HealthCare.Infrastructures.Shared;

public static class Regexes
{
    public static Regex EmailRegex()
    {
        return new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
    }
    public static Regex MobileRegex()
    {
        return new Regex("^09\\d{9}$");
    }
    public static bool IsValidIranianNationalCode(this string nationalId)
    {
        if (!Regex.IsMatch(nationalId, @"^\d{10}$"))
            return false;
        
        var check = Convert.ToInt32(nationalId.Substring(9, 1));
        var sum = Enumerable.Range(0, 9)
            .Select(x => Convert.ToInt32(nationalId.Substring(x, 1)) * (10 - x))
            .Sum() % 11;

        return (sum < 2 && check == sum) || (sum >= 2 && check + sum == 11);
    }
}