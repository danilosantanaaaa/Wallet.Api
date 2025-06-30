namespace Wallet.Contracts.Users;

public record UserRequest(
    string Name,
    string Email,
    string Password);