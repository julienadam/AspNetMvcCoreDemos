using System.Diagnostics;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Routing.Models;

namespace Routing.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Product()
    {
        return Content("Product from home");
    }


    public IActionResult Params()
    {
        return Content("Params from home");
    }
    
    public IActionResult Index(int? id)
    {
        return Content($"id = {id}");
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

    public IActionResult YearMonth(int year, int month)
    {
        return Content($"Year : {year}\nMonth : {month}");
    }
}
