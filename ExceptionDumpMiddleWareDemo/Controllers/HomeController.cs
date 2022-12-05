using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ExceptionDumpMiddleWareDemo.Models;

namespace ExceptionDumpMiddleWareDemo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        // For fun !
        throw new AccessViolationException();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error(string? dump)
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, DumpFile = dump });
    }
}
