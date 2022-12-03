using Microsoft.AspNetCore.Mvc;
using Routing.Plumbing;

namespace Routing.Controllers;

public class TradeController : Controller
{
    public IActionResult Make(string isin)
    {
        return Content($"Trading on valid ISIN {isin}");
    }
}