FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY Billing.API/Billing.API.csproj Billing.API/
RUN dotnet restore Billing.API/Billing.API.csproj
COPY . .
WORKDIR /src/Billing.API
RUN dotnet build Billing.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Billing.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Billing.API.dll"]
