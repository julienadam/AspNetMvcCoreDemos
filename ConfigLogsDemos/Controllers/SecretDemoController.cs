using Microsoft.AspNetCore.Mvc;

namespace ConfigLogsDemos.Controllers
{
    public class SecretDemoController : Controller
    {
        private readonly IConfiguration configuration;

        public SecretDemoController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IActionResult Index()
        {
            return Content(configuration["configuration:connectionString"]);
        }
    }
}
