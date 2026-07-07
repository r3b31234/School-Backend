School System – Backend API

A Web API for managing and querying student grading data (students, enrollments, and grades). Built with .NET, following Clean Architecture principles.

Tech Stack

ComponentTechnologyFramework.NET 10ORMEntity Framework Core 10.0.8DatabaseSQL ServerArchitectureClean Architecture

Project Structure

The solution is composed of two projects:

Solution/
├── WebApi/          # Entry point of the Web API (hosts controllers/endpoints)
└── AccesoDatos/         # Domain models and Entity Framework Core data access


WebApi: The host project. Contains the API controllers and application startup/configuration.
AccesoDatos: Contains the EF Core DbContext, entity models, and data access logic. Models were scaffolded from an existing database (Database First approach).



Note: If more layers exist (e.g., separate Application/Domain/Infrastructure projects), update this section to reflect the actual project breakdown.



Prerequisites


.NET 10 SDK
SQL Server (local instance, Docker container, or remote instance)
A tool to manage the database (SQL Server Management Studio)


Getting Started

1. Clone the repository

bashgit clone <repository-url>
cd <repository-folder>

2. Configure the database connection

Update the connection string in appsettings.json (or appsettings.Development.json) inside the ConsoleApp project:

json{
  "ConnectionStrings": {
    "DefaultConnection": "Server=<your-server>;Database=<your-database>;User Id=<user>;Password=<password>;TrustServerCertificate=True;"
  }
}


TODO: Confirm the exact connection string key name and format used in the project.



3. Restore dependencies

bashdotnet restore

4. Database setup

The database models were generated from an existing database (Database First / scaffolding), so no EF Core migrations are used to create the schema. Make sure the target SQL Server database already contains the expected schema before running the API.

If the schema ever needs to be re-scaffolded from the database, run:

bashdotnet ef dbcontext scaffold "Server=<your-server>;Database=<your-database>;..." Microsoft.EntityFrameworkCore.SqlServer -o Models --force


TODO: Confirm the exact scaffold command/parameters used for this project (output folder, context name, etc.).



5. Run the project

bashcd ConsoleApp
dotnet run

The API will be available at:

http://localhost:5168

Authentication

The API uses Basic Authentication via the Autentication endpoint.


TODO: Document the exact request/response format for this endpoint (headers, credentials format, token/session handling if any).



API Endpoints

MethodEndpointDescriptionGET/AlumnosProfesorGet students by professorPOST/AutenticationAuthenticate a userGET/PruebaTest/health-check endpointGET/BuscarAlumnoSearch for a studentPUT/ActualizarAlumnoUpdate a student's informationPOST/MatricularAlumnoEnroll a studentDEL/BorrarAlumnoDelete a studentGET/BuscarCalificacionesSearch for gradesPOST/AgregarCalificacionAdd a gradeDEL/DeleteCalificaionDelete a grade


TODO: Add request/response examples (body, query params, status codes) for each endpoint. If Swagger/OpenAPI is enabled, link to it here instead (e.g., http://localhost:5168/swagger).



Testing


TODO: Add instructions here if the project includes unit/integration tests (test project name, how to run them, e.g. dotnet test).



Deployment


TODO: Document how this project is deployed (CI/CD pipeline, IIS, Docker, Azure App Service, etc.).



Contributing


TODO: Add branching strategy, PR guidelines, or coding conventions if applicable.
