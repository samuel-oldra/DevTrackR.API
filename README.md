# Projeto de API usando C# e .NET 6

## DevTrackR - Jornada .NET Direto ao Ponto

Foi desenvolvida uma API REST completa de gerenciamento de pacotes.

## Tecnologias e práticas utilizadas
- ASP.NET Core com .NET 6
- Entity Framework Core
- SQL Server / In-Memory database
- Swagger
- Injeção de Dependência
- Programação Orientada a Objetos
- Padrão Repository
- Envio de E-mails com SendGrid
- Clean Code
- Publicação

## Funcionalidades
- Cadastro, Listagem, Detalhes de Pacote
- Cadastro de Atualização de Pacote

###

![alt text](https://raw.githubusercontent.com/samuel-oldra/DevTrackR.API/main/README_IMGS/swagger_ui.png)

## Comandos básicos
```
dotnet new gitignore
dotnet new webapi -o DevTrackR.API
dotnet new console -o DevTrackR.Console
dotnet build
dotnet run
dotnet watch run
dotnet publish
```

## Comandos user-secrets
```
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:DevTrackRCs" "Server=localhost;Database=DevTrackRCs;User ID=sa;Password=senha;"
dotnet user-secrets set "SendGridApiKey" "1234567890"
dotnet user-secrets list
```

## Tool Entity Framework Core (migrations)
```
dotnet tool install --global dotnet-ef
```

## Migrations
```
dotnet ef migrations add InitialMigration -o Persistence/Migrations
dotnet ef database update
```