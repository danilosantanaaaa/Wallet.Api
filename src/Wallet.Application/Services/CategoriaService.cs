using FriendlyResult;
using FriendlyResult.Enums;

using Wallet.Application.Services.Interfaces;
using Wallet.Contracts.Categorias;
using Wallet.Domain.Categorias;
using Wallet.Domain.Common.Interfaces;
using Wallet.Domain.Common.Repositories;

namespace Wallet.Application.Services;

internal sealed class CategoriaService(
    ICategoriaRepository categoriaRepository,
    IUnitOfWork unitOfWork) : ICategoriaService
{
    private readonly ICategoriaRepository _categoriaRepository = categoriaRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result<Guid>> CreateAsync(CategoriaRequest request)
    {
        var categoria = new Categoria(
            request.Nome,
            request.Descricao,
            request.Tipo);

        await _categoriaRepository.AddAsync(categoria);
        await _unitOfWork.SaveChangesAsync();

        return categoria.Id;
    }

    public async Task<Result<Deleted>> DeleteAsync(Guid id)
    {
        var categoria = await _categoriaRepository.GetByIdAsync(id);
        if (categoria is null)
        {
            return Error.NotFound();
        }

        await _categoriaRepository.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();

        return ResultState.Deleted;
    }

    public async Task<Result<Updated>> UpdateAsync(Guid id, CategoriaRequest request)
    {
        var categoria = await _categoriaRepository.GetByIdAsync(id);
        if (categoria is null)
        {
            return Error.NotFound();
        }

        categoria.Update(
            request.Nome,
            request.Descricao,
            request.Tipo);

        await _categoriaRepository.UpdateAsync(categoria);
        await _unitOfWork.SaveChangesAsync();

        return ResultState.Updated;
    }

    public async Task<IEnumerable<CategoriaResponse>> GetAllAsync()
    {
        var categorias = await _categoriaRepository.GetAllAsync();

        return categorias
            .Select(c => new CategoriaResponse(
                c.Id,
                c.Nome,
                c.Descricao,
                c.Tipo))
            .ToList();
    }

    public async Task<Result<CategoriaResponse?>> GetByIdAsync(Guid id)
    {
        var categoria = await _categoriaRepository.GetByIdAsync(id);
        if (categoria is null)
        {
            return Error.NotFound();
        }

        return new CategoriaResponse(
            categoria.Id,
            categoria.Nome,
            categoria.Descricao,
            categoria.Tipo);
    }
}
