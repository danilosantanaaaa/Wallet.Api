using Wallet.Domain.Common.Entities;

namespace Wallet.Domain.Users;

public class User : Entity
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public bool IsActive { get; private set; }
    public string RefreshToken { get; private set; }
    public DateTime RefreshTokenExpiry { get; private set; }

    public User(
        string name,
        string email,
        string passwordHash,
        bool isActive,
        string refreshToken,
        DateTime refreshTokenExpiry,
        Guid? id = null) : base(id ?? Guid.CreateVersion7())
    {
        Name = name;
        Email = email;
        PasswordHash = passwordHash;
        IsActive = isActive;
        RefreshToken = refreshToken;
        RefreshTokenExpiry = refreshTokenExpiry;
    }

    public void SetRefreskToken(
        string refreshToken,
        DateTime refreshTokenExpiry)
    {
        RefreshToken = refreshToken;
        RefreshTokenExpiry = refreshTokenExpiry;
    }

    private User() : base(default)
    {

    }
}