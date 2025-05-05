FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . ./

WORKDIR /src/src/Presentation

RUN dotnet restore RegistraterAuthWeb.csproj
RUN dotnet publish RegistraterAuthWeb.csproj -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /app/out ./

EXPOSE 80

ENTRYPOINT ["dotnet", "RegistraterAuthWeb.dll"]