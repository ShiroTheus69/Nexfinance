# Base runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5163
EXPOSE 7075

# Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia o .csproj da raiz
COPY ["././NexFinance.csproj", "./"]
RUN dotnet restore "./NexFinance.csproj"

# Copia a pasta src
COPY ././src ./src
RUN dotnet build "./NexFinance.csproj" -c Release -o /app/build

# Publish
FROM build AS publish
RUN dotnet publish "./NexFinance.csproj" -c Release -o /app/publish

# Runtime final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NexFinance.dll"]
