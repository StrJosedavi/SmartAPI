# SmartAPI 👨‍💻
#### Projeto de uma API Pura para serviços, escrita em C# utilizando o framework ASP.NET Core e o banco de dados PostgreSQL.

## Utilização 👨‍🏫

- Clone este repositório em sua máquina local:
    
    ```gitbash
    git clone https://github.com/StrJosedavi/SmartAPI.git
    ```

### VS 2022:

- Inicie a aplicação executando a solution pelo Visual Studio 2022.
- Dê start na aplicação, com isso irá abrir uma guia em seu navegador do SWAGGER, contendo todos os endpoints da aplicação.

### VS Code:

- Build a aplicação digitando o seguinte comando no terminal:
  ##### Atente-se de antes de executar o comando, estar no mesmo caminho do arquivo .csproj principal da aplicação.
    
    ```powershell
    dotnet build
    ```

- Crie ou edite o arquivo launch.json dentro da pasta .vscode, com o seguinte json:

```json
{
  "version": "0.2.0",
  "configurations": [
    {
      "name": "Launch SmartAPI",
      "program": "${workspaceFolder}/SmartAPI/bin/Debug/net6.0/SmartAPI.dll",
      "request": "launch",
      "type": "coreclr",
      "env": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      },
      "cwd": "${workspaceFolder}/SmartAPI"
    }
  ]
}
```

- Busque a opção de Run And Debug do Vs Code e na opção Launch SmartAPI, execute a aplicação:

    ![image](https://github.com/StrJosedavi/SmartAPI/assets/97465437/71c25a6c-a57a-4c9c-b961-93dc22f04cbe)

- Após isso, só utilizar a seguinte url para visualizar os métodos no swagger:

    [Swagger Index](https://localhost:7218/swagger/index.html)

## Dependências 🚀

#### 1. Instale o .NET Core SDK e o SQLServer em sua máquina local.

#### 2. Configure a conexão com o banco de dados SQLServer no arquivo appsettingsDevelopment.json:

```json
"ConnectionStrings": {    
    "DefaultConnection": "Host=localhost;Port=5432;Database=SmartAPI;Username=Davi;Password=123"      
},
```
 
#### 3. Execute o comando abaixo na pasta raiz do projeto para criar as tabelas no banco de dados:

```powershell
dotnet ef database update --project SmartAPI.Infrastructure
```

#### Extra: Caso queira reverter as migrations, basta utilizar o seguinte comando:

```powershell
dotnet ef database update 0 --project SmartAPI.Infrastructure
```

**Obs:. Atente-se de estar no caminho principal, para a execução da migration corretamente**
## Collection para Testes Postman: 🧬📊

[POSTMAN COLLECTION](https://web.postman.co/workspace/SmartAPI~3968ccf6-bdb5-42a7-826c-ebe731648148/overview)

## Referências 📖

- [common-web-application-architectures](https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures)
- [.NET Download](https://dotnet.microsoft.com/pt-br/download/dotnet)
- [AspNet-Core-Tutorials](https://learn.microsoft.com/pt-br/aspnet/core/tutorials/first-web-api?view=aspnetcore-7.0&tabs=visual-studio)
- [Documentation ASP.NET Core](https://learn.microsoft.com/pt-br/aspnet/core/?view=aspnetcore-7.0)
- [Documentation .NET](https://learn.microsoft.com/en-us/dotnet/)
- [Documentation Entity Framework](https://learn.microsoft.com/en-us/ef/)
- [Documentation SQL SERVER](https://learn.microsoft.com/en-us/sql/sql-server/?view=sql-server-ver16)
- [Launch Json VSCode](https://code.visualstudio.com/docs/csharp/debugger-settings)
- [GitHub WorkFlow](https://docs.github.com/en/actions/using-workflows)
- [Documentation Swagger](https://swagger.io/docs/)
- [Documentation Xunit](https://xunit.net/#documentation)
- [Documentation AutoMapper](https://docs.automapper.org/en/stable/)

## Contribuição 👍
#### Se você encontrar um bug ou quiser contribuir com o projeto, sinta-se à vontade para abrir uma issue.
