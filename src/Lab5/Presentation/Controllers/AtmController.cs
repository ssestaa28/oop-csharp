using Itmo.ObjectOrientedProgramming.Lab5.Application.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab5.Presentation.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Controllers;

[ApiController]
[Route("api/atm")]
public class AtmController : ControllerBase
{
    private readonly IAtmAppService _atmAppService;

    public AtmController(IAtmAppService atmAppService)
    {
        _atmAppService = atmAppService;
    }

    [HttpPost("authenticate")]
    public IActionResult Authenticate([FromBody] LoginRequest loginRequest)
    {
        (bool isAuthenticated, IAccount? account) = _atmAppService.AuthenticateUser(loginRequest.AccountNumber, loginRequest.Pin);

        if (isAuthenticated && account != null)
        {
            return Ok(account);
        }

        return Unauthorized("Invalid credentials");
    }

    [HttpGet("balance")]
    public IActionResult GetBalance([FromQuery] int accountId)
    {
        IAccount? account = _atmAppService.GetAccountById(accountId);
        if (account == null)
        {
            return NotFound("Account not found");
        }

        return Ok(_atmAppService.GetBalance(account));
    }

    [HttpPost("deposit")]
    public IActionResult Deposit([FromQuery] int accountId, [FromBody] decimal amount)
    {
        IAccount? account = _atmAppService.GetAccountById(accountId);
        if (account == null)
        {
            return NotFound("Account not found");
        }

        _atmAppService.Deposit(account, amount);
        return Ok("Deposit successful");
    }

    [HttpPost("withdraw")]
    public IActionResult Withdraw([FromQuery] int accountId, [FromBody] decimal amount)
    {
        IAccount? account = _atmAppService.GetAccountById(accountId);
        if (account == null)
        {
            return NotFound("Account not found");
        }

        if (_atmAppService.Withdraw(account, amount))
        {
            return Ok("Withdraw successful");
        }

        return BadRequest("Insufficient funds or invalid operation");
    }

    [HttpGet("transactions")]
    public IActionResult GetTransactionHistory([FromQuery] int accountId)
    {
        IAccount? account = _atmAppService.GetAccountById(accountId);
        if (account == null)
        {
            return NotFound("Account not found");
        }

        return Ok(_atmAppService.GetTransactionHistory(account));
    }
}