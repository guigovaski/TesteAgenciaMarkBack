# TesteAgenciaMarkBack

## Informações
- O banco de dados do projeto está configurado em um arquivo docker-compose, para poder usar o banco, você precisará usar o comando `docker-compose up` no mesmo nível do arquivo docker-compose e depois rodar o comando `docker-compose start`
- O projeto precisa criar a estrutura das tabelas no banco de dados, para isso use o comando: `dotnet ef migrations add "MigrationName"` para rodar as migrações e criar a estrutura no banco de dados
- O projeto está configurado para fazer seed no banco de dados (mockar alguns dados de teste) então após criar as migrations, você deve executar o comando `dotnet ef database update` para de fato executar as instruções SQL no banc, criar a estrutura das tabelas e fazer o seed dos dados
- **ATENÇÂO** para executar os 2 procedimentos acima, você deve ter a ferramenta do Entity Framework instalada na sua máquina, caso não tenha, use o comando `dotnet tool install --global dotnet-ef`
- Para rodar o projeto, use o comando: `dotnet run` dentro da pasta em que o arquivo .csproj se encontra ou utilize uma IDE
- O projeto está configurado para rodar na porta HTTP 5111
- Caminho para acessar a rota da documentação do Swagger: `http://localhost:5111/swagger/index.html`
