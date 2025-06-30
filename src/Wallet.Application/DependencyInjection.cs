using Microsoft.Extensions.DependencyInjection;

using Wallet.Application.Services;
using Wallet.Application.Services.Interfaces;

namespace Wallet.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICarteiraService, CarteiraService>();
        services.AddScoped<ICategoriaService, CategoriaService>();
        services.AddScoped<IContatoService, ContatoService>();
        services.AddScoped<ICobrancaService, CobrancaService>();
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}
