using Microsoft.AspNetCore.Mvc;

using Wallet.Application.Services.Interfaces;
using Wallet.Contracts.Categorias;

namespace Wallet.Api.Controllers;

[Route("api/v1/[controller]")]
public class CategoriasController(ICategoriaService categoriaService) : ApiController
{
    private readonly ICategoriaService _categoriaService = categoriaService;

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _categoriaService.GetByIdAsync(id);

        return result.MatchFirst(
            value => Ok(value),
            Problem);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _categoriaService.GetAllAsync();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CategoriaRequest request)
    {
        var result = await _categoriaService.CreateAsync(request);

        return result.MatchFirst(
            value => CreatedAtAction(nameof(GetByIdAsync), new { Id = value }, value),
            Problem);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, CategoriaRequest request)
    {
        var result = await _categoriaService.UpdateAsync(id, request);

        return result.MatchFirst(NoContent, Problem);
    }
}