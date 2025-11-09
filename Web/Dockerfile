# build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ./backendSchoolMe.sln ./
COPY ./Business/Business.csproj ./Business/
COPY ./Data/Data.csproj ./Data/
COPY ./Entity/Entity.csproj ./Entity/
COPY ./Utilities/Utilities.csproj ./Utilities/
COPY ./Web/Web.csproj ./Web/
RUN dotnet restore ./Web/Web.csproj

COPY . .
WORKDIR /src/Web
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 7000
ENV ASPNETCORE_URLS=http://+:7000
ENV DB_ENGINE=Postgres
ENTRYPOINT ["dotnet", "Web.dll"]
