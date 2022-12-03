using Microsoft.AspNetCore.Mvc;

namespace Routing.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return Content($"{nameof(ProductController)}/{nameof(Index)}");
        }

        //public IActionResult Index(int? id)
        //{
        //    return Content($"{nameof(ProductController)}/{nameof(Index)}/{id}");
        //}


        public IActionResult Search(string id)
        {
            return Content($"{nameof(ProductController)}/{nameof(Search)}/{id}");
        }
    }
}
