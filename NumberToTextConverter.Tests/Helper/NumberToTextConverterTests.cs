using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberToTextConverter.Server.Helper;
using System.Globalization;

namespace NumberToTextConverter.Tests.Helper;

[TestClass]
public class NumberToTextConverterTests
{
    [DataRow("123", "ONE HUNDRED AND TWENTY-THREE DOLLARS")]
    [DataRow("123.45", "ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS")]
    [DataRow(".45", "ZERO DOLLARS AND FORTY-FIVE CENTS")]
    [TestMethod]
    public void TestGetValueInCurrency(string userInput, string expectedResult)
    {
        //Arrange 
        var value = TestHelper.GetDecimal(userInput);
        //Act
        var result = NumberToTextConverter.ConvertToText((decimal)value);
        //Assert
        Assert.AreEqual(expectedResult, result);
    }
}