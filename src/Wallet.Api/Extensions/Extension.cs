using Microsoft.EntityFrameworkCore;

using Wallet.Infrastructure.Persistence.Contexts;

namespace Wallet.Api.Extensions;

internal static class Extension
{
    public static WebApplication ApplyMigrations(this WebApplication app)
    {
        using var apiDbContext = app.Services
            .CreateScope()
            .ServiceProvider
            .GetRequiredService<ApiDbContext>();

        apiDbContext.Database.Migrate();

        return app;
    }
}