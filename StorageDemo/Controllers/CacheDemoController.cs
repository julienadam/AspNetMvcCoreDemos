using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace StorageDemo.Controllers
{
    public class CacheDemoController : Controller
    {
        private readonly IMemoryCache cache;

        public CacheDemoController(IMemoryCache cache)
        {
            this.cache = cache;
        }

        public IActionResult Index()
        {
            var time = cache.GetOrCreate("time", entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromSeconds(5);
                var val = DateTime.Now;
                entry.Value = val;
                Console.WriteLine($"Cache miss, new value is {val}");
                return val;
            });

            return Content(time.ToLongTimeString());
        }
    }
}
