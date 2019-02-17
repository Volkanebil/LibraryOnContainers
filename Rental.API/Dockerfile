FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY Rental.API/Shipment.API.csproj Rental.API/
COPY EventBus/EventBus.csproj EventBus/
RUN dotnet restore Rental.API/Shipment.API.csproj
COPY . .
WORKDIR /src/Rental.API
RUN dotnet build Shipment.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Shipment.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Shipment.API.dll"]
