using BlockchainExplorer.Interfaces.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainExplorer.Controllers;

[Route("[controller]")]
public class TransactionsController : ControllerBase
{
    private readonly ITransactionsService _transactionsService;

    public TransactionsController(ITransactionsService transactionsService)
    {
        _transactionsService = transactionsService;
    }   

    [HttpGet]
    public async Task<IActionResult> GetBlockReceipts()
    {
        var response = await _transactionsService.RetrieveBlockReceipts();

        return Ok(response);
    }
}

