# SmartAPI
#### Projeto de uma API para atender as necessidades de uma aplicação WEB, escrita em C# utilizando o framework ASP.NET Core e o banco de dados SQLServer.

## Instalação
#### 1. Clone este repositório em sua máquina local:

``
git clone https://github.com/StrJosedavi/SmartAPI.git
``

#### 2. Instale o .NET Core SDK e o SQLServer em sua máquina local.

#### 3. Configure a conexão com o banco de dados SQLServer no arquivo appsettingsDevelopment.json:

``
"ConnectionStrings": {
    "SqlServer": "Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;TrustServerCertificate=True;"
 },
 ``
 
#### 4. Execute o comando abaixo na pasta raiz do projeto para criar as tabelas no banco de dados:

``dotnet ef database update``

## Utilização

VS 2022:
#### 1. Inicie a aplicação executando a solution pelo Visual Studio 2022.

#### 2. Ao executar, irá abrir uma guia em seu navegador, contendo todos os endpoints da aplicação.

## Contribuição
##### Se você encontrar um bug ou quiser contribuir com o projeto, sinta-se à vontade para abrir uma issue ou enviar um pull request.
