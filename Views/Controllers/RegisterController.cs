using Microsoft.AspNetCore.Mvc;
using Views.Models;

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

        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyEmailIsUnique(string email)
        {
            if (email == "foo@bar.org")
            {
                return Json($"Email {email} is already in use.");
            }

            return Json(true);
        }

        public IActionResult Index2()
        {
            return View(new VerifiedRegisterViewModel { Email = "foo@bar.org"});
        }

        [HttpPost]
        public IActionResult Index2(VerifiedRegisterViewModel vm)
        {
            if (ModelState.IsValid)
            {
                return Content($"Thank you for registering {vm.Email}");
            }
            else
            {
                return View(vm);
            }
        }

        public IActionResult ResetRequest()
        {
            return View(new ResetPasswordRequestViewModel { Email = "foo@bar.org"});
        }

        [HttpPost]
        public IActionResult ResetRequest(ResetPasswordRequestViewModel vm)
        {
            if (ModelState.IsValid)
            {
                return Content($"Reset email sent.");
            }
            else
            {
                return View(vm);
            }
        }

    }
}
