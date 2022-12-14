using ConfigLogsDemos.Config;
using ConfigLogsDemos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ConfigLogsDemos.Controllers
{
    public class OptionDemoController : Controller
    {
        private readonly IOptions<CustomCommon> options;

        public OptionDemoController(IOptions<CustomCommon> options)
        {
            this.options = options;
        }

        public IActionResult Index()
        {
            ViewBag.Options = options.Value;
            return View();
        }
    }
}
