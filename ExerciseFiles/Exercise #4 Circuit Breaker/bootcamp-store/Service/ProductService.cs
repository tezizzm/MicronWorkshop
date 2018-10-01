using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Steeltoe.CircuitBreaker.Hystrix;
using Steeltoe.Common.Discovery;

namespace bootcamp_store.Service
{
    public sealed class ProductService : HystrixCommand<string[]>
    {
        private readonly DiscoveryHttpClientHandler _handler;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IHystrixCommandOptions options, IDiscoveryClient client, ILogger<ProductService> logger) : 
            base(options)
        {
            _logger = logger;
            _handler = new DiscoveryHttpClientHandler(client);
            IsFallbackUserDefined = true;
        }

        public async Task<string[]> RetrieveProducts()
        {
            _logger.LogDebug("Retrieving Products from Product Service");
            return await ExecuteAsync();
        }

        protected override async Task<string[]> RunAsync()
        {
            var client = new HttpClient(_handler, false);
            _logger.LogDebug("Processing rest api call to get products");
            var result = await client.GetAsync("https://core-cf-microservice-martez/api/products");
            var products = await result.Content.ReadAsAsync<string[]>();
            
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }

            return products;
        }

        protected override Task<string[]> RunFallbackAsync()
        {
            _logger.LogDebug("Processing products from fallback method");
            var products = new[]
            {
                "Fallback Product One, Bulls Championship",
                "Fallback Product Two, Notre Dame Football National Championship",
                "Fallback Product Three, White Sox World Series!"
            };

            foreach (var product in products)
            {
                Console.WriteLine(product);
            }

            return Task.FromResult(products);
        }
    }
}
