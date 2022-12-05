using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StorageDemo.Models;

namespace StorageDemo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    public ActionResult TestTempData1()
    {
        TempData["clé"] = 42;
        return RedirectToAction("TestTempData2");
    }

    public ActionResult TestTempData2()
    {
        return Content(TempData["clé"]?.ToString() ?? "Pas de clé");
    }
    
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpPost]
    public IActionResult SetCookie(string cookie_val)
    {
        Response.Cookies.Append("CookieTest", cookie_val);
        return RedirectToAction(nameof(Index));
    }
}
