using ConfigLogsDemos.Config;
using ConfigLogsDemos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ConfigLogsDemos.Controllers
{
    public class OptionDemoController : Controller
    {
        private IOptions<CustomCommon> options;

        public IActionResult Index(IOptions<CustomCommon> options)
        {
            this.options = options ?? throw new ArgumentNullException(nameof(options));
            ViewBag.Options = options.Value;
            return View();
        }
    }
}
