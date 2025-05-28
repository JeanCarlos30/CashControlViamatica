FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["CashControl.API/CashControl.API.csproj", "CashControl.API/"]
RUN dotnet restore "CashControl.API/CashControl.API.csproj"
COPY . .
WORKDIR "/src/CashControl.API"
RUN dotnet build "CashControl.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CashControl.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CashControl.API.dll"]