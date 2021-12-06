#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Har.Archive.Backend.Api/Har.Archive.Backend.Api.csproj", "Har.Archive.Backend.Api/"]
RUN dotnet restore "Har.Archive.Backend.Api/Har.Archive.Backend.Api.csproj"
COPY . .
WORKDIR "/src/Har.Archive.Backend.Api"
RUN dotnet build "Har.Archive.Backend.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Har.Archive.Backend.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Har.Archive.Backend.Api.dll"]