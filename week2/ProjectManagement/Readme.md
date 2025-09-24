# 📝 Project Management API (Minimal API with .NET 8)

A lightweight **JIRA-inspired Project Management API** built with **.NET 8 Minimal APIs**.  
This project demonstrates how to design a simple yet extendable system for managing **Projects, Issues, and Users** with **roles & permissions**.

---

## 🚀 Features

- ✅ Create and manage **Projects**
- ✅ Track **Issues** (Bug, Task, Story) with status, priority, and assignment
- ✅ Manage **Users** with role-based permissions (Admin, Project Manager, Developer, QA)
- ✅ Navigation between **Users → Projects → Issues**
- ✅ Entity Framework Core with **SQL Server** 
- ✅ Extensible architecture for future features (comments, workflows, notifications)

---

## 🏗️ Architecture

The project mimics a simplified version of **JIRA’s real architecture**:

- **Presentation Layer** → Minimal API Endpoints
- **Application Layer** → Services & Repositories (business logic)
- **Data Layer** → EF Core + SQL Server database
- **Domain Models** → `User`, `Project`, `Issue`, `Role`, `Permission`

