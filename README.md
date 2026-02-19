# Task Tracking API

Backend API for an agile sprint planning board — manage teams, sprints, and tasks with role-based access control.

Built with **.NET 8**, **Clean Architecture**, **CQRS** (MediatR), **SQL Server**, **Redis**, and **JWT authentication**.

## Tech Stack

| Component | Technology |
|-----------|------------|
| Runtime | .NET 8.0 |
| Database | SQL Server 2022 |
| Caching | Redis 7 |
| ORM | Entity Framework Core 8 (Code First) |
| Auth | JWT Bearer (HS256) |
| CQRS | MediatR 14 |
| Validation | FluentValidation 12 |
| API Docs | Swagger / OpenAPI 3 |
| Containers | Docker Compose |

## Architecture

Clean Architecture with 4 independent projects:

```
IntakerTest.sln
├── TaskTrackingSystem.Domain/          # Entities, enums, exceptions (zero dependencies)
├── TaskTrackingSystem.Application/     # Commands, queries, DTOs, validators
├── TaskTrackingSystem.Infrastructure/  # EF Core, Redis, JWT, repositories
└── TaskTrackingSystem.API/             # Controllers, middleware, Swagger, DI root
```

Dependency flow: **API** -> Application + Infrastructure -> **Application** -> **Domain**

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [EF Core CLI tools](https://learn.microsoft.com/en-us/ef/core/cli/dotnet): `dotnet tool install --global dotnet-ef`

**For local development (without Docker):**
- SQL Server (local instance or SQL Server Express)
- Redis server

**For Docker development:**
- [Docker Desktop](https://www.docker.com/products/docker-desktop/)

## Getting Started

### Option 1: Docker Compose (Recommended)

Everything runs in containers — no local SQL Server or Redis needed.

**1. Start all services:**

```bash
docker-compose -p intaker-test up --build -d
```

This starts 3 containers on a shared `tasktracking-network` bridge network:

| Service | Host Port | Internal Hostname | Description |
|---------|-----------|-------------------|-------------|
| API | `5080` (HTTP), `5081` (HTTPS) | `tasktrackingsystem.api` | .NET 8 Web API |
| SQL Server | `1437` | `tasktrackingsystem.sqlserver` | SQL Server 2022 |
| Redis | `6380` | `tasktrackingsystem.redis` | Redis 7 (Alpine) |

Services communicate internally via hostnames (e.g., the API connects to `tasktrackingsystem.sqlserver:1433`).

**2. Open Swagger UI:**

```
http://localhost:5080/swagger
```

**Stop services:**

```bash
docker-compose -p intaker-test up down
```

To also remove persisted data (database + cache):

```bash
docker-compose -p intaker-test up down -v
```

---

### Option 2: Local Development

Run the API directly on your machine with local SQL Server and Redis.

**1. Verify prerequisites are running:**
- SQL Server on `localhost`
- Redis on `localhost:6379`

**2. Update connection strings** (if needed) in `TaskTrackingSystem.API/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=TaskTrackingDb;Trusted_Connection=true;TrustServerCertificate=true;",
    "Redis": "localhost:6379"
  }
}
```

**3. Run the API:**

```bash
dotnet run --project TaskTrackingSystem.API
```

**4. Open Swagger UI** at the URL shown in the console output (e.g., `https://localhost:7xxx/swagger`).

## Authentication

The API uses JWT Bearer tokens. Two roles exist: **Admin** and **Member**.

### Quick Start Flow

**1. Register a user:**

```http
POST /api/auth/register
Content-Type: application/json

{
  "email": "admin@example.com",
  "password": "P@ssw0rd123",
  "firstName": "John",
  "lastName": "Doe",
  "role": "Admin"
}
```

**2. Login to get a JWT token:**

```http
POST /api/auth/login
Content-Type: application/json

{
  "email": "admin@example.com",
  "password": "P@ssw0rd123"
}
```

Response:

```json
{
  "token": "eyJhbGciOiJIUzI1NiIs...",
  "userId": "...",
  "email": "admin@example.com",
  "role": "Admin"
}
```

**3. Use the token** in the `Authorization` header for all protected endpoints:

```
Authorization: Bearer eyJhbGciOiJIUzI1NiIs...
```

In Swagger UI, click the **Authorize** button and enter: `Bearer <your-token>`.

### Roles

| Role | Access |
|------|--------|
| **Admin** | All resources across all teams. Can create teams, manage members, and view all users. |
| **Member** | Own team's resources only. Sprints, tasks, and members scoped to their assigned team. |

## API Endpoints

| Method | Route | Auth | Description |
|--------|-------|------|-------------|
| `POST` | `/api/auth/register` | No | Register a new user |
| `POST` | `/api/auth/login` | No | Login, returns JWT token |
| `GET` | `/api/teams` | Yes | List teams (Admin: all, Member: own) |
| `POST` | `/api/teams` | Admin | Create a new team |
| `GET` | `/api/teams/{teamId}/members` | Yes | List team members |
| `POST` | `/api/teams/{teamId}/members` | Admin | Add a member to a team by email |
| `GET` | `/api/sprints` | Yes | List sprints (Admin: all, Member: own team) |
| `POST` | `/api/sprints` | Yes | Create a sprint (Admin must provide teamId) |
| `PUT` | `/api/sprints/{id}` | Yes | Update sprint name and dates |
| `GET` | `/api/sprints/{id}/board` | Yes | Get Kanban board (ToDo / InProgress / Done) |
| `POST` | `/api/tasks` | Yes | Create a task in a sprint |
| `GET` | `/api/tasks/{id}` | Yes | Get task details |
| `PUT` | `/api/tasks/{id}` | Yes | Update task title, description, assignee |
| `PATCH` | `/api/tasks/{id}/status` | Yes | Update task status (drag-and-drop) |
| `DELETE` | `/api/tasks/{id}` | Yes | Delete a task |
| `GET` | `/api/users` | Admin | List all users in the system |

### Task Status Values

| Value | Name | Description |
|-------|------|-------------|
| `0` | ToDo | Not started |
| `1` | InProgress | Work in progress |
| `2` | Done | Completed |

## Project Structure

```
IntakerTest.sln
│
├── TaskTrackingSystem.Domain/
│   ├── Entities/            User, Team, Sprint, SprintTask
│   ├── Enums/               TeamRole (Admin/Member), SprintTaskStatus (ToDo/InProgress/Done)
│   ├── Common/              BaseEntity (Id, CreatedAtUtc, UpdatedAtUtc)
│   ├── Exceptions/          DomainException
│   └── Repositories/        IUserRepository, ITeamRepository, ISprintRepository, ISprintTaskRepository, IUnitOfWork
│
├── TaskTrackingSystem.Application/
│   ├── Common/
│   │   ├── Interfaces/      ICacheService, ICurrentUserService, IJwtTokenService, IPasswordHasher
│   │   ├── Behaviors/       ValidationBehavior, LoggingBehavior (MediatR pipeline)
│   │   ├── Exceptions/      ValidationException, NotFoundException
│   │   └── CacheKeys.cs     Cache key generators
│   ├── Features/
│   │   ├── Auth/            Register, Login (commands + handlers + validators)
│   │   ├── Teams/           CreateTeam, AddTeamMember, GetTeams, GetTeamMembers
│   │   ├── Sprints/         CreateSprint, UpdateSprint, GetSprints, GetSprintBoard
│   │   ├── Tasks/           CreateTask, UpdateTask, UpdateTaskStatus, DeleteTask, GetTaskById
│   │   └── Users/           GetUsers (Admin only)
│   └── DependencyInjection.cs
│
├── TaskTrackingSystem.Infrastructure/
│   ├── Persistence/
│   │   ├── ApplicationDbContext.cs
│   │   ├── Configurations/  Fluent API entity configs
│   │   ├── Interceptors/    AuditableEntityInterceptor (auto-sets timestamps)
│   │   ├── Repositories/    Repository implementations
│   │   └── Migrations/      EF Core migrations
│   ├── Services/            JwtTokenService, PasswordHasher, CurrentUserService, CacheService
│   └── DependencyInjection.cs
│
├── TaskTrackingSystem.API/
│   ├── Controllers/         AuthController, TeamsController, SprintsController, TasksController, UsersController
│   ├── Middleware/           ExceptionHandlingMiddleware
│   └── Program.cs           Composition root
│
├── docker-compose.yml       API + SQL Server + Redis
└── TaskTrackingSystem.API/Dockerfile   Multi-stage build
```

## Configuration

### appsettings.json

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=TaskTrackingDb;Trusted_Connection=true;TrustServerCertificate=true;",
    "Redis": "localhost:6379"
  },
  "Jwt": {
    "Key": "YourSuperSecretKeyThatIsAtLeast32CharactersLong!",
    "Issuer": "TaskTrackingSystem",
    "Audience": "TaskTrackingSystem",
    "ExpirationInHours": 24
  }
}
```

### Docker Environment Overrides

When running via Docker Compose, connection strings are overridden through environment variables (no code changes needed). Service names resolve via the `tasktracking-network` bridge network:

| Setting | Docker Value |
|---------|-------------|
| `ConnectionStrings:DefaultConnection` | `Server=tasktrackingsystem.sqlserver;Database=TaskTrackingDb;User Id=sa;Password=YourStrong!Passw0rd2024;TrustServerCertificate=true;` |
| `ConnectionStrings:Redis` | `tasktrackingsystem.redis:6379` |

### Error Response Format

All errors follow a consistent JSON structure:

```json
{
  "message": "Error description",
  "errors": {
    "FieldName": ["Validation error message"]
  }
}
```

| HTTP Status | Cause |
|-------------|-------|
| `400` | Validation error (FluentValidation) |
| `401` | Missing or invalid JWT token |
| `403` | Insufficient role permissions |
| `404` | Resource not found |
| `409` | Conflict (e.g., duplicate email) |
| `500` | Unhandled server error |
