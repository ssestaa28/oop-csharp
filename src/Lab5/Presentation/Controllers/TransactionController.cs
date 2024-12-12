using Itmo.ObjectOrientedProgramming.Lab5.Domain.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Models;
using Itmo.ObjectOrientedProgramming.Lab5.Presentation.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionController : ControllerBase
{
    private readonly ITransactionRepository _transactionRepository;

    public TransactionController(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    [HttpGet("account/{accountId}")]
    public IActionResult GetTransactionsByAccountId(int accountId)
    {
        ICollection<ITransaction>? transactions = _transactionRepository.GetTransactionsByAccountId(accountId);

        if (transactions == null || transactions.Count == 0)
        {
            return NotFound("No transactions found for the given account ID");
        }

        var transactionDtos = transactions.Select(t => new TransactionDto
        {
            Id = t.Id,
            TransactionDate = t.TransactionDate,
            Amount = t.Amount,
            Type = t.Type,
            AccountId = t.AccountId,
        }).ToList();

        return Ok(transactionDtos);
    }

    [HttpPost]
    public IActionResult AddTransaction([FromBody] TransactionDto transactionDto)
    {
        if (transactionDto == null)
        {
            return BadRequest("Transaction data is required");
        }

        var transaction = new Transaction
        {
            Id = transactionDto.Id,
            TransactionDate = transactionDto.TransactionDate ?? DateTime.MinValue,
            Amount = transactionDto.Amount,
            Type = transactionDto.Type,
            AccountId = transactionDto.AccountId,
        };

        _transactionRepository.AddTransaction(transaction);

        return Ok("Transaction added successfully");
    }

    [HttpDelete("account/{accountId}")]
    public IActionResult DeleteTransactionsByAccountId(int accountId)
    {
        _transactionRepository.DeleteTransactionsByAccountId(accountId);
        return Ok("Transactions deleted successfully");
    }
}
