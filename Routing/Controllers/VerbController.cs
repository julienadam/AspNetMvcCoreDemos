using Microsoft.AspNetCore.Mvc;

namespace Routing.Controllers
{
    public class VerbController : Controller
    {
        [HttpGet]
        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string query)
        {
            return Content($"Résultats de recherche pour :{query}");
        }
    }
}
