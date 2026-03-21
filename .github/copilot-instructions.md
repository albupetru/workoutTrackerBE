# Workout Tracker — Backend Coding Conventions

## Project Structure

Two-project solution:
- **workoutTracker.Domain/** — Domain layer: entities, repositories, services, mappers, EF Core config, migrations
- **workoutTrackerAPI/** — Web layer: controllers, DI setup, configuration, middleware

### Domain Layer Folder Layout
```
Common/Constants/          — Static ID/value constants per entity
Common/Enums/              — All enums
DatabaseContext/            — ApplicationDbContext
DataSeeds/                 — Seed data classes (one per entity)
EntityTypeConfigurations/  — EF Core Fluent API configs (one per entity)
Extensions/                — Static extension method classes
Helpers/                   — Utility/helper classes
Mappers/                   — Mapperly mapper classes
Migrations/                — EF Core migrations (auto-generated)
Models/Application/        — Domain entities
Models/Common/             — Base classes, interfaces (BaseEntity, IAuditableEntity, ISoftDeletable)
Models/Configuration/      — Strongly-typed config models (bound from appsettings)
Repositories/Common/       — BaseRepository, IBaseRepository, UnitOfWork, IUnitOfWork
Repositories/Interface/    — Entity-specific repository interfaces
Repositories/Implementation/ — Entity-specific repository implementations
Services/Interface/        — Service contracts
Services/Implementation/   — Service implementations
ViewModels/                — DTOs for API responses/requests
```

### Web Layer Folder Layout
```
Controllers/               — API controllers
Program.cs                 — Entry point, DI, middleware pipeline
appsettings.json           — Base config
appsettings.Development.json — Dev overrides
```

## Naming Conventions

| Element | Convention | Example |
|---------|-----------|---------|
| Classes | PascalCase | `ExerciseRepository`, `UserSession` |
| Interfaces | `I` prefix + PascalCase | `IBaseRepository`, `IUserSession` |
| Enums | PascalCase, explicitly `: int` | `RoleType : int` |
| Enum members | PascalCase, explicit int values starting at 0 | `User = 0, Admin = 1` |
| Public methods/properties | PascalCase | `SaveChangesAsync()`, `Name` |
| Private fields | `_camelCase` prefix | `_dbContext`, `_userSession` |
| Local variables | camelCase | `mapper`, `exercises` |
| Async methods | `Async` suffix (on base/generic methods) | `SelectAsync()`, `SaveAsync()` |
| Files | Match class name exactly | `ExerciseController.cs` |

### Class Suffixes
- `Repository` — data access: `ExerciseRepository`
- `Service` — business logic: `GoogleLoginService`
- `Controller` — API endpoints: `ExerciseController`
- `ViewModel` — DTOs: `ExerciseViewModel`, `CreateExerciseViewModel`
- `EntityTypeConfiguration` — EF config: `ExerciseEntityTypeConfiguration`
- `Mapper` — Mapperly mappers: `ExerciseMapper`
- `Extensions` — extension methods: `DatabaseSetupExtensions`
- `DataSeed` — seed data: `ExerciseDataSeed`
- `Helper` — utilities: `SecurityKeyHelper`

## Entity Patterns

All entities extend `BaseEntity<T, TId>` with `Guid` as TId.

### Marker Interfaces
- `IAuditableEntity` — gets CreatedOn, CreatedById, ModifiedOn, ModifiedById shadow properties
- `ISoftDeletable` — gets DeletedOn, DeletedById shadow properties + global query filter

### Property Ordering
1. `[Key]` primary key (override from base)
2. Scalar properties (strings, ints, bools, enums)
3. Foreign key properties (Guid references)
4. Navigation properties (`virtual`, decorated with `[JsonIgnore]`)
5. `[NotMapped]` computed properties

### Example
```csharp
public class Exercise : BaseEntity<Exercise, Guid>, IAuditableEntity, ISoftDeletable
{
    [Key]
    public override Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    [JsonIgnore]
    public virtual ICollection<ExerciseTag> ExerciseTags { get; set; } = new List<ExerciseTag>();

    [NotMapped]
    public virtual ICollection<Tag> Tags => ExerciseTags.Select(p => p.Tag).ToList();
}
```

## EF Core Patterns

- **DbContext**: `ApplicationDbContext` with auto-applied audit fields via `SaveChanges`/`SaveChangesAsync` override
- **Shadow properties**: Audit + soft-delete fields defined in `ModelBuilderExtensions`, not on entities
- **Global query filter**: Soft-deleted entities excluded automatically
- **EntityTypeConfiguration**: One per entity, extends `BaseEntityTypeConfiguration<T, TId>`; called via `ApplyConfigurationsFromAssembly`
- **Relationships**: Fluent API in EntityTypeConfiguration (not data annotations)
- **Seed data**: Defined in `DataSeeds/` classes, applied in EntityTypeConfiguration `HasData()` using anonymous objects (to include shadow properties)
- **Migrations**: Auto-generated, timestamp-prefixed naming

## Repository & Unit of Work

- All data access through `IUnitOfWork` (injected into controllers)
- `UnitOfWork` exposes repository properties with lazy initialization: `_repo ??= new Repo(_dbContext)`
- `BaseRepository<T, TId>` provides: `SelectAsync`, `SingleAsync`, `SingleByIdAsync`, `InsertAsync`
- Multiple `SelectAsync` overloads for eager loading (Expression list, Func<IQueryable>, string list)
- Entity-specific repos extend `BaseRepository` and implement their own interface
- Save via `_unitOfWork.SaveAsync()` (not on individual repositories)

## Controller Patterns

```csharp
[ApiConventionType(typeof(DefaultApiConventions))]
[ApiController]
[Authorize]
[Route("[controller]")]
[Produces("application/json")]
public class ExerciseController
{
    private readonly IUnitOfWork _unitOfWork;
    // Constructor injection only
}
```

- Class-level `[Authorize]`, action-level `[AllowAnonymous]` to override
- Return `Task<ActionResult<T>>` or `Task<IActionResult>`
- Parameter binding: explicit `[FromQuery]`, `[FromBody]`
- Route convention: `[Route("[controller]")]` → `/exercise`, `/login`
- Mapper instantiated per action: `var mapper = new ExerciseMapper();`

## Mapping (Mapperly)

- Uses Riok.Mapperly (compile-time source generation)
- Mapper classes decorated with `[Mapper]`, partial methods auto-implemented
- Convention: `ToEntityViewModel(entity)` and `ToEntityViewModelList(list)`
- One mapper class per entity in `Mappers/` folder

## ViewModels

- Located in `ViewModels/` (flat folder)
- Generic `PaginatedEntityViewModel<T>` with `Results` and `Total`
- String properties initialized: `= string.Empty`
- No validation attributes — validation in services

## Dependency Injection

- **Scoped**: `IUserSession`, `IUnitOfWork` (per HTTP request)
- **Singleton**: Config objects (`ApplicationSecrets`, `GoogleSecrets`), stateless services (`IGoogleLoginService`)
- Constructor injection only (no service locator)
- Database registered via extension method: `builder.Services.RegisterSqliteDatabaseContext()`

## Configuration

- Strongly-typed config models in `Models/Configuration/`
- Bound from `appsettings.json` sections via `GetSection<T>()`
- Registered as singletons in DI

## Authentication

- Google OAuth → exchange code for Google JWT → decode → create/find user → issue app JWT
- JWT contains: oid (user ID), name, email claims
- Tokens validated via `Microsoft.AspNetCore.Authentication.JwtBearer`
- `IUserSession` extracts claims from `HttpContext.User` per request

## Tech Stack
- .NET 8, C# 12
- EF Core 8 with SQLite
- Mapperly for object mapping
- JWT Bearer authentication
- Google OAuth 2.0
- Swagger/OpenAPI

## Comments (important)
use comments only when the code logic + naming cannot clearly convey the intent. Avoid redundant comments that restate what the code does. Focus comments on the "why" and any non-obvious implementation details.