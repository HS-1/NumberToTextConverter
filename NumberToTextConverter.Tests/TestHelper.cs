namespace NumberToTextConverter.Tests;

public static class TestHelper
{
    public static decimal? GetDecimal(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return null;
        }

        // Validate the input against a regular expression for decimal numbers
        if (decimal.TryParse(value, out decimal result))
        {
            return result;
        }
        else
        {
            return null;
        }
    }
}
