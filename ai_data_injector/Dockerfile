#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["ai_data_injector.csproj", "."]
RUN dotnet restore "./ai_data_injector.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "ai_data_injector.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ai_data_injector.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ai_data_injector.dll"]
