using Wallet.Api;
using Wallet.Api.Extensions;
using Wallet.Application;
using Wallet.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddPresentation(builder.Configuration)
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("openapi/v1.json", "OpenAPI V1");
        options.RoutePrefix = string.Empty;
        options.DocumentTitle = "Wallet API";
    });

    app.ApplyMigrations();
}

app.UseHttpsRedirection();
app.UseCors(CorsConfig.MyAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers()
    .RequireAuthorization();

app.UseExceptionHandler();
await app.RunAsync();
