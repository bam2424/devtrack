# Use the official .NET 8.0 SDK image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set working directory
WORKDIR /app

# Copy project file and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Use the official .NET 8.0 runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0

# Set working directory
WORKDIR /app

# Copy the build output
COPY --from=build /app/out .

# Create directory for SQLite database
RUN mkdir -p /app/Data

# Set environment variables
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=http://0.0.0.0:$PORT

# Expose port (Railway will set this)
EXPOSE $PORT

# Run the application
ENTRYPOINT ["dotnet", "DevTrack.dll"] 