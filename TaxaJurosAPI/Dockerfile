#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 44384
EXPOSE 56134

ENV ASPNETCORE_URLS=http://+:56134

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["TaxaJurosAPI/TaxaJurosAPI.csproj", "TaxaJurosAPI/"]
RUN dotnet restore "TaxaJurosAPI/TaxaJurosAPI.csproj"
COPY . .
WORKDIR "/src/TaxaJurosAPI"
RUN dotnet build "TaxaJurosAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TaxaJurosAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaxaJurosAPI.dll"]