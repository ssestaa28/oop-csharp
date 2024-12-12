using Itmo.ObjectOrientedProgramming.Lab5.Application.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab5.Presentation.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Controllers;

[ApiController]
[Route("api/admin")]
public class AdminController : ControllerBase
{
    private readonly IAdminAppService _adminAppService;

    public AdminController(IAdminAppService adminAppService)
    {
        _adminAppService = adminAppService;
    }

    [HttpPost("authenticate")]
    public IActionResult Authenticate([FromBody] AdminLoginRequest loginRequest)
    {
        if (_adminAppService.AuthenticateAdmin(loginRequest.Password))
        {
            return Ok("Admin authenticated");
        }

        return Unauthorized("Invalid admin password");
    }

    [HttpPost("reset-account")]
    public IActionResult ResetAccount([FromBody] int accountId)
    {
        bool success = _adminAppService.ResetAccount(accountId);

        if (success)
        {
            return Ok("Account reset successfully");
        }

        return NotFound("Account not found");
    }
}
