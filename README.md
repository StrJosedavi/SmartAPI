# SmartAPI
#### Projeto de uma API Pura para serviços, com o objetivo de ser um SaaS de controle de gastos, escrita em C# utilizando o framework ASP.NET Core e o banco de dados SQLServer.

# Arquitetura Utilizada para esse projeto:

(Layered Architecture)
![image5-2](https://github.com/StrJosedavi/SmartAPI/assets/97465437/0cd1185d-fa74-4afc-8a5e-e13fc3c52e0c)

## Utilização

- Clone este repositório em sua máquina local:
    
    ```gitbash
    git clone https://github.com/StrJosedavi/SmartAPI.git
    ```

### VS 2022:

- Inicie a aplicação executando a solution pelo Visual Studio 2022.
- Dê start na aplicação, com isso irá abrir uma guia em seu navegador do SWAGGER, contendo todos os endpoints da aplicação.

### VS Code:

- Build a aplicação digitando o seguinte comando no terminal:
    - obs: atente-se de antes de executar o comando, estar no mesmo caminho do arquivo .csproj principal da aplicação.

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

## Dependências

#### 1. Instale o .NET Core SDK e o SQLServer em sua máquina local.

#### 2. Configure a conexão com o banco de dados SQLServer no arquivo appsettingsDevelopment.json:

    ```json
    "ConnectionStrings": {
        "SqlServer": "Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;TrustServerCertificate=True;"
     },
     ```
 
#### 3. Execute o comando abaixo na pasta raiz do projeto para criar as tabelas no banco de dados:

    ```powershell
    dotnet ef database update
    ```

## Contribuição
##### Se você encontrar um bug ou quiser contribuir com o projeto, sinta-se à vontade para abrir uma issue ou enviar um pull request.
