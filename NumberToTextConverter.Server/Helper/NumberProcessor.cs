using System.Globalization;

namespace NumberToTextConverter.Server.Helper;

public static class NumberProcessor
{
    /// <summary>
    /// Get the value in input as decimal, return null if this is not convertable.
    /// </summary>
    /// <param name="culture"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    public static decimal? GetValueInCurrency(CultureInfo culture, string input)
    {
        var isValidCurrency = decimal.TryParse(input, 
            NumberStyles.Number | NumberStyles.AllowCurrencySymbol,
            culture, 
            out decimal convertedValue);

        return isValidCurrency ? convertedValue : null;            
    }
}
