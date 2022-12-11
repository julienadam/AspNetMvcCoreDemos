using ConfigLogsDemos.Config;
using ConfigLogsDemos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ConfigLogsDemos.Controllers
{
    public class OptionSnapshotDemoController : Controller
    {
        private readonly IOptionsSnapshot<CustomCommon> options;

        public OptionSnapshotDemoController(IOptionsSnapshot<CustomCommon> options)
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
