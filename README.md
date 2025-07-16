# 🛒 Product & Order Management System API

An ASP.NET Core Web API for managing products, variants, and customer orders. Includes role-based JWT authentication, FluentValidation for input validation, and a clean service architecture.

---

## 🚀 Features

### ✅ Product Management
- Create, update, view, and delete products
- Each product can have multiple variants
- Product Fields: `name`, `brand`, `type` (`enum`: Mug, Jug, Cup, etc.)
- Variant Fields: `color`, `specification`, `size` (`enum`: Small, Medium, Large)

### ✅ Order Management
- Create orders in multiple steps:
  1. Select products
  2. Select variants and quantity
  3. Provide customer information
- View, update, and delete orders
- Calculates total quantity automatically

### ✅ Authentication
- Register and login using JWT tokens
- Secure endpoints with [Authorize] attributes
- Roles: `Admin`, `User`
  - Admin can create/update/delete products
  - Users can place/view orders

### ✅ Built With
- ASP.NET Core 8 Web API
- Entity Framework Core + MS SQL Server
- ASP.NET Core Identity
- FluentValidation
- JWT Authentication
- Swagger (OpenAPI)

---

