using FriendlyResult;
using static FriendlyResult.Error;

using Microsoft.Extensions.DependencyInjection;

using Wallet.Application.Common;
using Wallet.Application.Services.Interfaces;
using Wallet.Contracts.Users;
using Wallet.Domain.Common.Interfaces;
using Wallet.Domain.Common.Repositories;
using Wallet.Domain.Users;

namespace Wallet.Application.Services;

internal sealed class UserService(
    IUserRepository userRepository,
    IUnitOfWork unitOfWork,
    IPasswordHashProvider passwordHashProvider,
    IDateTimeProvider dateTimeProvider,
    IServiceScopeFactory serviceScopeFactory,
    IUserProvider userProvider) : IUserService
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IPasswordHashProvider _passwordHashProvider = passwordHashProvider;
    private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;
    private readonly IUserProvider _userProvider = userProvider;
    private readonly ITokenGenerator jwtTokenGenerator = serviceScopeFactory.CreateScope().ServiceProvider.GetKeyedService<ITokenGenerator>(TokenGeneratorType.Jwt)!;
    private readonly ITokenGenerator _refreshTokenGenerator = serviceScopeFactory.CreateScope().ServiceProvider.GetKeyedService<ITokenGenerator>(TokenGeneratorType.RefreshToken)!;

    public async Task<Result<AuthenticationResult>> CreateAsync(UserRequest request)
    {
        var userResult = await _userRepository.GetByEmail(request.Email);
        if (userResult is not null)
        {
            return Validation("User.Email", "Email já cadastrado.");
        }

        var passwordHash = _passwordHashProvider.Hash(request.Password);
        var refreshToken = _refreshTokenGenerator.Generate(null!);

        var user = new User(
            request.Name,
            request.Email,
            passwordHash,
            true,
            refreshToken,
            _dateTimeProvider.UtcNow);

        await _userRepository.AddAsync(user);
        await _unitOfWork.SaveChangesAsync();

        var token = jwtTokenGenerator.Generate(user);

        return new AuthenticationResult(
            user.Id,
            user.Name,
            user.Email,
            token,
            user.RefreshToken,
            user.RefreshTokenExpiry);
    }

    public async Task<Result<AuthenticationResult>> LoginAsync(LoginRequest request)
    {
        var user = await _userRepository.GetByEmail(request.Email);

        if (user is null || !_passwordHashProvider.VerifyPassword(request.Password, user.PasswordHash))
        {
            return Inauthorized("User.Login", "Email/Senha está inválida.");
        }

        var token = jwtTokenGenerator.Generate(user);
        var refreshToken = _refreshTokenGenerator.Generate(null!);

        user.SetRefreskToken(refreshToken, _dateTimeProvider.UtcNow);

        await _userRepository.UpdateAsync(user);
        await _unitOfWork.SaveChangesAsync();

        return new AuthenticationResult(
            user.Id,
            user.Name,
            user.Email,
            token,
            user.RefreshToken,
            user.RefreshTokenExpiry);
    }

    public async Task<Result<UserResponse?>> GetByIdAsync(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user is null)
        {
            return NotFound();
        }

        return new UserResponse(
            user.Id,
            user.Name,
            user.Email,
            user.IsActive);
    }

    public async Task<Result<AuthenticationResult>> RefreshTokenAsync(RefreshTokenRequest request)
    {
        Guid userId = _userProvider.GetUserId(request.Token)
            ?? throw new NullReferenceException();

        var user = await _userRepository.GetByIdAsync(userId);
        if (user is null)
        {
            return NotFound();
        }

        if (!user.PasswordHash.Equals(request.RefreshToken))
        {
            return Inauthorized(
                "User.RefreshToken",
                "Refreh token vencido ou inválido.");
        }

        var token = jwtTokenGenerator.Generate(user);
        var refreshToken = _refreshTokenGenerator.Generate(null!);

        user.SetRefreskToken(refreshToken, _dateTimeProvider.UtcNow);

        await _userRepository.UpdateAsync(user);
        await _unitOfWork.SaveChangesAsync();

        return new AuthenticationResult(
            user.Id,
            user.Name,
            user.Email,
            token,
            user.RefreshToken,
            user.RefreshTokenExpiry);
    }
}
