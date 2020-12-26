FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS build

WORKDIR /app

COPY . .

RUN cat ./secrets.json | dotnet user-secrets set

FROM mcr.microsoft.com/dotnet/aspnet:3.1

WORKDIR /app

COPY --from=build /app/bin/Release/netcoreapp3.1/Poseidon.Api.dll ./

EXPOSE 80

ENTRYPOINT ["dotnet", "Poseidon.Api.dll"]