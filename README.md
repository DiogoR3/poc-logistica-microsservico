# Prova de Conceito - Logística em Microsserviços

## Requisitos para executar o projeto:
  - Docker
  - .NET SDK/Runtime

## Passos:

```cmd
cd "src\POC.LogisticaMicrosservico.InformacoesCadastrais"
dotnet publish -c release
```

```cmd
cd "src\POC.LogisticaMicrosservico.ServicosAoCliente"
dotnet publish -c release
```

```cmd
cd "src\POC.LogisticaMicrosservico.Web"
dotnet publish -c release
```

```cmd
cd src
docker-compose up
```
