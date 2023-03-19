FROM python:3

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

RUN set -xe \
    && apt-get update -y \
    && apt-get install -y python3-pip
# RUN pip install --no-cache-dir -r requirements.txt

EXPOSE 3005
EXPOSE 3006
ENTRYPOINT ["dotnet", "minitwit-backend.API.dll"]
