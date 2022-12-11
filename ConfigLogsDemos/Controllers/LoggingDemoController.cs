using Microsoft.AspNetCore.Mvc;

namespace ConfigLogsDemos.Controllers
{
    public class LoggingDemoController : Controller
    {
        private readonly ILogger<LoggingDemoController> logger;

        public LoggingDemoController(ILogger<LoggingDemoController> logger)
        {
            this.logger = logger;
        }
        public IActionResult Index()
        {
            logger.LogTrace("Trace message {SomeData}", "fdjkhfs");
            logger.LogDebug("Debug message {SomeData} {SomethingElse}", "fdjkhfs", 42);
            logger.LogInformation("Info message {SomeData}", "fdjkhfs" );
            logger.LogWarning("Warning message {SomeData}", "fdjkhfs" );
            logger.LogError("Error message {SomeData}", "fdjkhfs" );
            logger.LogCritical("Critical message {SomeData}", "fdjkhfs" );
            return Content("Done, check the logs");
        }
    }
}
