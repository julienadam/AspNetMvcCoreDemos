using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace Routing.Controllers
{
    public class BooksController : Controller
    {
        // eg: /books
        // eg: /books/1430210079
        [Route("books/{isbn?}")]
        public ActionResult Show(string isbn)
        {
            return !string.IsNullOrEmpty(isbn) ? Content("One book : " + isbn) : Content("All books");
        }

        // eg: /books/lang
        // eg: /books/lang/en
        // eg: /books/lang/he
        // eg: /books/lang/fr-CA
        [Route("books/lang/{lang=en}")]
        public ActionResult ShowByLanguage(string lang)
        {

            return Content($"All books in : {new CultureInfo(lang).EnglishName} ({new CultureInfo(lang).NativeName})");
        }
    }
}
