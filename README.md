# Learning Management System API

A RESTful backend for an online learning platform, built with **ASP.NET Core 9 Web API** following **Clean Architecture** principles.

## Overview

This API supports the core workflow of an online course platform: course and lesson management, student enrollment, quizzes with questions, and submissions — all secured with JWT authentication and ASP.NET Core Identity, with Redis caching for performance.

## Tech Stack

- **Framework:** ASP.NET Core 9 Web API
- **Database:** SQL Server + Entity Framework Core 9
- **Auth:** ASP.NET Core Identity + JWT Bearer authentication
- **Caching:** Redis (StackExchange.Redis)
- **Mapping:** AutoMapper
- **Validation:** FluentValidation
- **Email:** SendGrid
- **Docs:** Swagger / Swashbuckle

## Architecture

The solution follows Clean Architecture with clear separation of concerns:

```
Learning Management System/
├── API/              # Controllers, DI extensions
├── Application/       # Business logic / services, DTOs
├── Core/               # Entities, interfaces, enums, custom exceptions
└── Infrastructure/     # EF Core DbContext, repositories, caching, persistence
```

- **Core** — domain entities and repository interfaces, no external dependencies.
- **Application** — business logic implemented against the Core interfaces.
- **Infrastructure** — EF Core data access, caching, and SQL Server persistence.
- **API** — controllers and DI wiring that expose HTTP endpoints.

## Features

- **Authentication & Accounts** — registration, login, password reset/change, forgot password, claims-based checks
- **Courses** — full CRUD with lookup by ID or name
- **Categories** — full CRUD with lookup by ID or name
- **Lessons** — full CRUD per course, with lookup by ID or name
- **Enrollment** — enroll students in courses, update/track enrollment status, lookup by student
- **Quizzes & Questions** — full CRUD for quizzes and their questions
- **Submissions** — students submit quiz answers, with retrieval and updates
- **User Profiles** — self-service profile updates and admin user management
- **Caching** — Redis-backed caching layer for performance
- **API Docs** — interactive Swagger UI with JWT bearer support built in

## Core Entities

`Course`, `Category`, `Lessons`, `Enrollment`, `Quiz`, `Question`, `Submission`, `User`, `Role`

## API Endpoints

| Controller | Sample Endpoints |
|---|---|
| **Account** | `POST /Register`, `POST /login`, `POST /changePassword`, `POST /ForgotPassword`, `POST /ResetPassword` |
| **Course** | `GET`, `GET /{id}`, `GET /Name/{Name}`, `POST`, `PUT /{id}`, `DELETE /{id}` |
| **Category** | `GET`, `GET /ById/{id}`, `GET /ByName/{Name}`, `POST`, `PUT /{id}`, `DELETE /{id}` |
| **Lesson** | `GET`, `GET /GetById/{id}`, `GET /GetByName/{Name}`, `POST`, `PUT /{id}`, `DELETE /{id}` |
| **Enrollment** | `GET`, `GET /{id}`, `GET /{studentId}`, `POST`, `PUT /{id}`, `DELETE /{id}` |
| **Quiz** | `GET`, `GET /GetById/{id}`, `GET /GetByName/{Name}`, `POST`, `PUT /{id}`, `DELETE /{id}` |
| **Question** | `GET`, `GET /{id}`, `POST`, `PUT /{id}`, `DELETE /{id}` |
| **Submission** | `GET`, `GET /{id}`, `POST`, `PUT /{id}`, `DELETE /{id}` |
| **User** | `GET /ById/{id}`, `GET /ByName/{Name}`, `PUT /Profile`, `PUT /{id}` |

Full request/response contracts are available via Swagger UI once the API is running.

## Getting Started

### Prerequisites
- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- SQL Server (LocalDB or full instance)
- Redis server (local or hosted)

### Setup

1. **Clone the repository**
   ```bash
   git clone git@github.com:Mostafaragab22/Learning-Management-System.git
   cd Learning-Management-System
   ```

2. **Configure `appsettings.json`**

   Add your connection string, Redis, and JWT settings:
   ```json
   {
     "ConnectionStrings": {
       "cs": "Server=YOUR_SERVER;Database=LearningManagementDb;Trusted_Connection=True;TrustServerCertificate=True",
       "Redis": "localhost:6379"
     },
     "JWT": {
       "Issuer": "your-issuer",
       "Audience": "your-audience",
       "SecretKey": "your-secret-key"
     }
   }
   ```

3. **Apply migrations**
   ```bash
   dotnet ef database update
   ```

4. **Run the API**
   ```bash
   dotnet run
   ```

5. **Explore the API**
   Open `https://localhost:{port}/swagger` to view and test all endpoints. Use the **Authorize** button with a `Bearer {token}` from `/login` to access protected routes.

## Author

**Mostafa Ragab**
Full Stack .NET Developer
[GitHub](https://github.com/Mostafaragab22) • [LinkedIn](https://www.linkedin.com/in/mostafa-ragab-846a09386)

