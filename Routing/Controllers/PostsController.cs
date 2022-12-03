using Microsoft.AspNetCore.Mvc;

namespace Routing.Controllers;

public class PostsController : Controller
{
    public IActionResult ViewPost(string slug)
    {
        return Content("Content for post titled " + slug);
    }
}