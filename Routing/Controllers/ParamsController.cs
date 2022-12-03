using Microsoft.AspNetCore.Mvc;

namespace Routing.Controllers
{
    public enum Couleur
    {
        Rouge,
        Vert,
        Bleu
    }

    public class ParamsController : Controller
    {
        // Params/Index?blah=42&c=rouge&truc=true
        // Params/Index?blah=42&c=jaune&truc=true
        // Params/Index?blah=42&c=-42&truc=true
        // Params/Index?blah=42&c=rouge&truc=1
        // Params/Index?blah=truc&c=rouge&truc=true

        public IActionResult Index(int blah, Couleur c, bool truc = false)
        {
            return Content($"{blah}, {c}, {truc}");
        }

        public IActionResult DemoDefaultId(int id) 
        {
            return Content($"{id}");
        }

        // Params/Category?name=things
        // Params/Category
        public IActionResult Category(string name)
        {
            return Content($"{name ?? "<null>"}");
        }

        // Params/Search?name=something
        // Params/Search
        public IActionResult Search(string name = "default")
        {
            return Content($"{name ?? "<null>"}");
        }

    }
}
