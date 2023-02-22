FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Pokemon-Api-BackEnd/Pokemon-Api-BackEnd.csproj", "Pokemon-Api-BackEnd/"]
RUN dotnet restore "Pokemon-Api-BackEnd/Pokemon-Api-BackEnd.csproj"
COPY . .
WORKDIR "/src/Pokemon-Api-BackEnd"
RUN dotnet build "Pokemon-Api-BackEnd.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pokemon-Api-BackEnd.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pokemon-Api-BackEnd.dll"]
