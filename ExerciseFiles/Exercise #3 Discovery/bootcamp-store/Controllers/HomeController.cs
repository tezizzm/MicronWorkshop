using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bootcamp_store.Models;
using Steeltoe.Common.Discovery;

namespace bootcamp_store.Controllers
{
    public class HomeController : Controller
    {
        //private static HttpClient client = new HttpClient();
        DiscoveryHttpClientHandler handler;

        public HomeController(IDiscoveryClient client)
        {
            handler = new DiscoveryHttpClientHandler(client);
        }

        public async Task<IActionResult> Index()
        {
            var client = new HttpClient(handler, false);
            var result = await client.GetAsync("https://core-cf-microservice-martez/api/products");
            var products = await result.Content.ReadAsAsync<string[]>();
            ViewData["products"] = products;
            foreach (var product in products)
            {
                System.Console.WriteLine(product);
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
