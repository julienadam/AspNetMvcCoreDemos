using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace StorageDemo.Controllers
{
    public class DistributedCacheDemoController : Controller
    {
        private readonly IDistributedCache cache;

        public DistributedCacheDemoController(IDistributedCache cache)
        {
            this.cache = cache;
        }

        public async Task<IActionResult> Index()
        {
            var objectFromCache = await cache.GetAsync("time");


            if (objectFromCache != null)
            {
                // Deserialize it
                var jsonToDeserialize = System.Text.Encoding.UTF8.GetString(objectFromCache);
                var cachedResult = JsonSerializer.Deserialize<DateTime>(jsonToDeserialize);
                return Content($"From cache {cachedResult.ToLongTimeString()}");
            }
            else
            {

                // If not found, then recalculate response
                var result = DateTime.Now;

                // Serialize the response
                var objectToCache = JsonSerializer.SerializeToUtf8Bytes(result);
                var cacheEntryOptions = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(5));

                // Cache it
                await cache.SetAsync("time", objectToCache, cacheEntryOptions);
                return Content($"New time {result.ToLongTimeString()}");
            }
        }
    }
}
