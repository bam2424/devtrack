# Use the official .NET 8.0 SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set working directory
WORKDIR /src

# Copy project file first for better layer caching
COPY ["DevTrack.csproj", "."]
RUN dotnet restore "DevTrack.csproj"

# Copy everything else
COPY . .

# Build and publish
WORKDIR "/src"
RUN dotnet build "DevTrack.csproj" -c Release -o /app/build
RUN dotnet publish "DevTrack.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Use the official .NET 8.0 runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

# Set working directory
WORKDIR /app

# Copy the published app
COPY --from=build /app/publish .

# Create directory for SQLite database with proper permissions
RUN mkdir -p /app/Data && chmod 755 /app/Data

# Set environment variables
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=http://0.0.0.0:${PORT:-8080}

# Expose the port (use 8080 as default, Railway will override with PORT env var)
EXPOSE ${PORT:-8080}

# Run the application
ENTRYPOINT ["dotnet", "DevTrack.dll"] 