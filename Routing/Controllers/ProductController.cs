using Microsoft.AspNetCore.Mvc;

namespace Routing.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return Content($"{nameof(ProductController)}/{nameof(Index)}");
        }

        public IActionResult Search()
        {
            return Content($"{nameof(ProductController)}/{nameof(Search)}");
        }
    }
}
