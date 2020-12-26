FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app
COPY bin/Release/netcoreapp3.1/Poseidon.Api.dll ./
EXPOSE 80
ENTRYPOINT ["dotnet", "Poseidon.Api.dll"]