using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InMemoryCacheDemo.Models;
using Microsoft.Extensions.Caching.Memory;
using System.Text;

namespace InMemoryCacheDemo.Controllers
{
    public class HomeController : Controller
    {
        private IMemoryCache _memoryCache;

        public HomeController(IMemoryCache memoryCache)
        {
            this._memoryCache = memoryCache;
        }
        public IActionResult Index()
        {
            ViewData["Employee"] = getCacheMethodOne(); //getCacheMethodTwo();
            return View();
        }
        public CacheValueAndsource getCacheMethodOne()
        {
            string cacheValue;
            string sourceOfData ="Cache";
            CacheValueAndsource cvs = new CacheValueAndsource();
            cvs.EmployeeName = null;
            cvs.Source = null;
            // Look for cache key.
            if (!_memoryCache.TryGetValue<string>("_EmployeeName", out cacheValue))
            {
                // Key not in cache, so get data.
                EmployeeViewModel model = new EmployeeViewModel();
                cacheValue = model.emp.EmployeeName;
                sourceOfData = "Not Cache";

                //Cache expiration
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(1));

                // Save values in cache for a given key.
                _memoryCache.Set<string>("_EmployeeName", cacheValue, cacheEntryOptions);
            }
            cvs.EmployeeName = cacheValue.ToString();
            cvs.Source = sourceOfData.ToString();
            return cvs;
        }

        //_memoryCache.GetOrCreate<string>("_EmployeeName",
        //    cacheEntry => {
        //        return DateTime.Now.ToString();
        //    });


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
