# Matchmaking Platform

This is a matchmaking platform designed for players to track their performance, wins, losses, hours played, Elo ratings, and team assignments.

## Technologies Used

- C# & .NET 9: The backend application is built using C# and .NET.
- Microsoft SQL Server: The database is powered by Microsoft SQL Server, and you can manage it using SSMS.
- AutoMapper: Used for mapping between different DTOs and models.
- Entity Framework Core: Used for database access and object-relational mapping (ORM).

## Database Setup (Code-First Approach)
The application uses Entity Framework Core with the Code-First approach for creating and managing the database schema. This means the database is generated from C# model classes, and migrations are used to update the database schema.
### Step 1: Configure the Connection String
 - Open appsettings.json in your project.
 - Ensure that the connection string points to your SQL Server instance. Example:
```charp
  {
    "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Database=MatchmakingPlatform;Trusted_Connection=True;MultipleActiveResultSets=true"
    }
  }
```
### Step 2: Add Entity Framework Core NuGet Packages
If you haven't already, install the required Entity Framework Core packages to your project using NuGet Package Manager or via the Package Manager Console.

For SQL Server, you can install the following packages:
```bash
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools
```
### Step 3: Run Migrations
Create a Migration: Open Package Manager Console in Visual Studio (Tools > NuGet Package Manager > Package Manager Console) and run the following command to create the first migration:

```bash
Add-Migration InitialCreate
```
This will generate migration files that define the database schema.

Apply the Migration to the Database: Once the migration is created, apply it to the database with:

```bash
Update-Database
```
This command will create the necessary tables in the SQL Server database based on the models you've defined.

## Building and Running the Application
### Step 1: Clone the Repository
If you haven't already, clone this repository to your local machine.

```bash
git clone https://github.com/yourusername/MatchmakingPlatform.git
```
### Step 2: Open the Solution in Visual Studio 

- Launch Visual Studio 2022.
- Open the cloned repository folder by selecting `Open a project or solution` and navigating to the solution file (`.sln`).
- Visual Studio will restore the required NuGet packages (ensure your internet connection is active).
  
### Step 3: Build the Application
- After opening the solution in Visual Studio, ensure that the project builds correctly.
- Press `Ctrl + Shift + B` or select `Build` > `Build Solution` from the menu to compile the application.
- If there are any build errors, check the Error List window for issues such as missing packages or incorrect configurations.
  
### Step 4: Run the Application
- Set the desired project as the startup project (typically the Web API or Main Application).
- Press `F5` or select `Debug` > `Start Debugging` to run the application in the Visual Studio debugger.
- If everything is configured correctly, the application will launch, and you can interact with it locally or through the specified web browser.
