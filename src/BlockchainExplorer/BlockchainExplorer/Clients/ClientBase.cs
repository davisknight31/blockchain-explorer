using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainExplorer.Clients
{
    public abstract class ClientBase
    {

        private readonly IHttpClientFactory _httpClientFactory;

        protected ClientBase(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<string> CreateHttpRequest(HttpMethod method, string clientBaseAddress, string relativeUrl, HttpContent content)
        {
            using var client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.BaseAddress = new Uri(clientBaseAddress);

            var request = new HttpRequestMessage(method, relativeUrl) { Content = content };

            var response = await client.SendAsync(request);


            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return await response.Content.ReadAsStringAsync();
        }
    }
}
