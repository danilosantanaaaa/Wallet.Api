using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi;

namespace Wallet.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Add services to the container.
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        services.AddOpenApi(options =>
       {
           options.AddDocumentTransformer<BearerConfig>();
           options.OpenApiVersion = OpenApiSpecVersion.OpenApi3_0;
       });

        services.AddProblemDetails();
        services.AddCors(configuration);

        services.AddControllers(options =>
        {
            options.SuppressAsyncSuffixInActionNames = false;
        });

        services.AddEndpointsApiExplorer();

        return services;
    }

    private static IServiceCollection AddCors(
        this IServiceCollection services,
        IConfiguration configuration)
    {

        var corsUrl = configuration.GetValue<string>("CorsUrl") ??
            throw new InvalidOperationException();

        services.AddCors(policy =>
        {
            policy.AddPolicy(name: CorsConfig.MyAllowSpecificOrigins, builder =>
            {
                builder.WithOrigins(corsUrl)
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });

        return services;
    }
}