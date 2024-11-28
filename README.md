# Matchmaking Platform

This is a matchmaking platform designed for players to track their performance, wins, losses, hours played, Elo ratings, and team assignments.

## Technologies Used

- C# & .NET 9: The backend application is built using C# and .NET.
- In Memory Database
- AutoMapper: Used for mapping between different DTOs and models.
- Entity Framework Core: Used for database access and object-relational mapping (ORM).

## Database Setup 

For Database Setup, you can install the following packages:
```bash
Install-Package Microsoft.EntityFrameworkCore.InMemory
Install-Package Microsoft.EntityFrameworkCore
Install-Package Microsoft.EntityFrameworkCore.Tools
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
