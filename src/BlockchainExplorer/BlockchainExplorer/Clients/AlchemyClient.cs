using BlockchainExplorer.Interfaces.External;
using BlockchainExplorer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlockchainExplorer.Clients;
public class AlchemyClient : IAlchemyClient
{
    private readonly string AlchemyEthBaseAddress = "https://eth-mainnet.g.alchemy.com/v2/qctIaVrmpmFFsct4SJ3ijJBzI-USRtJA";
    private readonly IHttpClientFactory _httpClientFactory;


    public AlchemyClient(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<string> CreateHttpRequest(HttpMethod method, string relativeUrl, HttpContent content)
    {
        using var client = _httpClientFactory.CreateClient();

        client.DefaultRequestHeaders.Add("Accept", "application/json");
        client.BaseAddress = new Uri(AlchemyEthBaseAddress);

        var request = new HttpRequestMessage(method, relativeUrl) { Content = content };

        var response = await client.SendAsync(request);


        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        return await response.Content.ReadAsStringAsync();
    }

    public async Task<BlockReceiptsResponse> PostEthGetBlockReceipts(string block)
    {
        var requestBody = new
        {
            id = 1,
            jsonrpc = "2.0",
            method = "eth_getBlockReceipts",
            @params = new[] { block }
        };

        var content = JsonContent.Create(requestBody);

        var responseString = await CreateHttpRequest(new HttpMethod("POST"), "", content);
        return JsonConvert.DeserializeObject<BlockReceiptsResponse>(responseString);

    }

}