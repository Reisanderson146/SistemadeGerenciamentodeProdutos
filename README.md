Sistema de Gerenciamento de Produtos — API .NET 8

Este projeto é uma API REST completa, desenvolvida em .NET 8 (versão 8.0.3), seguindo Clean Architecture e boas práticas modernas de desenvolvimento.

Tecnologias Utilizadas:
- .NET 8.0.3
- ASP.NET Core Web API
- Entity Framework Core 8 (8.0.3)
- SQL Server
- Swagger / Swashbuckle
- Dependency Injection
- Clean Architecture

Arquitetura da Solução:
SistemadeGerenciamentodeProdutos.Api → Camada de apresentação
SistemadeGerenciamentodeProdutos.Application → Regras de negócio, DTOs, Services
SistemadeGerenciamentodeProdutos.Domain → Entidades e Interfaces
SistemadeGerenciamentodeProdutos.Infrastructure → EF Core, DbContext, Migrations, Repositórios

Banco de Dados e Migrations:
- Update-Database
- Add-Migration NomeDaMigration

Endpoints:
POST /api/Produtos
GET /api/Produtos
GET /api/Produtos/{id}
PUT /api/Produtos/{id}
DELETE /api/Produtos/{id}

JSON Exemplo:
{
  "nome": "Notebook",
  "descricao": "Dell",
  "precoUnitario": 3000,
  "quantidadeInicial": 10
}

Pacotes NuGet (8.0.3):
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.AspNetCore.OpenApi
- Swashbuckle.AspNetCore

Connection String:
"ConnectionStrings": {
  "DefaultConnection": "Server=DESKTOP-VE7ISK0\SQLEXPRESS;Database=SGP;Trusted_Connection=True;TrustServerCertificate=True;"
}

Execução:
- Update-Database
- dotnet run
- Abrir Swagger

Autor: Anderson Reis
GitHub: https://github.com/Reisanderson146
