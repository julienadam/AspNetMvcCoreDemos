using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Views.Models;

namespace Views.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public ActionResult Index()
    {
        return View();
    }

    public ActionResult Index2()
    {
        return View();
    }

    public ActionResult Privacy()
    {
        return View();
    }

    public ActionResult ServerInfo()
    {
        var serverInfo = new ServerInfoViewModel
        {
            Cores = Environment.ProcessorCount,
            MachineName = Environment.MachineName,
            OperatingSystem = Environment.OSVersion.ToString(),
            CLRVersion = Environment.Version.ToString(),
        };

        return PartialView("ServerInfo/ServerInfo", serverInfo);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
