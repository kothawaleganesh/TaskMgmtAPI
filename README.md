
# 🧠 Task Management API – Deep Dive

A well-structured **Task Management API** built with **ASP.NET Core (.NET 9)**, using **CQRS**, **MediatR**, **Dapper**, and **Repository Pattern**. This project demonstrates enterprise-level architectural patterns ideal for scalable and testable applications.

---

## ✅ Features

- Create, fetch, update, complete, and delete tasks.
- Applies **CQRS pattern** to cleanly separate reads and writes.
- **MediatR** for command/query handling via the mediator pattern.
- **Repository abstraction** using **Dapper** with SQL Server.
- **Swagger UI** for API testing/documentation.
- **Dependency Injection** for decoupling components.
- Follows **Clean Architecture principles**.

---

## 🧱 Project Layers (Clean Architecture Inspired)

```
TaskMgmtAPI/
│
├── src/                  → Presentation Layer (Controllers)
├── Application/          → Application Layer (CQRS, Handlers)
├── DAL/                  → Data Access Layer (Repositories, Models)
├── appsettings.json      → Configuration
```

---

## 🧪 Technologies & Patterns – Detailed Notes

### 🔷 .NET 9

> ✅ .NET 9 is the latest release in the modern .NET ecosystem.

- **Unified Platform**: Single framework for cloud, mobile, desktop, IoT.
- **Cross-platform**: Runs on Windows, macOS, Linux.
- **High Performance**: AOT compilation, GC improvements, Span<T>, and async IO.
- **Modern Features**: Records, pattern matching, source generators.
- **Built-in DI & Middleware**: Eliminates need for external containers.

📚 Use case: Ideal for APIs, background services, microservices.

---

### 🔷 ASP.NET Core Web API

> 💡 ASP.NET Core enables building RESTful services using controllers or minimal APIs.

- **Routing & Endpoints**: Maps HTTP verbs to actions.
- **Model Binding & Validation**: Automatically binds and validates JSON input.
- **Filters, Middleware, Exception Handling**: Flexible pipeline.
- **Integrated Swagger**: Auto-generates OpenAPI docs.

📚 Use case: When you need scalable, secure, and testable web APIs.

---

### 🔷 CQRS (Command Query Responsibility Segregation)

> 🔃 Separates data **writes (commands)** and **reads (queries)**.

#### 🔸 Benefits:
- **Separation of concerns**: One class reads, another writes — cleaner logic.
- **Scalability**: Read/write parts can scale independently.
- **Security**: You can restrict commands but allow open queries.

#### 🧱 Example:
- `AddTaskItemCommand` → handles creation.
- `GetAllTasksQuery` → handles reading.

📚 Use case: When your read and write workloads differ in complexity or scale.

---

### 🔷 MediatR

> 📭 Implements the **mediator pattern**, removing tight coupling between controllers and logic.

#### 🔸 How it works:
- `IMediator.Send()` → sends a command/query.
- `IRequestHandler<TRequest, TResponse>` → handles it.

#### 🔸 Why MediatR?
- Makes controller "thin".
- Logic goes to handlers — single responsibility.
- Makes unit testing easier.

📚 Use case: When you need a clean way to separate logic and messaging in your application.

---

### 🔷 Repository Pattern

> 🗃️ Abstracts the database access so your business logic doesn’t care about the actual data source.

#### 🔸 Structure:
- `ITaskItemRepository`: Interface.
- `TaskItemRepository`: Concrete implementation using Dapper.

#### 🔸 Advantages:
- Decouples data access.
- Easy to mock in tests.
- Supports switch to EF Core or another DB without logic changes.

📚 Use case: Always use in non-trivial applications that interact with a DB.

---

### 🔷 Dapper

> ⚡ A micro-ORM for .NET that maps SQL results to objects.

#### 🔸 Why Dapper?
- Faster than EF Core (no change tracking).
- Direct SQL → full control over queries.
- Minimal overhead.

#### 🔸 Example:
```csharp
var sql = "SELECT * FROM TaskItems";
var result = await _connection.QueryAsync<TaskItem>(sql);
```

📚 Use case: When you want lightweight, performant DB operations and can handle your own SQL.

---

### 🔷 SQL Server

> 🧩 A powerful, enterprise-grade RDBMS.

- Supports stored procs, triggers, indexing, transactions, etc.
- Easy integration with ADO.NET/Dapper.
- Full support for constraints, relationships, normalization.

📚 Use case: Robust backend store for structured data, especially in enterprise.

---

### 🔷 Swagger (OpenAPI)

> 📘 Automatically generates UI and OpenAPI docs from your controller methods.

#### 🔸 Benefits:
- Test APIs directly from browser.
- Great for frontend/backend collaboration.
- Acts as living documentation.

#### 🔸 URL:
```
https://localhost:<port>/swagger
```

📚 Use case: Always use in public APIs or projects with frontend/backend coordination.

---

### 🔷 Dependency Injection (DI)

> 🔄 Technique to inject dependencies instead of creating them manually.

- `services.AddScoped<ITaskItemRepository, TaskItemRepository>();`
- Reduces coupling, simplifies testing.
- Native in .NET Core (`Microsoft.Extensions.DependencyInjection`).

📚 Use case: Every service-based or multi-layered project.

---

### 🔷 Configuration with appsettings.json

> ⚙️ Central place for environment-specific settings.

- `ConnectionStrings:DefaultConnection`
- Use `IConfiguration` to access these values in services.

📚 Use case: Use for DB strings, secrets (ideally via user-secrets in dev).

---

### 🔷 Microsoft.Data.SqlClient

> 🎯 Official SQL Server ADO.NET provider.

- Used by Dapper to create connection objects.
- Optimized for high-throughput SQL Server access.

---

## 📬 API Endpoints – Sample

| HTTP | Endpoint         | Description         |
|------|------------------|---------------------|
| GET  | `/GetAllTasks`   | List all tasks      |
| POST | `/CreateTask`    | Create a task       |
| PUT  | `/CompleteTask`  | Mark task completed |
| DELETE | `/DeleteTask` | Remove a task       |

---

## 🛠️ How to Run

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- SQL Server (Express or LocalDB)

### Steps

1. Clone this repo:
   ```bash
   git clone https://github.com/kothawaleganesh/TaskMgmtAPI.git
   cd TaskMgmtAPI
   ```

2. Set up DB connection in `appsettings.json`:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=.;Database=TaskDb;Trusted_Connection=True;"
   }
   ```

3. Build and run the API:
   ```bash
   dotnet build
   dotnet run
   ```

4. Visit Swagger:
   ```
   https://localhost:<port>/swagger
   ```

---

## 📄 License

This project is licensed under the **MIT License**.

---

## 🤝 Contributions

Have an idea, bug fix, or enhancement? Open an issue or pull request!

---

## 🔗 Repository

[🔗 GitHub - TaskMgmtAPI](https://github.com/kothawaleganesh/TaskMgmtAPI)
