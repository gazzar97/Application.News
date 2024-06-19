# Simple News Application
## Introduction

Welcome to **News App**! This is a simple web application built using .NET Core 8. It follows the Clean Architecture principles to ensure a scalable, maintainable, and testable codebase. The application serves as a robust starting point for building modern web applications with a clear separation of concerns.

## Table of Contents

1. [Project Overview](#project-overview)
2. [Technologies Used](#technologies-used)
3. [Architecture](#architecture)
4. [Installation](#installation)
5. [Configuration](#configuration)
6. [Running the Tests](#running-the-tests)
7. [Usage](#usage)

## Project Overview

**News App** is a web application designed to fetch data from the NewsAPI external provider based on category names and display the news on different pages according to each category. The application offers users an organized and user-friendly way to browse news articles sorted by categories, ensuring a seamless and informative experience. It is built with modern web technologies and follows industry best practices for software architecture. The primary goal of this project is to provide a robust foundation for developing scalable and maintainable web applications.

## Technologies Used

- **.NET Core 8**: The latest version of the .NET framework, used for building the application.
- **EF Core 8**: Entity Framework Core 8, an ORM framework for .NET, used for data access.
- **Microsoft SQL Server**: The database management system used to store application data.
- **NUnit**: A unit-testing framework for all .NET languages, used for writing and running tests.
- **RestSharp**: A simple REST and HTTP API client for .NET, used for calling external APIs.
- **Code First Approach**: A development approach where the database schema is created from the code.

## Architecture

The application is built following the Clean Architecture principles, which aim to achieve separation of concerns and make the system easier to maintain and test. Clean Architecture organizes the project into several layers, each with a specific responsibility:

- **Presentation Layer**: Handles the UI/UX and user interactions.
- **Application Layer**: Contains use cases and business logic.
- **Domain Layer**: Encapsulates core business entities and rules.
- **Infrastructure Layer**: Manages data access, external APIs, and other infrastructure concerns.

By enforcing clear boundaries between these layers, Clean Architecture ensures that changes in one part of the system have minimal impact on others. This makes the codebase more adaptable to changing requirements and easier to understand and test.

# Installation

To set up and run **News App**, follow these steps:

1. **Build Solution**:
   - Open the solution in Visual Studio.
   - Build the solution to restore dependencies and compile the code.

2. **Set Startup Project**:
   - Navigate to the **Presentation** folder.
   - Set the **Application.Client** project as the startup project.

3. **Configure Database**:
   - Open **appsettings.json** in the **Application.Client** project.
   - Update the server name in the connection string to match your SQL Server instance.

4. **Run Migrations**:
   - Open **Package Manager Console** in Visual Studio (`Tools -> NuGet Package Manager -> Package Manager Console`).
   - Ensure **Application.DAL** is selected as the default project in the console.
   - Run the following commands to create and apply the initial database migration:
     ```
     add-migration init
     update-database
     ```

These steps will initialize the project, configure the database connection, and apply the necessary migrations to set up the database schema.

# Configuration

To configure **News App**, follow these steps:

1. **Locate the Project**:
   - Find the project named **Application.NewsAPI** in your solution.

2. **Copy Configuration Files**:
   - In the **Application.NewsAPI** project, locate the following file:
     - `newssetting.development.json`
     
   - Right-click on each file and select **Properties**.
   - In the **Properties** window, set the **Copy to Output Directory** option to **Copy if newer** and then rebuild the project.

These steps ensure that the necessary configuration files are copied to the output directory, allowing the application to access and use them during runtime.

# Running the Tests

To run integration tests for **News App**, follow these steps:

1. **Locate the Tests Folder**:
   - Find the **Tests** folder in your solution.

2. **Expand the Tests Project**:
   - Expand the project named **Application.NewsAPI.Tests** within the **Tests** folder.

3. **Run Tests**:
   - Right-click on the **Application.NewsAPI.Tests** project name.
   - Select **Run Tests** from the context menu to execute all tests.
   - Alternatively, you can open **Test Explorer** in Visual Studio (`View tab -> Test Explorer`) and run individual test cases as needed.

These steps will execute the integration tests for the application, ensuring that all functionalities are working correctly in a simulated environment.

# Usage

To use **News App**, follow these steps:

1. **Rebuild the Solution**:
   - Open the solution in Visual Studio.
   - Build the solution to ensure all dependencies are resolved and the code is compiled.

2. **Set Startup Project**:
   - Navigate to the **Presentation** folder.
   - Set the **Application.Client** project as the default startup project.

3. **Start the Application**:
   - Start the project by pressing the **Start** button (green play button) in Visual Studio.
   - Once the application is running, navigate between pages to observe the output and functionality.

These steps will allow you to start and interact with **News App** effectively, exploring its features and user interface.

