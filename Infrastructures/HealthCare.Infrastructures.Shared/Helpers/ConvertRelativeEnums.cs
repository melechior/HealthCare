using HealthCare.Infrastructures.Shared.Enums;

namespace HealthCare.Infrastructures.Shared.Helpers;

public static class ConvertRelativeEnums
{
    public static int ConvertRelativeEnum(this Relative relative,bool? isMan)
    {
        switch (relative)
        {
            case Relative.Main:
                return 31;
            case Relative.Partner:
                return 12;
            case Relative.Daughter:
                return 8;
            case Relative.Father:
                return 5;
            case Relative.Mother:
                return 6;
            case Relative.Son:
                return 7;
            case Relative.Offspring:
                if (isMan.HasValue)
                {
                    if (isMan == true)
                    {
                        return 7;
                    }

                    return 8;
                }

                throw new Exception("Cannot convert relative to Main or Partner");
            case Relative.Sister:
                return 10;
            case Relative.Brother:
                return 9;
            default:
                throw new Exception("Cannot convert relative to Main or Partner");
        }
    }
}