using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace bootcamp_webapi.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IConfigurationRoot _config;
        public ProductsController(IConfigurationRoot config)
        {
            _config = config;
        }

        // GET api/products
        [HttpGet]
        public IEnumerable<string> Get()
        {
            Console.WriteLine($"product1 is {_config["product1"]}");
            Console.WriteLine($"product2 is {_config["product2"]}");
            return new[] {$"{_config["product1"]}", $"{_config["product2"]}"};
        }
    }
}