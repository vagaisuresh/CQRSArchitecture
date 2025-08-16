
# A Clean Architecture implementation using the CQRS pattern with MediatR in ASP.NET Core.

An implementation of **Clean Architecture** using CQRS (Command Query Responsibility Segregation) pattern and MediatR library in **ASP.NET Core**, structured to promote scalability, maintainability, and testability. This project demonstrates the separation of concerns through clearly defined layers—**Domain, Application, Infrastructure,** and **API**—and follows industry best practices such as the **Repository pattern, Unit of Work,** and **SOLID principles**, making the codebase modular and easy to extend.

---

## Features

- ✅ Clean Architecture with CQRS pattern and MediatR
- ✅ CRUD operations implemented using clean controllers
- ✅ SQL Server for data persistence
- ✅ Repository and UnitOfWork patterns for data access
- ✅ Easily extensible, maintainable, and testable codebase

---

## Tech Stack

- **ASP.NET Core Web API**
- **Entity Framework Core**
- **CQRS Pattern with MediatR**
- **IUnitOfWork & Repository Pattern**
- **SOLID Principles**
- **Blazor WebAssembly (WASM)**
- **SQL Server**

---

## Endpoints Overview

| Method | URL                         | Description                     |
|--------|-----------------------------|---------------------------------|
| GET    | /api/todos                  | List all ToDos.                 |
| GET    | /api/todos/{id}             | Get particular ToDo by ID       |
| POST   | /api/todos                  | Add new ToDo                    |
| PUT    | /api/todos/{id}             | Update existing ToDo by ID      |
| DELETE | /api/todos/{id}             | Delete an existing ToDo by ID   |
| PATCH  | /api/todos/{id}/complete    | Set as finished (done)          |

## Application Architecture

- Controllers handle HTTP requests
- Services encapsulate business logic
- Repositories manage data access per DB
- MS SQL Server database used

---

### ✅ Project Folder Structure
```
CQRSArchitecture.sln
|
├── src/
│   ├── CQRS.API/                   → ASP.NET Core Web API (Presentation layer)
│   ├── CQRS.Application/           → Business logic, use cases, CQRS
│   ├── CQRS.Domain/                → Core domain models, entities, interfaces
│   ├── CQRS.Persistence            → EF Core, DbContext, Repositories
│   ├── CQRS.Infrastructure         → Email, Files, Logging, 3rd Party APIs, external services, implementations
│   └── CQRS.Shared/                → Cross-cutting concerns, utilities, constants
|
├── tests/
│   ├── CQRS.API.Tests/             → Application & domain unit tests
│   └── CQRS.IntegrationTests/      → Integration & end-to-end API tests
|
├── ui/
│   └── CQRS.BlazorUI/              → Blazor frontend (SPA)
|
└── README.md
```

### ✅ src/CQRS.API – Presentation Layer (Web API)
```
CQRS.API/
├── Controllers/
├── Filters/
├── Middlewares/
├── DependencyInjection/
├── Program.cs
├── appsettings.json
└── CQRS.API.csproj
```

### ✅ src/CQRS.Application – Application Layer
```
CQRS.Application/
├── Interfaces/                  → Contracts for services, repos, etc.
├── DTOs/                        → Data Transfer Objects
├── Features/
│   ├── [Entity]/                → e.g., Product, User
│   │   ├── Commands/
│   │   ├── Queries/
│   │   └── Handlers/
├── Behaviors/                   → Pipeline behaviors (logging, validation)
├── Exceptions/
└── CQRS.Application.csproj
```
✅ Depends on: CQRS.Domain, CQRS.Shared


---

### ✅ src/CQRS.API – Presentation Layer (Web API)
Handles HTTP communication, routes, controllers, filters, and middleware.
```
CQRS.API/
├── Controllers/
├── Filters/
├── Middlewares/
├── DependencyInjection/
├── Program.cs
├── appsettings.json
└── CQRS.API.csproj
```

### ✅ src/CQRS.Application – Application Layer
Contains business rules, use cases, interfaces, commands/queries (CQRS).
```
CQRS.Application/
├── Interfaces/                  → Contracts for services, repos, etc.
├── DTOs/                        → Data Transfer Objects
├── Features/
│   ├── [Entity]/                → e.g., Product, User
│   │   ├── Commands/
│   │   ├── Queries/
│   │   └── Handlers/
├── Behaviors/                   → Pipeline behaviors (logging, validation)
├── Exceptions/
└── CQRS.Application.csproj
```
✅ Depends on: CQRS.Domain, CQRS.Shared

### ✅ src/CQRS.Domain – Domain Layer
Contains core business logic and models. Pure and independent.
```
CQRS.Domain/
├── Entities/
├── ValueObjects/
├── Enums/
├── Events/
├── Interfaces/                 → Domain-specific contracts (rare)
└── CQRS.Domain.csproj
```
❌ Depends on: None

### ✅ src/CQRS.Infrastructure – Infrastructure Layer
Handles persistence, external APIs, email, file storage, etc.
```
CQRS.Infrastructure/
├── Persistence/
│   ├── DbContexts/
│   ├── Migrations/
│   ├── Repositories/
│   └── Configurations/
├── Services/
├── Identity/
├── ExternalClients/
└── CQRS.Infrastructure.csproj
```
✅ Depends on: CQRS.Application, CQRS.Domain, CQRS.Shared

### ✅ src/CQRS.Shared – Cross-Cutting Concerns
Utilities and helpers used by all layers (logging, constants, mapping, etc.)
```
CQRS.Shared/
├── Extensions/
├── Helpers/
├── Constants/
├── Results/
├── Mapping/
└── CQRS.Shared.csproj
```
✅ Can be referenced by any project

### ✅ tests/ – Test Projects
tests/CQRS.UnitTests – Unit tests
```
CQRS.UnitTests/
├── Application/
├── Domain/
└── Helpers/
```
References: Application, Domain, Shared

tests/CQRS.IntegrationTests – API & DB Integration Tests
```
CQRS.IntegrationTests/
├── API/
├── Infrastructure/
└── DataSeed/
```
References: API, Infrastructure, Persistence, Shared


## 🔄 Project References & Dependency Flow
```
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
```
