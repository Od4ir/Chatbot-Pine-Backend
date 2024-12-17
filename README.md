# Chatbot Pine Backend

Este projeto é o **backend** do sistema de **Chatbot** para o **Banco Pine**, desenvolvido em **.NET 8.0** utilizando **C#**. Ele fornece APIs para interação com um banco de dados SQL Server, permitindo consultas de dados bancários, produtos financeiros, transações, entre outros.

## Tecnologias Utilizadas

- **.NET 8.0**: Framework para desenvolvimento de APIs.
- **C#**: Linguagem de programação principal.
- **SQL Server**: Banco de dados relacional utilizado para persistência dos dados.
- **Swagger**: Ferramenta para documentação e teste das APIs.
- **Entity Framework Core**: ORM (Object-Relational Mapper) para interação com o banco de dados.

## Estrutura do Projeto

A estrutura do projeto é organizada da seguinte maneira:

```plaintext
📁 ChatbotPineBackend/
├── 📁 Controllers/        # Contém os controladores das APIs
├── 📁 Models/             # Modelos de dados para o banco
├── 📁 Data/               # Contexto do banco de dados (DbContext)
├── Program.cs             # Arquivo principal de configuração e inicialização
├── appsettings.json       # Configurações do banco de dados e outros parâmetros
├── appsettings.Development.json # Configurações para desenvolvimento
├── ChatbotPineBackend.csproj  # Arquivo de projeto com dependências
```

## Requisitos

- **.NET 8.0** ou superior.
- **SQL Server** instalado (ou Docker configurado para rodar SQL Server).

## Configuração Inicial

### Clonando o Repositório

Clone o repositório para sua máquina local:

```bash
git clone https://github.com/SEU-USUARIO/chatbot-pine-backend.git
cd chatbot-pine-backend
```

### Instalação das Dependências

Instale as dependências do projeto com o comando:

```bash
dotnet restore
```

### Configuração do Banco de Dados

Configure a string de conexão no arquivo `appsettings.json`:

```json
{
    "ConnectionStrings": {
        "DefaultConnection": "Server=localhost,1433;Database=chatbot_bancopine_bd;User Id=sa;Password=SuaSenhaForte123;TrustServerCertificate=True;"
    }
}
```

### Rodando o Projeto

Execute o projeto localmente:

```bash
dotnet run
```

A aplicação estará disponível em `https://localhost:7296` (ou outra porta configurada).

### Acessando o Swagger

Abra o Swagger UI para testar os endpoints em:

```plaintext
https://localhost:7296/swagger
```
