# Employee Management System
**ASP.NET MVC 5 + SQL Server**

## Features
- Full CRUD (Create, Read, Update, Delete)
- Cascading Dropdown (Department → Designation via AJAX)
- Form Validation (server-side + client-side)
- Delete confirmation modal
- Bootstrap 4 UI

---

## Setup Steps

### Step 1 – Database Setup
1. Open **SQL Server Management Studio (SSMS)**
2. Open file: `Database/EmployeeDB.sql`
3. Run the script → it will create `EmployeeManagementDB` with tables and seed data

### Step 2 – Configure Connection String
Open `Web.config` and update the connection string:

```xml
<add name="EmployeeDBConnection"
     connectionString="Server=YOUR_SERVER;Database=EmployeeManagementDB;Integrated Security=True;"
     providerName="System.Data.SqlClient" />
```

| Server Type       | Value to use             |
|-------------------|--------------------------|
| LocalDB           | `(localdb)\MSSQLLocalDB` |
| SQL Server Express| `.\SQLEXPRESS`           |
| Full SQL Server   | `YOUR_PC_NAME\SQLSERVER` |

### Step 3 – Open in Visual Studio
1. Open Visual Studio 2019 or later
2. Open the `.sln` file (or open the folder as a project)
3. Right-click the solution → **Restore NuGet Packages**
4. Build the solution (Ctrl+Shift+B)
5. Press **F5** to run

---

## NuGet Packages Required
- `EntityFramework` (6.x)
- `Microsoft.AspNet.Mvc` (5.x)
- `Microsoft.AspNet.Web.Optimization`
- `jQuery.Validation.Unobtrusive`

---

## Project Structure
```
EmployeeManagementSystem/
├── Controllers/
│   └── EmployeeController.cs     ← CRUD + AJAX endpoint
├── Models/
│   ├── Employee.cs               ← Employee model with validations
│   ├── Department.cs             ← Department & Designation models
│   └── EmployeeDbContext.cs      ← EF DbContext
├── Views/
│   ├── Employee/
│   │   ├── Index.cshtml          ← Employee list + delete modal
│   │   ├── Create.cshtml         ← Add employee form
│   │   ├── Edit.cshtml           ← Edit employee form
│   │   └── _EmployeeForm.cshtml  ← Shared form partial
│   └── Shared/
│       └── _Layout.cshtml        ← Bootstrap layout
├── Database/
│   └── EmployeeDB.sql            ← DB creation + seed script
├── App_Start/
│   └── RouteConfig.cs
├── Global.asax.cs
└── Web.config                    ← Connection string here
```

---

## Cascading Dropdown Logic
- When **Department** is changed, an AJAX call hits `/Employee/GetDesignations?departmentId=X`
- The **Designation** dropdown is dynamically populated based on the selected department

| Department | Designations                        |
|------------|-------------------------------------|
| IT         | Developer, Tester, DevOps           |
| HR         | Recruiter, HR Manager               |
| Sales      | Sales Executive, Sales Manager      |
