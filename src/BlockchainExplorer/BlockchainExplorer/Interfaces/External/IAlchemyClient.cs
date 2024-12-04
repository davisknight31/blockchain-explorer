using BlockchainExplorer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainExplorer.Interfaces.External
{
    public interface IAlchemyClient
    {
        public Task<string> CreateHttpRequest(HttpMethod method, string relativeUrl, HttpContent requestObject);
        public Task<BlockReceiptsResponse> PostEthGetBlockReceipts(string block);

    }
}
