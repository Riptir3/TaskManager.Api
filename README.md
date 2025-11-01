# 🧠 Task Manager API

Egy **ASP.NET Core 8 Web API** alapú alkalmazás, amely felhasználói feladatok kezelésére szolgál, felhasználói regisztrációval, bejelentkezéssel és JWT-alapú authentikációval.  
A cél egy modern, biztonságos RESTful API létrehozása, amelyet egy React frontend használ.

---

## 🚀 Funkciók

- 👤 **Felhasználókezelés**
  - Regisztráció
  - Bejelentkezés (JWT tokennel)
  - Token alapú authentikáció

- ✅ **Feladatkezelés (Task CRUD)**
  - Létrehozás  
  - Lekérdezés  
  - Módosítás  
  - Törlés  

- 🔍 **Szűrés, keresés és rendezés** a feladatok között  
- 🔒 **CORS támogatás** a React frontendhez  
- ⚙️ **Egységes hibakezelés** és státuszkódok  

---

## 🧰 Felhasznált technológiák

- **ASP.NET Core 8 Web API**
- **Entity Framework Core**
- **SQL Server (LocalDB)**
- **JWT (JSON Web Token)**
- **AutoMapper**
- **Dependency Injection**
- **CORS Middleware**

---

## 🗂️ Projekt szerkezete

```
TaskManagerAPI/
│
├── Controllers/
│ ├── UsersController.cs
│ └── TasksController.cs
│
├── Data/
│ ├── AppDbContext.cs
│
├── Models/
│ ├── User.cs
│ └── TaskItem.cs
│
├── DTOs/
│ ├── UserRegisterDto.cs
│ ├── UserLoginDto.cs
│ ├── TaskDto.cs
│
├── Services/
│ ├── ITaskService.cs
│ ├── IUserService.cs
│ ├── TaskService.cs
│ ├── UserService.cs
│ └── JwtService.cs
│
├── Helpers/
│ └── PasswordHasher.cs
│
└── Program.cs
```
