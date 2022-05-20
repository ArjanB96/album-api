using Microsoft.AspNetCore.Mvc;

namespace Album.Api.Controllers
{
    [ApiController]
    //optional queryparameter name
    [Route("[/api/hello/{name}]")]
    public class HelloController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
