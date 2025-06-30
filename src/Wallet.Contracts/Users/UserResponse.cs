namespace Wallet.Contracts.Users;

public record UserResponse(
    Guid Id,
    string Nome,
    string Email,
    bool IsActive);