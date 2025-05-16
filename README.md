📊 Sales Summary API

This project is a minimal .NET 8 Web API that reads from a sales.json file and provides simple analytics and sorting capabilities via HTTP endpoints. It uses Minimal APIs, Swagger for documentation, and is structured with a clean services-based architecture.
🚀 Features

    ✅ Get Sales Summary: Total sales, average order, best-selling product.

    📦 Order Sales by Product Name

    📈 Order Sales by Quantity

    📄 Swagger UI for testing endpoints.

    🧩 Built with Dependency Injection and Minimal APIs.

📁 Project Structure

├── Program.cs                # Entry point and endpoint mapping
├── Infra/
│   ├── Services/
│   │   ├── Interfaces/
│   │   │   └── IProductService.cs
│   │   └── Classes/
│   │       └── ProductService.cs
│   ├── Models/
│   │   └── SaleEntity.cs
│   └── Dto/
│       └── SalesSummaryDto.cs
├── sales.json               # JSON file with sales data

🛠️ Endpoints

All endpoints are GET methods:
Route	Description
/GetSalesSummary	Returns total sales, average, best product
/OrderByProductname	Returns sales ordered by product name
/GetByQuantity	Returns sales ordered by quantity

All responses are derived from parsing a sales.json file located in the application's root directory.
🧪 How to Run

    Clone the repo

git clone https://github.com/your-username/sales-summary-api.git
cd sales-summary-api

Add the sales.json file
Place your JSON data in the root directory of the project. Here's a sample format:

[
  {
    "ProductName": "Laptop",
    "Quantity": 2,
    "UnitPrice": 1000
  },
  {
    "ProductName": "Mouse",
    "Quantity": 10,
    "UnitPrice": 25
  }
]

Run the project

    dotnet run

    Open https://localhost:{port}/swagger in your browser to test via Swagger UI.

📦 Dependencies

    ASP.NET Core 8

    Newtonsoft.Json

    Swashbuckle.AspNetCore (Swagger)

📌 Notes

    If sales.json is missing or empty, meaningful error messages are returned.

    All logic for reading and processing sales is located in ProductService.cs
