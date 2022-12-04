using Microsoft.AspNetCore.Mvc;

namespace Routing.Controllers;

[Route("promo/[action]")]
public class PromotionsController : Controller
{
    // eg.: /promo
    public ActionResult Index() { return Content("Index"); }

    // eg.: /promo/archive
    public ActionResult Archive() { return Content("Archive"); }

    // eg.: /promo/new
    public ActionResult New() { return Content("New"); }

    // eg.: /promo/Edit/edit/5 !
    [Route("edit/{promoId:int}")]
    public ActionResult Edit(int promoId) { return Content($"Editing {promoId}"); }

    // eg.: /specials !
    [Route("~/specials")]
    public ActionResult Specials() { return Content("Specials"); }
}