# SalesApp

**SalesApp** is a .NET 8 (C#) ASP.NET Core Web API solution for managing sales, products, cart, payments, and authentication.

## Solution Structure

```
SalesApp.sln
├── SalesApp.API        # ASP.NET Core Web API (presentation layer)
├── SalesApp.lib        # Shared class library (DTOs, services, exceptions, validations)
└── SalesApp.db         # Data access layer (Entity Framework Core, SQL Server)
```

## Technology Stack

- **Framework**: .NET 8, ASP.NET Core
- **Database**: SQL Server with Entity Framework Core 8
- **API Documentation**: Swagger / OpenAPI (Swashbuckle)
- **Logging**: Serilog (Console + File)
- **Validation**: FluentValidation
- **Mapping**: AutoMapper
- **Payments**: Stripe.net
- **Authentication**: JWT (AddAuthentication/AddAuthorization)

## Projects

### SalesApp.API
- Controllers: `Authentication`, `Cart`, `Categories`, `Payments`, `Products`
- CORS configured for `https://localhost:8085`
- Middleware: Serilog request logging, custom DB middleware

### SalesApp.lib
- DTOs, Services, Exceptions, Validations
- Shared business logic

### SalesApp.db
- Entity Framework Core 8 with SQL Server
- Entities, Contexts, Repositories, Migrations
- Serilog integration

## Getting Started

### Prerequisites
- .NET 8 SDK
- SQL Server (LocalDB or full instance)

### Run
```bash
dotnet restore
dotnet build
dotnet run --project SalesApp.API
```

Swagger UI available at `https://localhost:<port>/swagger` in Development.

## Configuration

Key settings in `SalesApp.API/appsettings.json`:
- Connection strings (SQL Server)
- Stripe: `SecretKey`
- CORS origins
- Serilog sinks

## Recent Features
- Authentication & authorization (JWT)
- Shopping cart management
- Stripe payment integration
- Product & category CRUD
- Exception handling middleware
- Structured logging (Serilog)