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
            //Will want to get latest on main list, but could allow user to choose a block to view receipts of
            string block = "0x14511fc";
            //string block = "latest";
            return await _alchemyClient.PostEthGetBlockReceipts(block);

        }

    }
}
