using Microsoft.AspNetCore.Mvc;

using Wallet.Application.Services.Interfaces;
using Wallet.Contracts.Carteiras;

namespace Wallet.Api.Controllers;

[Route("api/v1/[controller]")]
public class CarteirasController(ICarteiraService carteiraService) : ApiController
{
    private readonly ICarteiraService _carteiraService = carteiraService;

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _carteiraService.GetByIdAsync(id);

        return result.MatchFirst(
            value => Ok(value),
            Problem);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _carteiraService.GetAllAsync();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CarteiraRequest request)
    {
        var result = await _carteiraService.CreateAsync(request);

        return result.MatchFirst(
            value => CreatedAtAction(nameof(GetByIdAsync), new { Id = value }, value),
            Problem);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, CarteiraRequest request)
    {
        var result = await _carteiraService.UpdateAsync(id, request);

        return result.MatchFirst(NoContent, Problem);
    }
}