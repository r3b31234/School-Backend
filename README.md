# School System – Backend API

A RESTful Web API for managing student information, enrollments, and grades.

The project is built with **.NET 10** following **Clean Architecture** principles and uses **Entity Framework Core** with **SQL Server**.

---

# 🚀 Tech Stack

| Component | Technology |
|-----------|------------|
| Framework | .NET 10 |
| ORM | Entity Framework Core 10.0.8 |
| Database | SQL Server |
| Architecture | Clean Architecture |

---

#  Project Structure

```text
Solution
│
├── WebApi/          # Entry point of the API (Controllers, Startup, Configuration)
│
└── AccesoDatos/     # Entity Framework DbContext, Models and Data Access
```

### WebApi
Contains:

- API Controllers
- Dependency Injection configuration
- Middleware
- Application startup

### AccesoDatos
Contains:

- Entity Framework Core DbContext
- Entity Models
- Database access logic

The models were generated from an existing SQL Server database using the **Database First** approach.

---

#  Prerequisites

Before running the project, make sure you have:

- .NET 10 SDK
- SQL Server
- SQL Server Management Studio (optional)

---

# Getting Started

## 1. Clone the repository

```bash
git clone <repository-url>
cd <repository-folder>
```

---

## 2. Configure the database

Update the connection string inside:

```
appsettings.json
```

or

```
appsettings.Development.json
```

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=SERVER_NAME;Database=DATABASE_NAME;User Id=USERNAME;Password=PASSWORD;TrustServerCertificate=True;"
  }
}
```

---

## 3. Restore dependencies

```bash
dotnet restore
```

---

## 4. Database

This project follows a **Database First** approach.

The database schema must already exist before running the application.

If you need to regenerate the Entity Framework models:

```bash
dotnet ef dbcontext scaffold "Server=SERVER_NAME;Database=DATABASE_NAME;..." Microsoft.EntityFrameworkCore.SqlServer -o Models --force
```

---

## 5. Run the application

```bash
cd WebApi
dotnet run
```

The API will be available at:

```
http://localhost:5168
```

---

#  Authentication

The API uses **Basic Authentication** through the following endpoint:

```
POST /Autentication
```

---

# API Endpoints

| Method | Endpoint | Description |
|---------|----------|-------------|
| GET | `/AlumnosProfesor` | Get students assigned to a professor |
| POST | `/Autentication` | Authenticate a user |
| GET | `/Prueba` | Test endpoint |
| GET | `/BuscarAlumno` | Search for a student |
| PUT | `/ActualizarAlumno` | Update student information |
| POST | `/MatricularAlumno` | Enroll a student |
| DELETE | `/BorrarAlumno` | Delete a student |
| GET | `/BuscarCalificaciones` | Get student grades |
| POST | `/AgregarCalificacion` | Add a grade |
| DELETE | `/DeleteCalificaion` | Delete a grade |

---

#  Testing

If test projects are added in the future, run:

```bash
dotnet test
```

---

# Deployment

Deployment instructions can be added depending on the target environment:

- IIS
- Docker
- Azure App Service
- CI/CD Pipeline

---

# Contributing

Contributions are welcome.

1. Fork the repository.
2. Create a feature branch.
3. Commit your changes.
4. Open a Pull Request.

---

# Notes

- Built with **.NET 10**
- Uses **Entity Framework Core**
- SQL Server Database
- Database First approach
- Clean Architecture
