using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CustomImageResult.Models;
using CustomImageResult.Plumbing;
using System.Drawing.Imaging;
using System.Drawing;

namespace CustomImageResult.Controllers;

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

    public ActionResult DisplayTime()
    {
        Bitmap bmp = new Bitmap(200, 50);
        Graphics g = Graphics.FromImage(bmp);

        g.FillRectangle(Brushes.White, 0, 0, 200, 50);
        g.DrawString(DateTime.Now.ToShortTimeString(), new Font("Arial", 32), Brushes.Red, new PointF(0, 0));

        return new ImageResult { Image = bmp, ImageFormat = ImageFormat.Jpeg };
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
