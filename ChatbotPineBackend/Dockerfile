# Imagem base para .NET SDK, que contém o .NET CLI para construir e restaurar pacotes.
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Definir o diretório de trabalho dentro do container
WORKDIR /app

# Copiar o arquivo do projeto e restaurar dependências
COPY *.csproj ./
RUN dotnet restore

# Copiar todos os arquivos do projeto para dentro do container
COPY . ./

# Construir o projeto
RUN dotnet publish -c Release -o out

# Imagem base para a execução da aplicação (imagem mais leve, sem o SDK completo)
FROM mcr.microsoft.com/dotnet/aspnet:8.0

# Definir o diretório de trabalho dentro do container
WORKDIR /app

# Copiar a aplicação publicada do container de build
COPY --from=build /app/out ./

# Expor a porta em que o app vai rodar
EXPOSE 7296

# Comando para rodar a aplicação dentro do container
ENTRYPOINT ["dotnet", "ChatbotPineBackend.dll"]
