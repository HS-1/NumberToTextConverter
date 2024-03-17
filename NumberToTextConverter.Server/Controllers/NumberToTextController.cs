using Microsoft.AspNetCore.Mvc;
using NumberToTextConverter.Server.Business;
using NumberToTextConverter.Server.Model;
using System.Globalization;

namespace NumberToTextConverter.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class NumberToTextController : ControllerBase
{    
    ProcessTextToNumber processTextToNumber = new ProcessTextToNumber(); //in real world, we want to have as DI with logger

    public NumberToTextController()
    {
    }

    [HttpGet]
    [Route("GetText/{userInput}")]
    public ResponseModel GetText(string userInput)
    {
        string[] userLanguages = Request.Headers["Accept-Language"].ToString().Split(',');
        return processTextToNumber.NumberToText(new CultureInfo(userLanguages[0]), userInput);
    }
}