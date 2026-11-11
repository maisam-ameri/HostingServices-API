# HostingServices API

A RESTful Web API built with ASP.NET Core, following **Onion Architecture** principles to provide a maintainable, scalable, and well-structured backend application for hosting service management.

## Overview

HostingServices API is a backend project developed using C# and ASP.NET Core Web API.

The project is designed with a focus on separation of concerns, dependency inversion, and maintainability. It follows Onion Architecture to keep the core business logic independent of external concerns such as data access and presentation.

## Architecture

The project follows **Onion Architecture**, organizing application components into separate layers with dependencies directed toward the core.

### Project Structure

| Project | Description |
|---|---|
| `Entities` | Contains the core entities and domain models. |
| `Service.Contracts` | Defines service interfaces and abstractions. |
| `Service` | Contains service implementations and business logic. |
| `Repository` | Handles data access operations. |
| `Contracts` | Contains data transfer contracts. |
| `Presentation` | Handles API presentation and HTTP-related concerns. |
| `LoggerService` | Provides logging functionality. |
| `Shared` | Contains shared components and utilities. |
| `Host_Service` | Main application and API entry point. |

### Architectural Principles

- Separation of Concerns
- Dependency Inversion
- Loose Coupling
- Abstraction through Interfaces
- Maintainable and Testable Code

## Technologies

- C#
- ASP.NET Core Web API
- .NET
- RESTful API
- Dependency Injection

## Getting Started

### Prerequisites

- .NET SDK
- Visual Studio or another compatible IDE

### Clone the Repository

```bash
git clone https://github.com/maisam-ameri/HostingServices-API.git
```

### Run the Application

1. Open the solution in Visual Studio.
2. Configure the required application settings.
3. Restore NuGet packages.
4. Build the solution.
5. Run the `Host_Service` project.

## Configuration

Configure the required application settings before running the project, including database connection strings and other environment-specific settings where applicable.

## API Endpoints

API endpoint documentation and usage examples can be added here.

## License

This project is currently not distributed under a specified open-source license.
