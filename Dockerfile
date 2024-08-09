FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
RUN apt-get update \
    && apt-get install -y curl=7.88.1-10+deb12u6 --no-install-recommends\
    && rm -rf /var/lib/apt/lists/*
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
HEALTHCHECK CMD curl -f http://localhost:8080/health || exit
