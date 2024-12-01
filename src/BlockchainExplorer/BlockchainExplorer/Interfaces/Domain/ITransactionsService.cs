using BlockchainExplorer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainExplorer.Interfaces.Domain
{
    public interface ITransactionsService
    {
        public Task<BlockReceiptsResponse> RetrieveBlockReceipts();

    }
}
