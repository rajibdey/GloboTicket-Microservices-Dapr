#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["GloboTicket.Services.ShoppingBasket/GloboTicket.Services.ShoppingBasket.csproj", "GloboTicket.Services.ShoppingBasket/"]
COPY ["GloboTicket.Packages.Extensions/GloboTicket.Packages.Extensions.csproj", "GloboTicket.Packages.Extensions/"]
COPY ["GloboTicket.Services.EventCatalog/GloboTicket.Services.EventCatalog.csproj", "GloboTicket.Services.EventCatalog/"]
RUN dotnet restore "GloboTicket.Services.ShoppingBasket/GloboTicket.Services.ShoppingBasket.csproj"
COPY . .
WORKDIR "/src/GloboTicket.Services.ShoppingBasket"
RUN dotnet build "GloboTicket.Services.ShoppingBasket.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GloboTicket.Services.ShoppingBasket.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GloboTicket.Services.ShoppingBasket.dll"]
