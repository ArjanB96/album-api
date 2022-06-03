using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

// https://localhost:5011/api/hello?name=Arjan To test


namespace Album.Api.Controllers
{
    public class HelloController : Controller
    {
        [HttpGet("/api/hello")]
        public IActionResult Index(string name)
        {
            var greetingService = new GreetingService();
            var result = greetingService.Greet(name);
            return Ok(result);
        }
    }
}


  