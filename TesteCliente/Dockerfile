#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["nuget.config", "."]
COPY ["TesteCliente/TesteCliente.csproj", "TesteCliente/"]
COPY ["TesteCliente.Persistencia/TesteCliente.Persistencia.csproj", "TesteCliente.Persistencia/"]
COPY ["TesteCliente.Core/TesteCliente.Core.csproj", "TesteCliente.Core/"]

RUN dotnet restore --configfile "nuget.config" "TesteCliente/TesteCliente.csproj"
COPY . .
WORKDIR "/src/TesteCliente"
RUN dotnet build "TesteCliente.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TesteCliente.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TesteCliente.dll"]