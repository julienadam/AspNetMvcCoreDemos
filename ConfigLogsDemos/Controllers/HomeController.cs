using System.Diagnostics;
using ConfigLogsDemos.Config;
using Microsoft.AspNetCore.Mvc;
using ConfigLogsDemos.Models;
using Microsoft.Extensions.Configuration;

namespace ConfigLogsDemos.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IConfiguration configuration;

    public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
    {
        _logger = logger;
        this.configuration = configuration;
    }

    public IActionResult Index()
    {
        ViewBag.Header = configuration["CustomCommon:Abc"];
        return View();
    }
    public IActionResult Index2()
    {
        ViewBag.Options = configuration.GetSection(nameof(CustomCommon)).Get<CustomCommon>(); ;
        return View();
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
}
