# Movie API README

## Overview

This project is an API for managing movie watchlists. It allows users to add movies to their watchlist, mark movies as watched, retrieve movies from their watchlist, and search for movies by name. The application is built using the following technologies:

- **ASP.NET Core Web API**: Provides the backend infrastructure for handling HTTP requests and responses.
- **MediatR**: Used for implementing the Mediator pattern to decouple request handling logic.
- **Entity Framework Core (EF Core)**: Manages data access and database interactions.
- **MS SQL Server**: Serves as the database for storing movie-related data.
- **Code-First Approach**: The database schema is generated from code models.
- **Migrations and Fluent API**: Used for managing database schema changes.
- **Swagger**: Provides an interactive API documentation interface.

## Prerequisites

Before you start, ensure that you have the following installed:

1. **Visual Studio 2022 Preview**: You can download it from [here](https://visualstudio.microsoft.com/vs/preview/).
2. **.NET 8 SDK**: Install it from [.NET SDK Downloads](https://dotnet.microsoft.com/download/dotnet/8.0).

## Getting Started

Follow these steps to set up and run the project:

1. **Clone the Repository**:
   ```bash
   git clone <repository_url>
   cd MovieApi
   
2. **Database Configuration:**

Update the connection string in appsettings.json to point to your MS SQL Server instance.

Run the following commands in the Package Manager Console to create the initial database migration:

## Overview

This project is an API for managing movie watchlists. It allows users to add movies to their watchlist, mark movies as watched, retrieve movies from their watchlist, and search for movies by name. The application is built using the following technologies:

- **ASP.NET Core Web API**: Provides the backend infrastructure for handling HTTP requests and responses.
- **MediatR**: Used for implementing the Mediator pattern to decouple request handling logic.
- **Entity Framework Core (EF Core)**: Manages data access and database interactions.
- **MS SQL Server**: Serves as the database for storing movie-related data.
- **Code-First Approach**: The database schema is generated from code models.
- **Migrations and Fluent API**: Used for managing database schema changes.
- **Swagger**: Provides an interactive API documentation interface.
