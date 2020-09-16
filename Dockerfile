# Build env
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /var/api
COPY ./Api/Api.csproj ./Api/Api.csproj
RUN dotnet restore Api/Api.csproj
COPY ./Api ./Api
RUN dotnet publish Api/Api.csproj -c Release -o /var/api/output

# Runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS run-env
WORKDIR /srv/api
COPY --from=build-env /var/api/output ./
COPY ./docker-entrypoint.sh ./docker-entrypoint.sh
RUN chmod +x ./docker-entrypoint.sh
ENTRYPOINT ["sh", "-c", "./docker-entrypoint.sh"]
