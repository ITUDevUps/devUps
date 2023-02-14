

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_HTTP_PORT=https://*:3006
ENV ASPNETCORE_URLS=http://*:3005
COPY . .
WORKDIR "/src/."
RUN dotnet restore "minitwit-backend.API\minitwit-backend.API.csproj" 
RUN dotnet build "minitwit-backend.API\minitwit-backend.API.csproj" -c Release -o /app





FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal
WORKDIR /app
COPY --from=build /app .

#Copy database from datafolder to already have some data to display
COPY ./minitwit-backend.API/Data/minitwit.db/ /app/Data/
EXPOSE 3005
EXPOSE 3006
ENTRYPOINT ["dotnet", "minitwit-backend.dll"]
