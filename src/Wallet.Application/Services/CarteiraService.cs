using FriendlyResult;
using FriendlyResult.Enums;

using Wallet.Application.Services.Interfaces;
using Wallet.Contracts.Carteiras;
using Wallet.Domain.Carteiras;
using Wallet.Domain.Common.Interfaces;
using Wallet.Domain.Common.Repositories;

namespace Wallet.Application.Services;

internal sealed class CarteiraService(
    ICarteiraRepository carteiraRepository,
    IUnitOfWork unitOfWork) : ICarteiraService
{
    private readonly ICarteiraRepository _carteiraRepository = carteiraRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result<Guid>> CreateAsync(CarteiraRequest request)
    {
        var carteira = new Carteira(
            request.Nome,
            request.Descricao);

        await _carteiraRepository.AddAsync(carteira);
        await _unitOfWork.SaveChangesAsync();

        return carteira.Id;
    }

    public async Task<Result<Deleted>> DeleteAsync(Guid id)
    {
        var carteira = await _carteiraRepository.GetByIdAsync(id);
        if (carteira is null)
        {
            return Error.NotFound();
        }

        await _carteiraRepository.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();

        return ResultState.Deleted;
    }

    public async Task<Result<Updated>> UpdateAsync(Guid id, CarteiraRequest request)
    {

        var carteira = await _carteiraRepository.GetByIdAsync(id);
        if (carteira is null)
        {
            return Error.NotFound();
        }

        carteira.Update(
            request.Nome,
            request.Descricao);

        await _carteiraRepository.UpdateAsync(carteira);
        await _unitOfWork.SaveChangesAsync();

        return ResultState.Updated;
    }

    public async Task<IEnumerable<CarteiraResponse>> GetAllAsync()
    {
        var carteiras = await _carteiraRepository.GetAllAsync();

        return carteiras
            .Select(c => new CarteiraResponse(
                c.Id,
                c.Nome,
                c.Descricao))
            .ToList();
    }

    public async Task<Result<CarteiraResponse?>> GetByIdAsync(Guid id)
    {
        var carteira = await _carteiraRepository.GetByIdAsync(id);
        if (carteira is null)
        {
            return Error.NotFound();
        }

        return new CarteiraResponse(
            carteira.Id,
            carteira.Nome,
            carteira.Descricao);
    }
}