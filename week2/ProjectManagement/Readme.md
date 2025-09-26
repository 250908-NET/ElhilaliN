# 📝 Project Management API (Minimal API with .NET 8)

A lightweight **JIRA-inspired Project Management API** built with **.NET 8 Minimal APIs**.  
This API demonstrates a simple, extendable system for managing **Projects, Issues, and Users** with **role-based permissions**.

---

## 🚀 Features

- **Project Management**

  - Create, update, and delete projects
  - Assign and remove users from projects
  - Retrieve project details, members, and related issues
  - Search projects by keyword

- **Issue Tracking**

  - Create, update, and delete issues
  - Assign issues to users
  - Filter issues by status, priority, type, assigned user, or project
  - Retrieve issues per project
  - Only **Admin** can see all issues

- **User Management**

  - Create, update, and delete users
  - Role-based access to resources
  - Retrieve user-specific projects and issues

- **Authentication & Authorization**

  - JWT-based authentication
  - Role-based authorization
  - Endpoints protected according to **Admin, Manager, and User** roles

- **Tech Stack**
  - .NET 8 Minimal API
  - Entity Framework Core + SQL Server
  - AutoMapper for DTO mapping

---

## 🏗️ Architecture

The project uses a clean layered structure:

- **Presentation Layer** → Minimal API endpoints
- **Application Layer** → Services & Repositories containing business logic
- **Data Layer** → EF Core with SQL Server database
- **Domain Models** → `User`, `Project`, `Issue`, `Role`, `Permission`

---

## 👤 User Roles & Permissions

| Role        | Permissions                                                                                                          |
| ----------- | -------------------------------------------------------------------------------------------------------------------- |
| **Admin**   | Full access: create/update/delete users, projects, issues, assign/remove users to projects                           |
| **Manager** | Manage projects they own: view projects, assign users, create/update/delete issues in their projects |
| **User**    | Limited access: view projects they belong to, view issues assigned to them                                           |

### Example Access

- **Projects Endpoint**

  - **Admin:** sees all projects
  - **Manager:** sees projects they manage
  - **User:** sees projects they are part of

- **Issues Endpoint**

  - **Admin:** sees all issues
  - **Manager:** sees issues in projects they manage
  - **User:** sees only issues assigned to them

- **Project Members Endpoint**
  - **Admin:** sees all members
  - **Manager:** sees members of projects they manage
  - **User:** sees members of projects they are part of

---

## 🔑 Authentication

- JWT Bearer Token authentication
- All endpoints are protected by `[RequireAuthorization]`
- Role checks are performed using a custom `AuthHelpers` utility

---

## 📁 Models

- **User**

  - Id, FullName, Email, PasswordHash, Role
  - Navigation properties: `Projects`, `AssignedIssues`

- **Project**

  - Id, Name, Description, ManagerId
  - Navigation properties: `Manager`, `Issues`

- **Issue**
  - Id, Title, Description, Type, Status, Priority
  - Navigation properties: `Project`, `AssignedUser`

---

## ⚙️ Getting Started

1. Clone the repository
2. Configure your SQL Server connection in `appsettings.json`
3. Run `dotnet ef database update` to apply migrations
4. Run the API: `dotnet run`
5. Use a tool like Postman to test endpoints

---

## 🔧 Future Enhancements

- Add **Comments** for issues
- Implement **Workflow transitions** (ToDo → InProgress → Done)
- Add **Notifications** for assignments and project updates
- Implement **Role-specific dashboards**
