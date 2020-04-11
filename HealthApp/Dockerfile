#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
ENV DOTNET_USE_POLLING_FILE_WATCHER 1
ENV ASPNETCORE_ENVIRONMENT Development
ENV ASPNETCORE_URLS "http://+:8000"
WORKDIR /app
EXPOSE 8000

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["HealthApp/HealthApp.csproj", "HealthApp/"]
RUN dotnet restore "HealthApp/HealthApp.csproj"
COPY . .
WORKDIR "/src/HealthApp"
RUN dotnet build "HealthApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HealthApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HealthApp.dll"]