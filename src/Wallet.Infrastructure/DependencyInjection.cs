using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Wallet.Application.Common;
using Wallet.Domain.Common.Interfaces;
using Wallet.Domain.Common.Repositories;
using Wallet.Infrastructure.Persistence.Contexts;
using Wallet.Infrastructure.Persistence.Repositories;
using Wallet.Infrastructure.Security.PasswordHashers;
using Wallet.Infrastructure.Security.Tokens;
using Wallet.Infrastructure.Services;

namespace Wallet.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .AddHttpContextAccessor()
            .AddServices()
            .AddAuthentication(configuration)
            .AddPersistence(configuration);

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<IDateTimeProvider, SystemDateTimeProvider>();
        services.AddScoped<IPasswordHashProvider, PasswordHashProvider>();
        services.AddScoped<IUserProvider, UserProvider>();

        return services;
    }

    private static IServiceCollection AddAuthentication(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

        services.AddKeyedScoped<ITokenGenerator, JwtTokenGenerator>(TokenGeneratorType.Jwt);
        services.AddKeyedScoped<ITokenGenerator, RefreshTokenGenerator>(TokenGeneratorType.RefreshToken);

        services.ConfigureOptions<JwtBearerTokenValidationConfiguration>()
            .AddAuthentication()
            .AddJwtBearer();

        services.AddAuthorization();

        return services;
    }

    private static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("PostgreConnection")
            ?? throw new InvalidOperationException("Connection string 'PostgreConnection' not found.");

        services.AddDbContext<ApiDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });

        services.AddScoped<ICarteiraRepository, CarteiraRepository>();
        services.AddScoped<ICategoriaRepository, CategoriaRepository>();
        services.AddScoped<IContatoRepository, ContatoRepository>();
        services.AddScoped<ICobrancaRepository, CobrancaRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
