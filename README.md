<h1 align="center">
  DevTrackR - Jornada .NET Direto ao Ponto
</h1>
<p align="center">
  <a href="#tecnologias-e-práticas-utilizadas">Tecnologias e práticas utilizadas</a> •
  <a href="#funcionalidades">Funcionalidades</a> •
  <a href="#comandos">Comandos</a>
</p>

Foi desenvolvida uma API REST completa de gerenciamento de pacotes.

## Tecnologias e práticas utilizadas
- ASP.NET Core com .NET 6
- Entity Framework Core
- SQL Server / SQLite / In-Memory database
- Swagger (documentação)
- SendGrid (envio de e-mail)
- Programação Orientada a Objetos
- Injeção de Dependência
- Padrão Repository
- Clean Code
- Publicação

## Funcionalidades
- Cadastro, Listagem, Detalhes de Pacote
- Cadastro de Atualização de Pacote

###

![alt text](https://raw.githubusercontent.com/samuel-oldra/DevTrackR.API/main/README_IMGS/swagger_ui.png)

## Comandos

### Comandos básicos
```
dotnet new gitignore
dotnet new webapi -o DevTrackR.API
dotnet new console -o DevTrackR.Console

dotnet build
dotnet run
dotnet watch run

dotnet publish
```

### Comandos user-secrets
```
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:DevTrackCs" "Server=***;Database=***;User ID=***;Password=***;"
dotnet user-secrets set "SendGridApiKey" "1234567890"
dotnet user-secrets remove "ConnectionStrings:DevTrackCs"
dotnet user-secrets remove "SendGridApiKey"
dotnet user-secrets clear
dotnet user-secrets list
```

### Tool Entity Framework Core (migrations)
```
dotnet tool install --global dotnet-ef
dotnet tool uninstall --global dotnet-ef
```

### Migrations
```
dotnet ef migrations add InitialMigration -o Persistence/Migrations
dotnet ef database update
```