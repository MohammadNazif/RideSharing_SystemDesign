# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY . .
RUN dotnet restore "RideSharing.sln"
RUN dotnet publish "src/RideSharing.Api/RideSharing.Api.csproj" -c Release -o /out

# Runtime Stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /out .
ENTRYPOINT ["dotnet", "RideSharing.Api.dll"]
