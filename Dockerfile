# Use a imagem base do SDK do .NET Core para construir o aplicativo
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Defina o diretório de trabalho como /app
WORKDIR /app

# Copie o código-fonte para o diretório de trabalho
COPY . /app

COPY ./*.csproj ./smartAPI 

# Construa o aplicativo no modo de lançamento e gere o artefato final
RUN dotnet publish -c Release -o out

# Imagem de tempo de execução para a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

# Defina o diretório de trabalho como /app
WORKDIR /app

# Copie o artefato final da imagem de construção para a imagem de tempo de execução
COPY --from=build /app/out ./

# Exponha a porta 80 para o tráfego HTTP
EXPOSE 80

# Defina o ponto de entrada do aplicativo
ENTRYPOINT ["dotnet", "SmartAPI.dll"]
