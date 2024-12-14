using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainExplorer.Models;

public class BlockReceiptsResponse : BaseAlchemyResponse
{
    public List<BlockReceiptResultItem> Result { get; set; } = [];
}

public class BlockReceiptResultItem
{
    public string TransactionHash { get; set; } = string.Empty;
    public string BlockHash { get; set; } = string.Empty;
    public string BlockNumber { get; set; } = string.Empty;
    public string LogsBloom { get; set; } = string.Empty;
    public string GasUsed { get; set; } = string.Empty;
    public string ContractAddress { get; set; } = string.Empty;
    public string CumulativeGasUsed { get; set; } = string.Empty;
    public string TransactionIndex { get; set; } = string.Empty;
    public string From { get; set; } = string.Empty;
    public string To { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string EffectiveGasPrice { get; set; } = string.Empty;
    public List<BlockReceiptResultLogItem> Logs { get; set; } = [];
}

public class BlockReceiptResultLogItem
{
    public string BlockHash { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string LogIndex { get; set; } = string.Empty;
    public string Data { get; set; } = string.Empty;
    public bool Removed { get; set; }
    public List<string> Topics { get; set; } = [];
    public string BlockNumber { get; set; } = string.Empty;
    public string TransactionIndex { get; set; } = string.Empty;
    public string TransactionHash { get; set; } = string.Empty;
}


