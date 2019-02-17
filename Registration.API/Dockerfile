FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY Registration.API/Registration.API.csproj Registration.API/
RUN dotnet restore Registration.API/Registration.API.csproj
COPY . .
WORKDIR /src/Registration.API
RUN dotnet build Registration.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Registration.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Registration.API.dll"]
