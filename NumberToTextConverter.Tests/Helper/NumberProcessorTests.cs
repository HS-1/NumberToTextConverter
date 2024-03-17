using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberToTextConverter.Server.Helper;
using System.Globalization;

namespace NumberToTextConverter.Tests.Helper;

[TestClass]
public class NumberProcessorTests
{
    [DataRow("123", "123")]
    [DataRow("123.45", "123.45")]
    [DataRow(".45", "0.45")]
    [DataRow("", "")] 
    [DataRow("abc", "")] 
    [TestMethod]
    public void TestGetValueInCurrency(string userInput, string expectedResult)
    {
        //Arrange 
        var expected = TestHelper.GetDecimal(expectedResult);
        //Act
        var result = NumberProcessor.GetValueInCurrency(CultureInfo.CurrentCulture, userInput);
        //Assert
        Assert.AreEqual(expected, result);
    }    
}