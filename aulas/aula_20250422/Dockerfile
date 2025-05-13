FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["MonolitoBackend.Api/MonolitoBackend.Api.csproj", "MonolitoBackend.Api/"]
COPY ["MonolitoBackend.Core/MonolitoBackend.Core.csproj", "MonolitoBackend.Core/"]
COPY ["MonolitoBackend.Infrastructure/MonolitoBackend.Infrastructure.csproj", "MonolitoBackend.Infrastructure/"]

RUN dotnet restore "MonolitoBackend.Api/MonolitoBackend.Api.csproj"
COPY . .
WORKDIR "/src/MonolitoBackend.Api"
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MonolitoBackend.Api.dll"]
