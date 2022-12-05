using Microsoft.AspNetCore.Mvc;

namespace StorageDemo.Controllers
{
    public class SessionDemoController : Controller
    {
        public IActionResult Index()
        {
            var sessionAsDictionary =
                HttpContext.Session.Keys
                    .ToDictionary(k => k, k => HttpContext.Session.GetString(k));
            return View(sessionAsDictionary);
        }

        [HttpPost]
        public IActionResult SetSession(string key, string value)
        {
            HttpContext.Session.SetString(key, value);
            return RedirectToAction(nameof(Index));
        }
    }
}
