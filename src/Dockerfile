FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Easypeasy.Api/Easypeasy.Api.csproj", "Easypeasy.Api/"]
RUN dotnet restore "Easypeasy.Api/Easypeasy.Api.csproj"
COPY . .
WORKDIR "/src/Easypeasy.Api"
RUN dotnet build "Easypeasy.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Easypeasy.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Easypeasy.Api.dll"]