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
public class AlchemyClient : ClientBase, IAlchemyClient
{
    private readonly string AlchemyEthBaseAddress = "https://eth-mainnet.g.alchemy.com/v2/qctIaVrmpmFFsct4SJ3ijJBzI-USRtJA";


    public AlchemyClient(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
    {
        
    }

    public Task<SingleResultValueAlchemyResponse<string>> GetBlockNumber()
    {
        throw new NotImplementedException();
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

        var responseString = await CreateHttpRequest(new HttpMethod("POST"),AlchemyEthBaseAddress, "", content);
        return JsonConvert.DeserializeObject<BlockReceiptsResponse>(responseString);

    }

}