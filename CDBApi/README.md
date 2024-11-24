# CDB Solution

## Requisitos
- Visual Studio 2022 ou Visual Studio Code
- .NET Framework 4.7.2 ou superior
- Node.js e npm (para o frontend Angular)

## Configuração
1. Clone o repositório.
2. Abra a solução no Visual Studio ou Visual Studio Code.
3. Restaure os pacotes NuGet.
4. Compile e execute o projeto.

## Execução da API
1. Navegue até o diretório do projeto `CDBApi`.
2. Execute o comando `dotnet run` para iniciar a API.
3. A API estará disponível em `http://localhost:5050`.

## Execução do Frontend Angular
1. Navegue até o diretório do projeto `CDBClient`.
2. Execute o comando `npm install` para instalar as dependências.
3. Execute o comando `npm start` para iniciar o frontend Angular.
4. O frontend estará disponível em `http://localhost:4200`.

## Testes
1. Navegue até o diretório do projeto de testes `CDBApi.Tests`.
2. Execute o comando `dotnet test` para executar os testes.
3. Para verificar a cobertura de teste, execute o comando:
   ```sh
   dotnet test /p:CollectCoverage=true