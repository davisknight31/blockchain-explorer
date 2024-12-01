using BlockchainExplorer.Clients;
using BlockchainExplorer.Interfaces.Domain;
using BlockchainExplorer.Interfaces.External;
using BlockchainExplorer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainExplorer.Services.Domain
{
    public class TransactionsService : ITransactionsService
    {

        private readonly IAlchemyClient _alchemyClient;

        public TransactionsService(IAlchemyClient alchemyClient)
        {
            _alchemyClient = alchemyClient;
        }

        public async Task<BlockReceiptsResponse> RetrieveBlockReceipts()
        {
            return await _alchemyClient.CreatePostRequest();

        }

    }
}
