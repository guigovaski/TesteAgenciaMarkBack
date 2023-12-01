FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["AgenciaEventosAPI/AgenciaEventosAPI.csproj", "AgenciaEventosAPI/"]
RUN dotnet restore "AgenciaEventosAPI/AgenciaEventosAPI.csproj"
COPY . .
WORKDIR "/src/AgenciaEventosAPI"
RUN dotnet build "AgenciaEventosAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AgenciaEventosAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AgenciaEventosAPI.dll"]