using System.Diagnostics;
using Antelcat.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Antelcat.DependencyInjection.Autowired.ServerTest.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    [Autowired]
    protected ITest? Test;
    
    [Autowired]
    protected ILogger<TestController>? Logger;

    [HttpGet(Name = "TestAutowired")]
    public IActionResult TestAutowired()
    {
        try
        {
            if (Logger == null)
            {
                throw new NullReferenceException("Logger not been autowired");
            }

            if (Test == null)
            {
                throw new NullReferenceException("Service not been autowired");

            }

            Test.FullFilled();
        }
        catch (Exception e)
        {
            return new NotFoundObjectResult(e);
        }

        return new ObjectResult(new { Logger, Test });
    }
}