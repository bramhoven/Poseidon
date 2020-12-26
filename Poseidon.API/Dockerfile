FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /app
COPY bin/Release/netcoreapp3.1/Poseidon.Api.dll ./
EXPOSE 80
ENTRYPOINT ["dotnet", "Poseidon.Api.dll"]