FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CQRSApi/CQRSApi.csproj", "CQRSApi/"]
RUN dotnet restore "CQRSApi/CQRSApi.csproj"
COPY . .
WORKDIR "/src/CQRSApi"
RUN dotnet build "CQRSApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CQRSApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CQRSApi.dll"]
