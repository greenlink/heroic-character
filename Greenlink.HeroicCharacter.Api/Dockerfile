# --- Build Stage ---
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy csproj and restore
COPY *.csproj ./Greenlink.HeroicCharacter.Api/
RUN dotnet restore Greenlink.HeroicCharacter.Api/Greenlink.HeroicCharacter.Api.csproj

# Copy everything and build
COPY . .
WORKDIR /src/Greenlink.HeroicCharacter.Api
RUN dotnet publish -c Release -o /app/publish

# --- Runtime Stage ---
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 5030
ENTRYPOINT ["dotnet", "Greenlink.HeroicCharacter.Api.dll"]
