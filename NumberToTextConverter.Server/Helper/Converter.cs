namespace NumberToTextConverter.Server.Helper;

public static class Converter
{
    private static readonly string[] OnesPlace = { "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE" };
    private static readonly string[] Teens = { "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN" };
    private static readonly string[] TensPlace = { "", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };

    /// <summary>
    /// Return the decimal to text with dollar and cents.
    /// Round to nearest 2 decimal if there are more than 2 decimal places.
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    public static string ConvertToText(decimal number)
    {
        int dollars = (int)Math.Truncate(number);
        int cents = (int)((number - dollars) * 100);

        string text = ConvertNumberToText(dollars) + " DOLLARS";
        if (cents > 0)
            text += " AND " + ConvertNumberToText(cents) + " CENTS";
        return text;
    }

    private static string ConvertNumberToText(int number)
    {
        if (number < 0)
            return "Minus " + ConvertNumberToText(-number);
        if (number < 100)
            return ConvertToTextBelow100(number);
        if (number < 1000)
            return ConvertNumberToText(number / 100) + " HUNDRED AND " + ConvertToTextBelow100(number % 100);
        if (number < 1000000)
            return ConvertNumberToText(number / 1000) + " THOUSAND AND " + ConvertToTextBelow1000(number % 1000);
        if (number < 1000000000)
            return ConvertNumberToText(number / 1000000) + " MILLION AND " + ConvertToTextBelow1000(number % 1000000);
        return ConvertNumberToText(number / 1000000000) + " BILLION AND " + ConvertToTextBelow1000(number % 1000000000);
    }

    private static string ConvertToTextBelow100(int number)
    {
        if (number < 10)
            return OnesPlace[number];
        if (number < 20)
            return Teens[number - 10];
        return TensPlace[number / 10] + "-" + OnesPlace[number % 10];
    }

    private static string ConvertToTextBelow1000(int number)
    {
        if (number == 0)
            return "";
        return ConvertToTextBelow100(number) + " ";
    }
}   
