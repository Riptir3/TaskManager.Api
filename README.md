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
- **Dependency Injection**
- **CORS Middleware
- **Axios**

---

## 🗂️ Projekt szerkezete

```
TaskManagerAPI/
│
├── Controllers/
│ ├── UsersController.cs -> Felhasználói végpontok ( regisztráció, bejelentkezés ).
│ └── TasksController.cs -> Felhasználói feladatok végpontjai ( CRUD, keresés/szűrés).
│
├── Data/
│ ├── AppDbContext.cs -> Adatbázis konfiguráció.
│
├── Filters/
│ ├── ValidationFilter.cs -> Validációs hibák kezelése.
│
├── Middlewares/
│ ├── ErrorHandlingMiddleware.cs -> Hiba kezelés.
│ └── ValidationErrorMiddleware.cs -> Validációs hibák eljutatása a frontendre.
│
├── Migrations/ -> Adatbázis migrációk.
|
├── Models/
│ ├── DTOs/ -> Data Transfer Objects.
│ ├── Entities/ -> Adatbázis modellek.
│ ├── ApiResponse.cs -> Egyedi response object.
│
├── Services/
│ ├── JwtService.cs -> JWT token generálás
│ └── PasswordService.cs -> Jelszó titkosítás és ellenőrzés.
│
├──appsettings.json -> Konfigurációs fájl.
|
└── Program.cs
```
