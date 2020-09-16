# Prime Finder 
A not-so-simple example of prime finder ASP.NET Core Web API

## Requirements
1. .NET Core SDK 3.1
2. Docker

## Getting started
1. Run build: `dotnet build`
2. Run tests with coverage report: `dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=lcov /p:CoverletOutput=./lcov`
3. Run the app with watch: `dotnet watch -p Api/Api.csproj run`

## Features
- Swagger API documentation at `https://localhost:5001/api/docs`
- API versioning
- CQRS with MediatR
- Health endpoint at `https://localhost:5001/health`

## Tests
- Against Math utility with a list of proven prime numbers
- For controllers
- For command/query handlers
- Test coverage with Coverlet

## Deploy
- Build image: `docker build . -t prime.finder:v1.0`
- Run in Docker Compose: `docker-compose up`
- Run in Production: `docker-compose -f docker-compose.yml -f docker-compose.production.yml up` 
