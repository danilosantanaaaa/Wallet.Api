using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Wallet.Application.Services.Interfaces;
using Wallet.Contracts.Users;

namespace Wallet.Api.Controllers;

[AllowAnonymous]
[Route("api/v1/[controller]")]
public class UsersController(IUserService userService) : ApiController
{
    private readonly IUserService _userService = userService;

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(UserRequest requet)
    {
        var result = await _userService.CreateAsync(requet);

        return result.MatchFirst(
            value => Ok(value),
            Problem);
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(LoginRequest request)
    {
        var result = await _userService.LoginAsync(request);

        return result.MatchFirst(
            value => Ok(value),
            Problem);
    }

    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshTokenAsync(RefreshTokenRequest request)
    {
        var result = await _userService.RefreshTokenAsync(request);

        return result.MatchFirst(
            value => Ok(value),
            Problem);
    }
}