# Etapa 1: Build da aplicação
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copiar arquivos do projeto
COPY MonolitoBackend.sln ./
COPY MonolitoBackend.API/ MonolitoBackend.API/
COPY MonolitoBackend.Core/ MonolitoBackend.Core/
COPY MonolitoBackend.Tests/ MonolitoBackend.Tests/
COPY MonolitoBackend.Infrastructure/ MonolitoBackend.Infrastructure/

# Restaurar pacotes e compilar
RUN dotnet restore
RUN dotnet publish MonolitoBackend.API/MonolitoBackend.API.csproj -c Release -o /publish

# Etapa 2: Runtime da aplicação
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /publish .

# Expor porta
EXPOSE 5000
CMD ["dotnet", "MonolitoBackend.API.dll"]