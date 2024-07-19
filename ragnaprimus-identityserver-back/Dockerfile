
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ragnaprimus-identityserver-back/ragnaprimus-identityserver-back.csproj", "ragnaprimus-identityserver-back/"]
RUN dotnet restore "ragnaprimus-identityserver-back/ragnaprimus-identityserver-back.csproj"
COPY . .
WORKDIR "/src/ragnaprimus-identityserver-back"
RUN dotnet build "ragnaprimus-identityserver-back.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ragnaprimus-identityserver-back.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
ENV ASPNETCORE_ENVIRONMENT="Prod"
ENV ASPNETCORE_URLS=http://+:5000
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ragnaprimus-identityserver-back.dll"]