# SchoolWeb.API

SchoolWeb.API is a .NET 6.0 Web API application that provides a platform for managing school-related data. It follows the principles of REST and uses SQL Server as its data store.

## ToDo
- ** This has to be moved to a secret store like Azure Key Vaults.
- ** Refresh JWT Token so as the user does not have to authenticate after every time the JWT token expires(30 minutes currently).
- ** Blacklist JWT Token so as the token becomes invalid as soon as the user logs off.

## Features

- **Student Management**: The API provides endpoints for creating, retrieving, updating, and deleting student records.
- **Course Management**: The API provides endpoints for managing course information.
- **Grade Management**: The API provides endpoints for managing student grades for different courses.

## Technologies

- **.NET 6.0**: The latest version of .NET, used for building the API.
- **Entity Framework Core**: The ORM used for data access.
- **SQL Server**: The database used for storing data.
- **Swagger**: Used for API documentation and testing.

## Project Structure

The project follows a clean architecture with a separation of concerns:

- **Controllers**: Handle incoming HTTP requests and return HTTP responses.
- **Services**: Contain the business logic of the application.
- **Repositories**: Handle data access, using Entity Framework Core to interact with the database.
- **Models**: Represent the data entities in the application.

## Setup

1. **Prerequisites**: Make sure you have .NET 6.0 SDK and SQL Server installed on your machine.
2. **Clone the repository**: `git clone https://github.com/nandhakishore92/SchoolWeb.API`
3. **Change to the directory**: `cd school-api`
4. **Update the connection string**: Update the connection string in `appsettings.json` to point to your SQL Server instance.
5. **Run the application**: `dotnet run`

Once the application is running, you can navigate to `https://localhost:5001/swagger` to view the API documentation and test the endpoints.