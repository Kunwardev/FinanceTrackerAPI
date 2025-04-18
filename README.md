# FinanceTrackerAPI
 Making a Personal Finance Tracker to understand the C# concepts better

# 💰 Finance Tracker API

A simple ASP.NET Core Web API that helps users track their income, expenses, and generate financial summaries.

---

## 🚀 Tech Stack

- ASP.NET Core Web API
- Entity Framework Core (SQLite)
- AutoMapper
- xUnit (for testing)
- Swagger (for API docs)
- Serilog (Logging)

---

## Project Structure
FinanceTrackerAPI/
│
├── Controllers/
│   └── IncomeController.cs
│   └── ExpenseController.cs
│
├── Models/
│   └── Income.cs
│   └── Expense.cs
│
├── Data/
│   └── FinanceContext.cs
│   └── Repositories/
│       └── IIncomeRepository.cs
│       └── IncomeRepository.cs
│
├── DTOs/
│   └── IncomeDto.cs
│
├── Profiles/
│   └── MappingProfile.cs
│
└── Program.cs / appsettings.json


## 📦 Setup Instructions

### Prerequisites

- .NET 8 SDK
- VS Code
- SQLite (no setup required, embedded)

### Getting Started

```bash
git clone <your-repo-url>
cd FinanceTrackerAPI
dotnet restore
dotnet ef database update
dotnet run

# Add Serilog packages
dotnet add package Serilog.AspNetCore
dotnet add package Serilog.Sinks.Console
dotnet add package Serilog.Sinks.File