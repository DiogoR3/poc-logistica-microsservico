FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine
COPY bin/Release/net5.0/publish/ App/
WORKDIR /App
ENTRYPOINT ["dotnet", "POC.LogisticaMicrosservico.Web.dll"]
