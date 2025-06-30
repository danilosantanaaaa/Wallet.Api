using Microsoft.AspNetCore.Mvc;

using Wallet.Application.Services.Interfaces;
using Wallet.Contracts.Cobrancas;

namespace Wallet.Api.Controllers;

[Route("api/v1/[controller]")]
public class CobrancasController(ICobrancaService cobrancaService) : ApiController
{
    private readonly ICobrancaService _cobrancaService = cobrancaService;

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _cobrancaService.GetByIdAsync(id);

        return result.MatchFirst(
            value => Ok(value),
            Problem);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _cobrancaService.GetAllAsync();

        return Ok(result);
    }

    [HttpGet("report")]
    public async Task<IActionResult> GetReportAsync()
    {
        var result = await _cobrancaService.GetReportAsync();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CobrancaRequest request)
    {
        var result = await _cobrancaService.CreateAsync(request);

        return result.MatchFirst(
            value => CreatedAtAction(nameof(GetByIdAsync), new { Id = value }, value),
            Problem);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, CobrancaRequest request)
    {
        var result = await _cobrancaService.UpdateAsync(id, request);

        return result.MatchFirst(NoContent, Problem);
    }
}