# CQRSArchitecture
CQRS and MediatR in ASP.NET Core

MyEnterpriseApp.sln
|
├── src/
│   ├── MyApp.API/                → ASP.NET Core Web API (Presentation layer)
│   ├── MyApp.Application/        → Business logic, use cases, CQRS
│   ├── MyApp.Domain/             → Core domain models, entities, interfaces
│   ├── MyApp.Persistence         → EF Core, DbContext, Repositories
│   ├── MyApp.Infrastructure      → Email, Files, Logging, 3rd Party APIs, external services, implementations
│   └── MyApp.Shared/             → Cross-cutting concerns, utilities, constants
|
├── tests/
│   ├── MyApp.UnitTests/          → Application & domain unit tests
│   └── MyApp.IntegrationTests/   → Integration & end-to-end API tests
|
└── README.md

# ✅ src/MyApp.API – Presentation Layer (Web API)

MyApp.API/
├── Controllers/
├── Filters/
├── Middlewares/
├── DependencyInjection/
├── Program.cs
├── appsettings.json
└── MyApp.API.csproj

# ✅ src/MyApp.Application – Application Layer

MyApp.Application/
├── Interfaces/                  → Contracts for services, repos, etc.
├── DTOs/                        → Data Transfer Objects
├── Features/
│   ├── [Entity]/                → e.g., Product, User
│   │   ├── Commands/
│   │   ├── Queries/
│   │   └── Handlers/
├── Behaviors/                   → Pipeline behaviors (logging, validation)
├── Exceptions/
└── MyApp.Application.csproj

✅ Depends on: MyApp.Domain, MyApp.Shared


---

# ✅ src/MyApp.API – Presentation Layer (Web API)
Handles HTTP communication, routes, controllers, filters, and middleware.

MyApp.API/
├── Controllers/
├── Filters/
├── Middlewares/
├── DependencyInjection/
├── Program.cs
├── appsettings.json
└── MyApp.API.csproj

# ✅ src/MyApp.Application – Application Layer
Contains business rules, use cases, interfaces, commands/queries (CQRS).

MyApp.Application/
├── Interfaces/                  → Contracts for services, repos, etc.
├── DTOs/                        → Data Transfer Objects
├── Features/
│   ├── [Entity]/                → e.g., Product, User
│   │   ├── Commands/
│   │   ├── Queries/
│   │   └── Handlers/
├── Behaviors/                   → Pipeline behaviors (logging, validation)
├── Exceptions/
└── MyApp.Application.csproj
✅ Depends on: MyApp.Domain, MyApp.Shared

# ✅ src/MyApp.Domain – Domain Layer
Contains core business logic and models. Pure and independent.

MyApp.Domain/
├── Entities/
├── ValueObjects/
├── Enums/
├── Events/
├── Interfaces/                 → Domain-specific contracts (rare)
└── MyApp.Domain.csproj
❌ Depends on: None

# ✅ src/MyApp.Infrastructure – Infrastructure Layer
Handles persistence, external APIs, email, file storage, etc.

MyApp.Infrastructure/
├── Persistence/
│   ├── DbContexts/
│   ├── Migrations/
│   ├── Repositories/
│   └── Configurations/
├── Services/
├── Identity/
├── ExternalClients/
└── MyApp.Infrastructure.csproj
✅ Depends on: MyApp.Application, MyApp.Domain, MyApp.Shared

# ✅ src/MyApp.Shared – Cross-Cutting Concerns
Utilities and helpers used by all layers (logging, constants, mapping, etc.)

MyApp.Shared/
├── Extensions/
├── Helpers/
├── Constants/
├── Results/
├── Mapping/
└── MyApp.Shared.csproj
✅ Can be referenced by any project

# ✅ tests/ – Test Projects
tests/MyApp.UnitTests – Unit tests

MyApp.UnitTests/
├── Application/
├── Domain/
└── Helpers/
References: Application, Domain, Shared

tests/MyApp.IntegrationTests – API & DB Integration Tests

MyApp.IntegrationTests/
├── API/
├── Infrastructure/
└── DataSeed/
References: API, Infrastructure, Persistence, Shared


# 🔄 Project References & Dependency Flow

API
├── references → Application, Infrastructure, Shared
Application
├── references → Domain, Shared
Infrastructure
├── references → Application, Domain, Shared
Domain
├── no references
Shared
├── no references


# 🧰 Libraries & Tools (Common in Enterprise Clean Arch)
Concern	                Library
CQRS	                MediatR
Validation	            FluentValidation
Mapping	                AutoMapper
ORM	                    EF Core
Unit Testing	        xUnit, Moq, FluentAssertions
Integration Testing	    WebApplicationFactory, TestContainers
Logging	                Serilog, Seq
API Versioning	        Microsoft.AspNetCore.Mvc.Versioning
Swagger	                Swashbuckle.AspNetCore
Security/Auth	        ASP.NET Identity, JWT Bearer Auth