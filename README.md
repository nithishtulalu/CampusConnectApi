# 📚 CampusConnectAPI — Backend System

CampusConnectAPI is a robust, modular backend system built with **ASP.NET Core** for managing academic operations in a university or campus environment. It supports role-based access, dynamic data flows, and production-grade resilience.

## 🚀 Modules Included

| Module         | Features                                                                 |
|----------------|--------------------------------------------------------------------------|
| 🎓 Courses     | Create/view/update/delete courses                                         |
| 📘 Subjects    | Manage subjects within a course                                           |
| 🧮 Grades      | Track academic scores with secure role filters                            |
| 🕒 Attendance  | Record and query attendance per student                                   |
| 💸 Fees        | Auto-generate fees, accept payments, view balances                        |
| 💳 Transactions| Full audit of student payments                                            |
| 📚 Library     | Borrow/return books, view history                                         |
| 🎉 Events      | View upcoming events, register, list user events                          |
| 💬 Support     | Submit contacts, feedback, and view FAQs                                  |


## 🔐 Authentication & Roles

- JWT-based authentication
- Roles: `Admin`, `Student`, `Teacher`
- Secure endpoints via `[Authorize(Roles = ...)]`

## 📦 Tech Stack

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server (or SQLite for local dev)
- Swagger (OpenAPI)
- Postman test flows

## 📂 Folder Structure

ampusConnectAPI/
├── Controllers/ 
├── Models/ 
├── DTOs/
├── Repositories/
├── Services/ 
├── ApplicationDbContext
├── Migrations/
├── AppSetting.json
├── Program.cs
└── README.md
