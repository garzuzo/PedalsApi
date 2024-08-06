FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["PedalsApi/", "PedalsApi/"]
COPY ["PedalsApi.Domain/PedalsApi.Domain.csproj", "PedalsApi.Domain/"]
COPY ["PedalsApi.Application/PedalsApi.Application.csproj", "PedalsApi.Application/"]
COPY ["PedalsApi.Infrastructure/PedalsApi.Infrastructure.csproj", "PedalsApi.Infrastructure/"]
RUN dotnet restore "./PedalsApi/PedalsApi.csproj"
COPY . .
WORKDIR "/src/PedalsApi/"
RUN dotnet build "./PedalsApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./PedalsApi.csproj" -c Release -o /app/publish 

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PedalsApi.dll"]

#Health check configuration
HEALTHCHECK --interval=50s --timeout=10s --start-period=30s --retries=3 \
CMD curl -f http://localhost:8080/health || exit 1
