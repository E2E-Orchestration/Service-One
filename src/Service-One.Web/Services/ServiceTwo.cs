using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Service_One.Web.Services
{
    public class ServiceTwo
    {
        private string ServiceTwoUrl { get; set; }
        private HttpClient httpClient { get; set; }

        const string ServiceOneGreeting = "Hello, ";

        public ServiceTwo(IConfiguration config)
        {
            ServiceTwoUrl = config.GetValue<string>(nameof(ServiceTwoUrl));
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(ServiceTwoUrl)
            };
        }

        public async Task<string> GetGreeting()
        {
            var serviceTwoGreeting = await httpClient.GetAsync("world");

            var svcTwoGreetingText = await serviceTwoGreeting.Content.ReadAsStringAsync();

            return $"{ServiceOneGreeting}{svcTwoGreetingText}";
        }
    }
}
