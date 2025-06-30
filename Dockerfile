FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["src/Wallet.Api/Wallet.Api.csproj", "Wallet.Api/"]
COPY ["src/Wallet.Application/Wallet.Application.csproj", "Wallet.Application/"]
COPY ["src/Wallet.Domain/Wallet.Domain.csproj", "Wallet.Domain/"]
COPY ["src/Wallet.Contracts/Wallet.Contracts.csproj", "Wallet.Contracts/"]
COPY ["src/Wallet.Infrastructure/Wallet.Infrastructure.csproj", "Wallet.Infrastructure/"]

RUN dotnet restore "Wallet.Api/Wallet.Api.csproj"
COPY . ../
WORKDIR /src/Wallet.Api
RUN dotnet build "Wallet.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish --no-restore -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0
ENV ASPNETCORE_HTTP_PORTS=8080
EXPOSE 8080
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "Wallet.Api.dll"]