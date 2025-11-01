# 🧠 Task Manager API

An **ASP.NET Core 8 Web API** application for managing user tasks with user registration, login and JWT-based authentication. The goal is to provide a modern, secure RESTful API consumed by a React frontend.

---

## 🚀 Features

* 👤 **User management**

  * Registration
  * Login (with JWT token)
  * Token-based authentication

* ✅ **Task management (Task CRUD)**

  * Create
  * Read
  * Update
  * Delete

* 🔍 **Filtering, searching and sorting** tasks

* 🔒 **CORS support** for the React frontend

* ⚙️ **Centralized error handling** and appropriate status codes

---

## 🧰 Technologies

* **ASP.NET Core 8 Web API**
* **Entity Framework Core**
* **SQL Server (LocalDB)**
* **JWT (JSON Web Token)**
* **Dependency Injection**
* **CORS Middleware**
* **Axios**

---

## 🗂️ Project structure

```
TaskManagerAPI/
│
├── Controllers/
│   ├── UsersController.cs -> User endpoints (registration, login).
│   └── TasksController.cs -> Task endpoints (CRUD, search/filter).
│
├── Data/
│   ├── AppDbContext.cs -> Database configuration.
│
├── Filters/
│   ├── ValidationFilter.cs -> Handles validation errors.
│
├── Middlewares/
│   ├── ErrorHandlingMiddleware.cs -> Global error handling.
│   └── ValidationErrorMiddleware.cs -> Pipes validation errors to the frontend.
│
├── Migrations/ -> Database migrations.
│
├── Models/
│   ├── DTOs/ -> Data Transfer Objects.
│   ├── Entities/ -> Database models.
│   ├── ApiResponse.cs -> Custom API response object.
│
├── Services/
│   ├── JwtService.cs -> JWT token generation.
│   └── PasswordService.cs -> Password hashing and verification.
│
├── appsettings.json -> Configuration file.
│
└── Program.cs
```

---

## 🧪 API endpoints

### 🔹 Users

| HTTP Method | Route                 | Description                    |
| ----------- | --------------------- | ------------------------------ |
| `POST`      | `/api/Users/register` | Register a new user            |
| `POST`      | `/api/Users/login`    | Log in and receive a JWT token |

### 🔹 Tasks (authentication required)

| HTTP Method | Route             | Description       |
| ----------- | ----------------- | ----------------- |
| `GET`       | `/api/Tasks`      | Get all tasks     |
| `GET`       | `/api/Tasks/{id}` | Get a task by ID  |
| `POST`      | `/api/Tasks`      | Create a new task |
| `PUT`       | `/api/Tasks/{id}` | Update a task     |
| `DELETE`    | `/api/Tasks/{id}` | Delete a task     |

---

## 🔑 JWT authentication

After successful login the server returns a JWT token that the client should send with every request in the header:

```http
Authorization: Bearer <token>
```

### Example request:

```http
GET /api/Tasks HTTP/1.1
Host: localhost:7242
Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...
```

Currently, when the token expires the client must re-authenticate (log in again).

---

## 🌍 Frontend integration

A React + Tailwind based frontend is available and intended to work with this backend:

👉 [Task Manager Frontend](https://github.com/Riptir3/task-manager-frontend)

The two applications communicate over Axios and use the `https://localhost:7242/api/...` endpoints.

---

## ⚙️ Installation & running

### 1️⃣ Clone the repository

```bash
git clone https://github.com/Riptir3/TaskManager.Api.git
cd TaskManager.API
```

### 2️⃣ Build / restore dependencies

```bash
dotnet build
```

### 3️⃣ Create the database

```bash
dotnet ef database update
```

### 4️⃣ Run the application

```bash
dotnet run
```

### The backend will be available at:

```
https://localhost:7242
```

### Swagger UI:

```
https://localhost:7242/swagger
```

---

## Contact

Developer: **Riptir3 (Bence)**
GitHub: [github.com/Riptir3](https://github.com/Riptir3)
