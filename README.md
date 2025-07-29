# Task Management API

This project is a simple Task Management API built with ASP.NET Core (.NET 9), using the CQRS (Command Query Responsibility Segregation) and Repository patterns. It demonstrates clean separation of concerns, maintainability, and testability.

---

## Features

- Create, retrieve, complete, and delete task items.
- Uses MediatR for CQRS implementation.
- Repository pattern for data access abstraction.
- Dapper for lightweight data access.
- Swagger/OpenAPI documentation.

---

## Technologies, Libraries, and Patterns Used

### .NET 9
- **Modern, cross-platform framework for building high-performance applications.**
- Used as the foundation for the API, providing performance, security, and scalability.

### ASP.NET Core Web API
- **Framework for building RESTful HTTP services.**
- Used for controllers, routing, model binding, validation, and dependency injection.

### CQRS (Command Query Responsibility Segregation)
- **Separates read (query) and write (command) operations.**
- Improves maintainability, scalability, and testability.
- **Commands:** Classes like `AddTaskItemCommand` represent state-changing actions.
- **Queries:** Classes like `GetAllTasksQuery` represent data retrieval.
- **Handlers:** Each command/query has a handler (e.g., `AddTaskItemCommandHandler`) with business logic.
- **MediatR:** Dispatches commands/queries to handlers, decoupling controllers from business logic.

### MediatR
- **In-process messaging library for .NET.**
- Implements the mediator pattern, decoupling senders from receivers.
- Used to send commands/queries from controllers to handlers.

### Repository Pattern
- **Abstraction layer for data access.**
- Promotes loose coupling, testability, and flexibility.
- **ITaskItemRepository:** Interface for CRUD operations.
- **TaskItemRepository:** Implementation using Dapper and SQL Server.

### Dapper
- **Lightweight, high-performance micro-ORM for .NET.**
- Used for executing SQL queries and mapping results to C# objects.

### SQL Server
- **Relational database management system.**
- Stores task data persistently.

### Swagger / OpenAPI
- **API documentation and testing tools.**
- Generates interactive documentation for easy testing and sharing.

### Dependency Injection
- **Technique for loose coupling and testability.**
- Services like `ITaskItemRepository` and `IMediator` are registered and injected where needed.

### Microsoft.Extensions.Configuration
- **Configuration framework for .NET apps.**
- Reads connection strings and settings from `appsettings.json`.

### Microsoft.Data.SqlClient
- **Official SQL Server data provider for .NET.**
- Enables Dapper to connect and execute queries.

---

## Project Structure

- **src/**: ASP.NET Core Web API project (controllers, startup).
- **Application/**: Application layer (CQRS commands, queries, handlers).
- **DAL/**: Data access layer (repositories, data models).

---

## Example API Endpoints

- `GET /GetAllTasks` - Retrieve all tasks.
- `POST /CreateTask` - Create a new task.

---

## How to Run

1. Ensure you have .NET 9 SDK installed.
2. Configure your connection string in `appsettings.json` under `DefaultConnection`.
3. Build and run the solution.
4. Access Swagger UI at `https://localhost:<port>/swagger` for API documentation and testing.

---

## Summary Table

| Technology/Pattern         | Purpose/Role in Project                                                                 |
|----------------------------|----------------------------------------------------------------------------------------|
| .NET 9                     | Application framework                                                                 |
| ASP.NET Core Web API       | RESTful API development                                                               |
| CQRS                       | Separation of read/write logic                                                        |
| MediatR                    | In-process messaging, decoupling controllers from handlers                            |
| Repository Pattern         | Data access abstraction                                                               |
| Dapper                     | Lightweight data access                                                               |
| SQL Server                 | Persistent data storage                                                               |
| Swagger/OpenAPI            | API documentation and testing                                                         |
| Dependency Injection       | Loose coupling and testability                                                        |
| Microsoft.Extensions.Configuration | Configuration management                                                      |
| Microsoft.Data.SqlClient   | SQL Server connectivity                                                               |

---

## License

MIT License
