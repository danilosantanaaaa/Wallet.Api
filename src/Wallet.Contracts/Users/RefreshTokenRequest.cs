namespace Wallet.Contracts.Users;

public record RefreshTokenRequest(
    string Token,
    string RefreshToken);