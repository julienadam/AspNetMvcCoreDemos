using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace CustomImageResult.Plumbing
{
    public static class ImageResultHelper
    {
        public static IHtmlContent Image(this HtmlHelper helper, string controller, string action, int width, int height)
        {
            return helper.Image(controller, action, width, height, "");
        }

        public static IHtmlContent Image(this HtmlHelper helper, string controller, string action, int width, int height, string alt)
        {
            var urlHelper = new UrlHelper(helper.ViewContext);
            var url = urlHelper.Action(new UrlActionContext { Action = action, Controller = controller });
            return helper.Raw($"<img src=\"{url}\" width=\"{width}\" height=\"{height}\" alt=\"{alt}\" />");
        }
    }
}
