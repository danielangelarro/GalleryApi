FROM mcr.microsoft.com/dotnet/aspnet:7.0-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 5109

ENV ASPNETCORE_URLS=http://+:5109

FROM mcr.microsoft.com/dotnet/sdk:7.0-nanoserver-1809 AS build
ARG configuration=Release
WORKDIR /src
COPY ["src/GalleryApi.API/GalleryApi.API.csproj", "src/GalleryApi.API/"]
RUN dotnet restore "src\GalleryApi.API\GalleryApi.API.csproj"
COPY . .
WORKDIR "/src/src/GalleryApi.API"
RUN dotnet build "GalleryApi.API.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "GalleryApi.API.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GalleryApi.API.dll"]
