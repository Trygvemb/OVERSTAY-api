# OVERSTAY

## Project Overview
OVERSTAY is a .NET-based application built with .NET 9.0 and C# 13.0, utilizing ASP.NET Core.

## Prerequisites
- Docker
- .NET 9.0 SDK

## Database Configuration
The project uses Microsoft SQL Server with Full-Text Search capabilities, running in a Docker container. The database configuration is managed through Docker Compose.

### Docker Compose Configuration
The `docker-compose.yml` file sets up the following:

- **SQL Server Container**:
  - Image: `vibs2006/sql_server_fts:latest`
  - Container Name: `mssql_server`
  - Port: `1433` (mapped to host)
  - Persistent data storage using named volume: `mssql_data`

### Starting the Database
To start the database, run:
```bash
docker-compose up -d
```

### Database Connection
- Server: `localhost,1433`
- Username: `sa`
- Password: `Password123!`

## Getting Started
1. Ensure you have all prerequisites installed
2. Clone the repository
3. Start the database using Docker Compose
4. Build and run the application

## Development Environment
- IDE: JetBrains Rider 2025.1 EAP 9
- Framework: .NET 9.0
- Language: C# 13.0
- Technologies: ASP.NET Core, Razor
