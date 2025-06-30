using FriendlyResult;
using FriendlyResult.Enums;

using Wallet.Application.Services.Interfaces;
using Wallet.Contracts.Contatos;
using Wallet.Domain.Common.Interfaces;
using Wallet.Domain.Common.Repositories;
using Wallet.Domain.Contatos;

namespace Wallet.Application.Services;

internal sealed class ContatoService(
    IContatoRepository contatoRepository,
    IUnitOfWork unitOfWork) : IContatoService
{
    private readonly IContatoRepository _contatoRepository = contatoRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result<Guid>> CreateAsync(ContatoRequest request)
    {
        var contato = new Contato(
            request.Nome,
            request.Email,
            request.Telefone);

        await _contatoRepository.AddAsync(contato);
        await _unitOfWork.SaveChangesAsync();

        return contato.Id;
    }

    public async Task<Result<Deleted>> DeleteAsync(Guid id)
    {
        var contato = await _contatoRepository.GetByIdAsync(id);
        if (contato is null)
        {
            return Error.NotFound();
        }

        await _contatoRepository.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();

        return ResultState.Deleted;
    }

    public async Task<Result<Updated>> UpdateAsync(Guid id, ContatoRequest request)
    {
        var contato = await _contatoRepository.GetByIdAsync(id);
        if (contato is null)
        {
            return Error.NotFound();
        }

        contato.Update(
            request.Nome,
            request.Email,
            request.Telefone);

        await _contatoRepository.UpdateAsync(contato);
        await _unitOfWork.SaveChangesAsync();

        return ResultState.Updated;
    }

    public async Task<IEnumerable<ContatoResponse>> GetAllAsync()
    {
        var contatos = await _contatoRepository.GetAllAsync();

        return contatos
            .Select(c => new ContatoResponse(
                c.Id,
                c.Nome,
                c.Email,
                c.Telefone))
            .ToList();
    }

    public async Task<Result<ContatoResponse?>> GetByIdAsync(Guid id)
    {
        var contato = await _contatoRepository.GetByIdAsync(id);
        if (contato is null)
        {
            return Error.NotFound();
        }

        return new ContatoResponse(
            contato.Id,
            contato.Nome,
            contato.Email,
            contato.Telefone);
    }
}
