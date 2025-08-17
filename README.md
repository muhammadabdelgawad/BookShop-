# BookShop-

## Description

This ASP.NET Core MVC application provides a basic platform for managing and displaying books in a shop.  It includes features for CRUD operations on categories and products, utilizing Entity Framework Core for data access with a SQL Server database.

## Features and Functionality

*   **Category Management:**
    *   Create, Read, Update, and Delete (CRUD) operations for categories.
    *   Display a list of all categories.
    *   View details of a specific category.

*   **Product Management:**
    *   Create, Read, Update, and Delete (CRUD) operations for products.
    *   Products are associated with a specific category.
    *   Display a list of all products with their associated category.

## Technology Stack

*   **ASP.NET Core MVC:**  Framework for building the web application.
*   **Entity Framework Core (EF Core):** Object-Relational Mapper (ORM) for interacting with the SQL Server database.
*   **SQL Server:**  Database for storing category and product information.
*   **Data Access Layer:** Utilizes a Unit of Work pattern and generic repositories for data access abstraction.
*   **Bootstrap:** CSS framework for styling the user interface.
*   **jQuery:** JavaScript library for DOM manipulation and AJAX calls
*   **jQuery Validation Unobtrusive:** Used for Client side validation.

## Prerequisites

Before running the application, ensure you have the following installed:

*   **.NET SDK (8.0 or higher):**  Download from [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download)
*   **SQL Server:**  A local or remote SQL Server instance.  SQL Server Express is a free option.
*   **Visual Studio or VS Code (optional):**  An IDE for development (recommended).

## Installation Instructions

1.  **Clone the Repository:**

    ```bash
    git clone https://github.com/muhammadabdelgawad/BookShop-
    cd BookShop-
    ```

2.  **Update Database Connection String:**

    *   Open the `BookShop/Program.cs` file.
    *   Locate the `AddDbContext` configuration within the `Main` method.
    *   Modify the `builder.Configuration.GetConnectionString("DefaultConnection")` part to reflect your SQL Server connection string.

    ```csharp
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
    ```

    Example connection string:

    ```
    "DefaultConnection": "Server=your_server;Database=BookShopDB;Trusted_Connection=True;TrustServerCertificate=True"
    ```

    Replace `your_server` with your SQL Server instance name, and `BookShopDB` with the desired database name.  Ensure the SQL Server instance is running. If you are using localdb:  "Server=(localdb)\mssqllocaldb;Database=BookShopDB;Trusted_Connection=True;MultipleActiveResultSets=true"

3.  **Apply Migrations:**

    Open a terminal in the `Data Access` directory and run the following commands to create the database and tables:

    ```bash
    dotnet ef database update
    ```

    This will create the database based on the models defined in the project. If you encounter issues, ensure that the Entity Framework Core tools are installed globally or locally:

    ```bash
    dotnet tool install --global dotnet-ef  # If you don't have it already
    dotnet add package Microsoft.EntityFrameworkCore.Tools
    ```

4.  **Build and Run the Application:**

    Navigate to the `BookShop` directory in the terminal and run the following command:

    ```bash
    dotnet run
    ```

    The application will start, and you can access it through your web browser at the address specified in the console output (usually `https://localhost:xxxx`).

## Usage Guide

*   **Accessing the Application:**

    Open your web browser and navigate to the address where the application is running (e.g., `https://localhost:5001`).

*   **Category Management:**

    *   Navigate to the Category section (e.g. `/Category/Index`).
    *   Use the "Create Category" button to add new categories.
    *   Edit and Delete actions are available in the category list.
    *   Clicking the 'Details' buttons will display details of that category.

*   **Product Management:**

    *   Navigate to the Product section (e.g., `/Product/Index`).
    *   Use the "Create Product" button to add new products. When creating a product, you'll be prompted to select a category from a dropdown list populated from the database.
    *   Edit and Delete actions are available in the product list.
    *   Clicking the 'Details' buttons will display details of that product.

## API Documentation

There is no explicit API documentation provided as this project is mainly an MVC application. However, the controllers (`CategoryController.cs`, `ProductController.cs`, and `HomeController.cs`) define the endpoints and actions available.

## Contributing Guidelines

Contributions are welcome! To contribute to this project:

1.  Fork the repository.
2.  Create a new branch for your feature or bug fix.
3.  Implement your changes.
4.  Test your changes thoroughly.
5.  Submit a pull request with a clear description of your changes.

## License Information

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

```
MIT License

Copyright (c) 2024 muhammadabdelgawad

