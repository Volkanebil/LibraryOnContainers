FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY OcelotApiGateway/OcelotApiGateway.csproj OcelotApiGateway/
RUN dotnet restore OcelotApiGateway/OcelotApiGateway.csproj
COPY . .
WORKDIR /src/OcelotApiGateway
RUN dotnet build OcelotApiGateway.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish OcelotApiGateway.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "OcelotApiGateway.dll"]
