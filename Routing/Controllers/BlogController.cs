using Microsoft.AspNetCore.Mvc;

namespace Routing.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Foo()
        {
            return Content($"The blog controller, not the Posts controller !");
        }
    }
}
