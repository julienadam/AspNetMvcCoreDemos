using Microsoft.AspNetCore.Mvc;

namespace Views.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string email, string password)
        {
            return Content($"Thank you for registering {email}");
        }
    }
}
