namespace Wallet.Contracts.Users;

public record AuthenticationResult(
    Guid Id,
    string Nome,
    string Email,
    string Token,
    string RefreshToken,
    DateTime RefreshTokenExpiry);