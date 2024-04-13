# Use a imagem base do SDK do .NET Core para construir o aplicativo
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app

# Copie o arquivo csproj e restaurar dependências
COPY SmartAPI/*.csproj ./SmartAPI/
COPY SmartAPI.Business/*.csproj ./SmartAPI.Business/
COPY SmartAPI.Infrastructure/*.csproj ./SmartAPI.Infrastructure/
RUN dotnet restore

# Copie todo o código-fonte e construa o aplicativo
COPY . .
RUN dotnet publish -c Release -o out

# Imagem de tempo de execução para a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./
EXPOSE 80
ENTRYPOINT ["dotnet", "SmartAPI.Application.dll"]


