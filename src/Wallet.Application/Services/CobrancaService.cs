using FriendlyResult;
using FriendlyResult.Enums;

using Wallet.Application.Services.Interfaces;
using Wallet.Contracts.Cobrancas;
using Wallet.Domain.Cobrancas;
using Wallet.Domain.Common.Interfaces;
using Wallet.Domain.Common.Repositories;

namespace Wallet.Application.Services;

internal sealed class CobrancaService(
    ICobrancaRepository cobrancaRepository,
    IUnitOfWork unitOfWork) : ICobrancaService
{
    private readonly ICobrancaRepository _cobrancaRepository = cobrancaRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result<Guid>> CreateAsync(CobrancaRequest request)
    {
        var cobranca = new Cobranca(
            request.Descricao,
            request.Valor,
            request.Status,
            request.CarteiraId,
            request.CategoriaId,
            request.ContatoId);

        await _cobrancaRepository.AddAsync(cobranca);
        await _unitOfWork.SaveChangesAsync();

        return cobranca.Id;
    }

    public async Task<Result<Deleted>> DeleteAsync(Guid id)
    {
        var cobranca = await _cobrancaRepository.GetByIdAsync(id);
        if (cobranca is null)
        {
            return Error.NotFound();
        }

        await _cobrancaRepository.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();

        return ResultState.Deleted;
    }

    public async Task<Result<Updated>> UpdateAsync(Guid id, CobrancaRequest request)
    {
        var cobranca = await _cobrancaRepository.GetByIdAsync(id);
        if (cobranca is null)
        {
            return Error.NotFound();
        }

        cobranca.Update(
            request.Descricao,
            request.Valor,
            request.Status,
            request.CarteiraId,
            request.CategoriaId,
            request.ContatoId);

        await _cobrancaRepository.UpdateAsync(cobranca);
        await _unitOfWork.SaveChangesAsync();

        return ResultState.Updated;
    }

    public async Task<IEnumerable<CobrancaResponse>> GetAllAsync()
    {
        var cobrancas = await _cobrancaRepository.GetAllAsync();

        return cobrancas.Select(c => new CobrancaResponse(
                c.Id,
                c.Descricao,
                c.Valor,
                c.Status,
                c.CarteiraId,
                c.CategoriaId,
                c.ContatoId)
            ).ToList();
    }

    public async Task<Result<CobrancaResponse?>> GetByIdAsync(Guid id)
    {
        var cobranca = await _cobrancaRepository.GetByIdAsync(id);
        if (cobranca is null)
        {
            return Error.NotFound();
        }

        return new CobrancaResponse(
            cobranca.Id,
            cobranca.Descricao,
            cobranca.Valor,
            cobranca.Status,
            cobranca.CarteiraId,
            cobranca.CategoriaId,
            cobranca.ContatoId);
    }

    public async Task<CobrancaReportResponse> GetReportAsync()
    {
        return await _cobrancaRepository.GetReportAsync();
    }
}
