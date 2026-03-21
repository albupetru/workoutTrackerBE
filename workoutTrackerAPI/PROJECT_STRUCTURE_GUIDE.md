# .NET API Project Structure Guide

This guide documents the architectural principles and structure used in this workout tracker API project, suitable for building clean, maintainable .NET 8 Web APIs.

## Table of Contents
- [Overview](#overview)
- [Solution Structure](#solution-structure)
- [Project Organization](#project-organization)
- [Key Architectural Principles](#key-architectural-principles)
- [Detailed Layer Breakdown](#detailed-layer-breakdown)
- [Design Patterns](#design-patterns)
- [Implementation Guidelines](#implementation-guidelines)
- [Best Practices](#best-practices)

---

## Overview

This project follows a **two-layer architecture** with clear separation of concerns:
1. **WebAPI Layer** - HTTP entry point, controllers, and API configuration
2. **Domain Layer** - Business logic, data access, models, and shared utilities

**Target Framework:** .NET 8  
**Database:** SQLite with Entity Framework Core  
**Authentication:** JWT Bearer Token with Google OAuth integration  

---

## Solution Structure

```
YourSolution/
??? YourProject.WebAPI/              # API/Presentation Layer
?   ??? Controllers/                 # API Controllers
?   ??? Program.cs                   # Application entry point & DI configuration
?   ??? appsettings.json            # Configuration files
?   ??? appsettings.Development.json
?
??? YourProject.Domain/              # Domain/Data Layer
    ??? Common/                      # Shared constants and enums
    ?   ??? Constants/              # Application constants
    ?   ??? Enums/                  # Enumeration types
    ??? DatabaseContext/            # EF Core DbContext
    ??? DataSeeds/                  # Database seed data
    ??? EntityTypeConfigurations/   # Fluent API configurations
    ??? Extensions/                 # Extension methods
    ??? Helpers/                    # Helper/utility classes
    ??? Mappers/                    # Object mapping (using Mapperly)
    ??? Migrations/                 # EF Core migrations
    ??? Models/                     # Domain models
    ?   ??? Application/           # Business domain entities
    ?   ??? Common/                # Base entities and interfaces
    ?   ??? Configuration/         # Configuration models
    ??? Repositories/               # Data access layer
    ?   ??? Common/                # Base repository & UnitOfWork
    ?   ??? Interface/             # Repository interfaces
    ?   ??? Implementation/        # Repository implementations
    ??? Services/                   # Business services
    ?   ??? Interface/             # Service interfaces
    ?   ??? Implementation/        # Service implementations
    ??? ViewModels/                 # Data transfer objects (DTOs)
```

---

## Project Organization

### YourProject.WebAPI (Web API Layer)

**Purpose:** HTTP interface, routing, authentication/authorization, and dependency injection setup.

**Key Files:**
- `Program.cs` - Application bootstrapping, service registration, middleware pipeline
- `Controllers/` - Thin controllers that delegate to repositories/services

**Dependencies:**
```xml
<PackageReference Include="Microsoft.AspNetCore.Authentication.JwtBearer" />
<PackageReference Include="Microsoft.AspNetCore.Authentication.Google" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" />
<PackageReference Include="Swashbuckle.AspNetCore" />
```

**Project Reference:**
```xml
<ProjectReference Include="..\YourProject.Domain\YourProject.Domain.csproj" />
```

### YourProject.Domain (Domain Layer)

**Purpose:** Business logic, data models, data access, and reusable utilities.

**Key Features:**
- Entity Framework Core configuration
- Repository pattern with Unit of Work
- Shadow properties for auditing
- Soft delete functionality
- Object mapping with Mapperly

**Dependencies:**
```xml
<PackageReference Include="Microsoft.EntityFrameworkCore" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" />
<PackageReference Include="Riok.Mapperly" />
<PackageReference Include="System.IdentityModel.Tokens.Jwt" />
```

---

## Key Architectural Principles

### 1. **Separation of Concerns**
- Web layer handles HTTP concerns only
- Domain layer contains all business logic and data access
- Clear boundaries between layers

### 2. **Repository Pattern**
- Abstract data access behind repository interfaces
- Generic base repository for common operations
- Specific repositories for entity-specific logic
- Unit of Work pattern to manage transactions

### 3. **Generic Base Entities**
- All entities inherit from `BaseEntity<T, TId>`
- Support for different ID types (Guid, int, etc.)
- Built-in equality comparison and transient detection

### 4. **Shadow Properties**
- Auditing fields (CreatedOn, ModifiedOn, CreatedById, ModifiedById)
- Soft delete fields (DeletedOn, DeletedById)
- Managed through EF Core shadow properties (not on entity classes)

### 5. **Marker Interfaces**
- `IAuditableEntity` - Entities requiring audit tracking
- `ISoftDeletable` - Entities supporting soft delete
- `IBaseEntity<T, TId>` - Base entity contract

### 6. **Dependency Injection**
- All services and repositories registered in DI container
- Interface-based dependencies
- Scoped lifetime for repositories and services

---

## Detailed Layer Breakdown

### Models

#### Base Entity Pattern
```csharp
public abstract class BaseEntity<T, TId> : IBaseEntity<T, TId>
    where T : BaseEntity<T, TId>
{
    public virtual TId Id { get; set; }
    public virtual bool IsTransient() => EqualityComparer<TId>.Default.Equals(Id, default(TId));
    // Equality and hashing implementation
}
```

#### Application Entities
```csharp
public class Exercise : BaseEntity<Exercise, Guid>, IAuditableEntity, ISoftDeletable
{
    public override Guid Id { get; set; }
    public string Name { get; set; }
    // Navigation properties
    public virtual ICollection<ExerciseTag> ExerciseTags { get; set; }
}
```

#### Marker Interfaces
```csharp
public interface IAuditableEntity { }  // Enables automatic audit tracking
public interface ISoftDeletable { }    // Enables soft delete
```

### Repositories

#### Generic Base Repository
- `IBaseRepository<T, TId>` - Defines CRUD operations
- `BaseRepository<T, TId>` - Implements common data access patterns
- Methods: `SelectAsync`, `SingleAsync`, `SingleByIdAsync`, `InsertAsync`
- Support for eager loading with Include
- Support for ordering and filtering

#### Entity-Specific Repositories
```csharp
public interface IExerciseRepository : IBaseRepository<Exercise, Guid>
{
    // Add entity-specific methods here
}

public class ExerciseRepository : BaseRepository<Exercise, Guid>, IExerciseRepository
{
    public ExerciseRepository(ApplicationDbContext context) : base(context) { }
    // Implement custom methods
}
```

#### Unit of Work Pattern
```csharp
public interface IUnitOfWork
{
    int Save();
    Task<int> SaveAsync();
    IUserRepository UserRepository { get; }
    IExerciseRepository ExerciseRepository { get; }
}
```

**Benefits:**
- Single transaction boundary
- Lazy initialization of repositories
- Coordinated save operations

### Database Context

```csharp
public class ApplicationDbContext : DbContext
{
    private readonly IUserSession _userSession;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Configure shadow properties for auditing and soft delete
        modelBuilder.ConfigureShadowProperties();
        
        // Global query filter for soft delete
        modelBuilder.ExcludeSoftDeletedEntitiesGlobally();
        
        // Apply all entity configurations
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserEntityTypeConfiguration).Assembly);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        // Automatically apply audit info before saving
        ChangeTracker.ApplyAuditInfoToChanges(_userSession);
        return base.SaveChangesAsync(cancellationToken);
    }
}
```

### Entity Type Configurations

```csharp
public abstract class BaseEntityTypeConfiguration<TBase, TId> : IEntityTypeConfiguration<TBase>
    where TBase : BaseEntity<TBase, TId>
{
    public virtual void Configure(EntityTypeBuilder<TBase> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(c => c.Id);
    }
}

// Example specific configuration
public class ExerciseEntityTypeConfiguration : BaseEntityTypeConfiguration<Exercise, Guid>
{
    public override void Configure(EntityTypeBuilder<Exercise> builder)
    {
        base.Configure(builder);
        // Add specific configurations
    }
}
```

### Extensions

#### Database Setup Extension
```csharp
public static void RegisterSqliteDatabaseContext(this IServiceCollection services, string connectionString)
{
    services.AddDbContext<ApplicationDbContext>((provider, options) =>
    {
        options.UseSqlite(connectionString);
        options.EnableSensitiveDataLogging();
    });
}
```

#### Change Tracker Extension
- Automatically sets audit fields on entity changes
- Handles soft delete by converting delete operations to updates
- Integrates with `IUserSession` for user tracking

#### Model Builder Extensions
- `ConfigureShadowProperties()` - Sets up shadow properties
- `ExcludeSoftDeletedEntitiesGlobally()` - Applies soft delete query filters
- Uses reflection to apply configurations dynamically

### Mappers

Using **Riok.Mapperly** for compile-time mapping (faster than AutoMapper):

```csharp
[Mapper]
public partial class ExerciseMapper
{
    public partial ExerciseViewModel ToExerciseViewModel(Exercise exercise);
    public partial IList<ExerciseViewModel> ToExerciseViewModelList(IList<Exercise> exercises);
}
```

**Benefits:**
- Compile-time code generation
- No runtime reflection
- Type-safe mapping
- Superior performance

### Services

```csharp
public interface IGoogleLoginService
{
    Task<GoogleAccessTokenResponse> GetToken(string code);
}

public class GoogleLoginService : IGoogleLoginService
{
    private readonly GoogleSecrets _googleSecrets;
    
    public GoogleLoginService(GoogleSecrets googleSecrets)
    {
        _googleSecrets = googleSecrets;
    }
    // Implementation
}
```

### ViewModels (DTOs)

```csharp
public class ExerciseViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<TagViewModel> Tags { get; set; }
}

public class PaginatedEntityViewModel<T>
{
    public IList<T> Results { get; set; }
    public int Total { get; set; }
}
```

### Controllers

```csharp
[ApiConventionType(typeof(DefaultApiConventions))]
[ApiController]
[Authorize]
[Route("[controller]")]
[Produces("application/json")]
public class ExerciseController
{
    private readonly IUnitOfWork _unitOfWork;

    public ExerciseController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedEntityViewModel<ExerciseViewModel>>> Get(
        [FromQuery] string? keyword = null)
    {
        var mapper = new ExerciseMapper();
        var exercises = await _unitOfWork.ExerciseRepository
            .SelectAsync(
                x => string.IsNullOrEmpty(keyword) || x.Name.StartsWith(keyword),
                x => x.Name,
                query => query.Include(x => x.ExerciseTags).ThenInclude(x => x.Tag));

        return new PaginatedEntityViewModel<ExerciseViewModel>
        {
            Results = mapper.ToExerciseViewModelList(exercises),
            Total = exercises.Count
        };
    }
}
```

---

## Design Patterns

### 1. Repository Pattern
**Purpose:** Abstract data access logic  
**Implementation:** Generic `BaseRepository<T, TId>` with entity-specific repositories  
**Benefits:** Testability, maintainability, separation of concerns

### 2. Unit of Work Pattern
**Purpose:** Manage transactions and coordinate repository operations  
**Implementation:** `UnitOfWork` class that provides repository instances  
**Benefits:** Single save point, transaction management

### 3. Generic Programming
**Purpose:** Reusable code for entities with different ID types  
**Implementation:** `BaseEntity<T, TId>`, `BaseRepository<T, TId>`  
**Benefits:** Type safety, code reuse, flexibility

### 4. Dependency Injection
**Purpose:** Loose coupling and testability  
**Implementation:** Constructor injection throughout  
**Benefits:** Testability, flexibility, maintainability

### 5. Shadow Properties Pattern
**Purpose:** Keep auditing metadata out of domain models  
**Implementation:** EF Core shadow properties for audit fields  
**Benefits:** Clean domain models, automatic tracking

### 6. Query Filter Pattern
**Purpose:** Automatically exclude soft-deleted records  
**Implementation:** Global query filters in `OnModelCreating`  
**Benefits:** Consistent behavior, no manual filtering needed

### 7. Extension Method Pattern
**Purpose:** Extend framework/library functionality  
**Implementation:** Static extension classes  
**Benefits:** Cleaner code, better organization

---

## Implementation Guidelines

### Adding a New Entity

1. **Create the Model** (in `Models/Application/`)
```csharp
public class YourEntity : BaseEntity<YourEntity, Guid>, IAuditableEntity, ISoftDeletable
{
    public override Guid Id { get; set; }
    public string Name { get; set; }
    // Add properties
}
```

2. **Create Entity Type Configuration** (in `EntityTypeConfigurations/`)
```csharp
public class YourEntityTypeConfiguration : BaseEntityTypeConfiguration<YourEntity, Guid>
{
    public override void Configure(EntityTypeBuilder<YourEntity> builder)
    {
        base.Configure(builder);
        // Configure relationships, constraints, etc.
    }
}
```

3. **Create Repository Interface** (in `Repositories/Interface/`)
```csharp
public interface IYourEntityRepository : IBaseRepository<YourEntity, Guid>
{
    // Add custom methods
}
```

4. **Implement Repository** (in `Repositories/Implementation/`)
```csharp
public class YourEntityRepository : BaseRepository<YourEntity, Guid>, IYourEntityRepository
{
    public YourEntityRepository(ApplicationDbContext context) : base(context) { }
    // Implement custom methods
}
```

5. **Add to Unit of Work**
```csharp
// In IUnitOfWork
IYourEntityRepository YourEntityRepository { get; }

// In UnitOfWork
private IYourEntityRepository _yourEntityRepository;
public IYourEntityRepository YourEntityRepository
{
    get => _yourEntityRepository ??= new YourEntityRepository(_dbContext);
}
```

6. **Create ViewModel** (in `ViewModels/`)
```csharp
public class YourEntityViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
```

7. **Create Mapper** (in `Mappers/`)
```csharp
[Mapper]
public partial class YourEntityMapper
{
    public partial YourEntityViewModel ToViewModel(YourEntity entity);
    public partial IList<YourEntityViewModel> ToViewModelList(IList<YourEntity> entities);
}
```

8. **Create Controller** (in `WebAPI/Controllers/`)
```csharp
[ApiController]
[Authorize]
[Route("[controller]")]
public class YourEntityController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    
    public YourEntityController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    // Add actions
}
```

9. **Add Migration**
```bash
dotnet ef migrations add AddYourEntity --project YourProject.Domain --startup-project YourProject.WebAPI
dotnet ef database update --project YourProject.Domain --startup-project YourProject.WebAPI
```

### Adding a New Service

1. **Create Interface** (in `Services/Interface/`)
```csharp
public interface IYourService
{
    Task<Result> DoSomething(Parameters params);
}
```

2. **Implement Service** (in `Services/Implementation/`)
```csharp
public class YourService : IYourService
{
    private readonly IUnitOfWork _unitOfWork;
    
    public YourService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Result> DoSomething(Parameters params)
    {
        // Implementation
    }
}
```

3. **Register in DI** (in `Program.cs`)
```csharp
builder.Services.AddScoped<IYourService, YourService>();
```

### Configuration Management

1. **Create Configuration Model** (in `Models/Configuration/`)
```csharp
public class YourSettings
{
    public string SomeSetting { get; set; }
}
```

2. **Add to appsettings.json**
```json
{
  "YourSettings": {
    "SomeSetting": "value"
  }
}
```

3. **Register in Program.cs**
```csharp
var yourSettings = builder.Configuration.GetSection<YourSettings>("YourSettings");
builder.Services.AddSingleton(yourSettings);
```

---

## Best Practices

### 1. Naming Conventions
- **Interfaces:** Prefix with `I` (e.g., `IUserRepository`)
- **Implementations:** Match interface name without `I` (e.g., `UserRepository`)
- **ViewModels:** Suffix with `ViewModel` (e.g., `ExerciseViewModel`)
- **Constants:** Use static classes with const fields
- **Private fields:** Use `_camelCase` prefix (e.g., `_unitOfWork`)

### 2. Async/Await
- Use `async`/`await` for all I/O operations
- Suffix async methods with `Async` (e.g., `SelectAsync`)
- Avoid blocking calls (`.Result`, `.Wait()`)

### 3. Dependency Injection
- Use constructor injection
- Depend on interfaces, not concrete types
- Register services with appropriate lifetime (Scoped, Transient, Singleton)

### 4. Error Handling
- Use try-catch in controllers
- Return appropriate HTTP status codes
- Use `IActionResult` for flexible responses
- Consider creating custom exception types

### 5. Authentication & Authorization
- Use `[Authorize]` at controller level by default
- Use `[AllowAnonymous]` for public endpoints
- Leverage JWT claims for user context

### 6. API Design
- Use RESTful conventions
- Use route attributes for clarity: `[Route("[controller]")]`
- Use HTTP verb attributes: `[HttpGet]`, `[HttpPost]`, etc.
- Return `ActionResult<T>` for typed responses

### 7. Database Best Practices
- Use migrations for schema changes
- Always include navigation properties for relationships
- Use eager loading (`Include`) when you know you need related data
- Use async methods for database operations
- Leverage query filters for soft delete

### 8. Testing Considerations
- Repository pattern enables easy mocking
- Keep controllers thin for easier testing
- Use in-memory database for integration tests
- Mock external services (like Google Login)

### 9. Security
- Never commit secrets to source control
- Use User Secrets for local development
- Use environment variables or Azure Key Vault in production
- Validate all user input
- Use parameterized queries (EF Core does this automatically)

### 10. Performance
- Use `IQueryable` projections where possible
- Avoid N+1 queries (use `Include` or `ThenInclude`)
- Consider pagination for large datasets
- Use Mapperly instead of AutoMapper for better performance
- Enable response caching where appropriate

---

## Configuration Example

### Program.cs Structure
```csharp
var builder = WebApplication.CreateBuilder(args);

// 1. Configure services from appsettings
var sqlDbSettings = builder.Configuration.GetSection<SQLDatabaseSettings>("SQLDatabaseSettings");
var applicationSecrets = builder.Configuration.GetSection<ApplicationSecrets>("ApplicationSecrets");

// 2. Register DbContext
builder.Services.RegisterSqliteDatabaseContext(sqlDbSettings.ConnectionString);

// 3. Register configuration objects
builder.Services.AddSingleton(applicationSecrets);

// 4. Register repositories and services
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserSession, UserSession>();

// 5. Configure CORS
builder.Services.AddCors(options => /* configure */);

// 6. Configure Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => /* configure */);

// 7. Add controllers and Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 8. Configure middleware pipeline
app.UseCors();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
```

---

## Summary

This architecture provides:
- ? Clean separation of concerns
- ? Testable code through dependency injection
- ? Reusable generic base classes
- ? Automatic audit tracking via shadow properties
- ? Soft delete functionality
- ? Type-safe object mapping
- ? RESTful API design
- ? JWT authentication with Google OAuth
- ? Entity Framework Core with migrations
- ? SOLID principles adherence

The structure scales well for small to medium-sized applications and can be extended with additional patterns (CQRS, MediatR, etc.) as needed for larger systems.
