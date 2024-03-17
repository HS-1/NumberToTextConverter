using NumberToTextConverter.Server.Helper;
using NumberToTextConverter.Server.Model;
using System.Globalization;

namespace NumberToTextConverter.Server.Business;

public class ProcessTextToNumber
{
    public ResponseModel NumberToText(CultureInfo info, string userInput)
    {
        try
        {
            //1. check user culture + valid currency amount
            decimal? currencyAmount = NumberProcessor.GetValueInCurrency(info, userInput);

            if (currencyAmount == default)
                return new ResponseModel()
                {
                    StatusCode = 500,
                    Summary = "Value is not a valid currency amount."
                };

            //2. round to nearest 2 decimal
            var roundedValue = Math.Round((decimal)currencyAmount, 2);

            //3. convert to text with helper function
            var result = Converter.ConvertToText(roundedValue);

            return new ResponseModel()
            {
                StatusCode = 200,
                Summary = result
            };

        }catch(Exception ex)
        {
            return new ResponseModel()
            {
                StatusCode = 500,
                Summary = ex.Message
            };
        }
    }
}
