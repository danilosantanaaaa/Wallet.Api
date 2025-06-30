using Microsoft.AspNetCore.Mvc;

using Wallet.Application.Services.Interfaces;
using Wallet.Contracts.Contatos;

namespace Wallet.Api.Controllers;

[Route("api/v1/[controller]")]
public class ContatosController(IContatoService contatoService) : ApiController
{
    private readonly IContatoService _contatoService = contatoService;

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _contatoService.GetByIdAsync(id);

        return result.MatchFirst(
            value => Ok(value),
            Problem);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _contatoService.GetAllAsync();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(ContatoRequest request)
    {
        var result = await _contatoService.CreateAsync(request);

        return result.MatchFirst(
            value => CreatedAtAction(nameof(GetByIdAsync), new { Id = value }, value),
            Problem);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, ContatoRequest request)
    {
        var result = await _contatoService.UpdateAsync(id, request);

        return result.MatchFirst(NoContent, Problem);
    }
}