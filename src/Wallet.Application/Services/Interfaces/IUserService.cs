using FriendlyResult;

using Wallet.Contracts.Users;

namespace Wallet.Application.Services.Interfaces;

public interface IUserService
{
    Task<Result<AuthenticationResult>> CreateAsync(UserRequest request);
    Task<Result<AuthenticationResult>> LoginAsync(LoginRequest request);
    Task<Result<AuthenticationResult>> RefreshTokenAsync(RefreshTokenRequest request);
    Task<Result<UserResponse?>> GetByIdAsync(Guid id);
}