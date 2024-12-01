using BlockchainExplorer.Interfaces.External;
using BlockchainExplorer.Models;
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

    public async Task<BlockReceiptsResponse> CreatePostRequest()
    {
        using var client = _httpClientFactory.CreateClient();

        var requestBody = new
        {
            id = 1,
            jsonrpc = "2.0",
            method = "eth_getBlockReceipts",
            @params = new[] { "0x14511fc" }
        };

        client.DefaultRequestHeaders.Add("Accept", "application/json");
        client.BaseAddress = new Uri(AlchemyEthBaseAddress);

        var response = await client.PostAsJsonAsync("", requestBody);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        return await response.Content.ReadFromJsonAsync<BlockReceiptsResponse>();


    }

}