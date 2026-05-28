FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY Fact.sln .
COPY Fact.Api/Fact.Api.csproj Fact.Api/
COPY Fact.Core/Fact.Core.csproj Fact.Core/
COPY Fact.Tests/Fact.Tests.csproj Fact.Tests/
RUN dotnet restore
COPY . .
RUN dotnet publish Fact.Api -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
COPY certs/test-cert.pfx certs/
EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5000
ENV ASPNETCORE_ENVIRONMENT=Development
ENV Certificate__Path=certs/test-cert.pfx
ENTRYPOINT ["dotnet", "Fact.Api.dll"]
