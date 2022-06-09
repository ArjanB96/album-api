using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using Album.Api;

// https://localhost:5011/api/hello?name=Arjan To test


namespace Album.Api.Controllers
{
    [ApiController]
    [Route("api/hello")]

    public class HelloController : Controller
    {
        private readonly ILogger _logger;

        public HelloController(ILogger<HelloController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get(string name)
        {
            _logger.LogInformation($"GET used with name {name} on {DateTime.UtcNow}");
            string greeting = new GreetingService().Greet(name);
            return greeting;
        }
    }
}