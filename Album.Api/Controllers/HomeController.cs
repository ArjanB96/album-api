using Microsoft.AspNetCore.Mvc;

namespace Album.Api.Controllers
{
    [ApiController]
    //get
    [Route("api/hello/[controller]")]
    ///api/hello/{name}]")]
    
    public class HelloController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("{name}")]
        public string GreetingService(string name)
        {   
            if (name == null || name == "" || name == " ")
                return "Hello, World!";
            else
                return $"Hello, {name}!";
        }
    }
}

