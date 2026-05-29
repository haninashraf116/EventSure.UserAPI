
# EventSure User Module

## Overview
This project implements the User Module for **EventSure** using ASP.NET Core Web API.  
It includes:
- In-memory user store
- Secure password hashing using BCrypt
- Two core endpoints: **Register** and **Login**
- Membership tier logic

---

## Technologies Used
- ASP.NET Core (.NET 6 / .NET 7)
- C#
- BCrypt.Net for password hashing
- Postman for testing

---

##  Project Structure
- `Controllers/UsersController.cs`: Handles API endpoints for user registration and login
- `Models/UserAccount.cs`: Represents the user data structure
- `Services/UserService.cs`: Contains the logic for storing and verifying users
- `Program.cs`: Main entry point of the application

---

##  How to Run the Project

1. Open the solution in **Visual Studio 2022** or **VS Code**.
2. Ensure you have **.NET 6 SDK** or higher installed.
3. Run the project using:
   ```
   dotnet run
   ```
4. The API will be available at:
   ```
   https://localhost:{port}/api/users
   ```

---

##  How to Test using Postman

###  1. Successful Registration
**POST** `https://localhost:{port}/api/users/register`  
**Body (JSON):**
```json
{
  "username": "haneen123",
  "email": "haneen@example.com",
  "password": "password123",
  "confirmPassword": "password123",
  "membershipTier": "General"
}
```

###  2. Registration with Existing Email
Use the same email as before → returns error message.

###  3. Successful Login
**POST** `https://localhost:{port}/api/users/login`  
**Body (JSON):**
```json
{
  "email": "haneen@example.com",
  "password": "password123"
}
```

###  4. Login with Wrong Password
Use wrong password → returns unauthorized error.

📎 Screenshots of all cases are included in the attached PDF file.

---

## 📝 Notes
- All data is stored in memory (no database used).
- MembershipTier defaults to `General` if not provided.
- Passwords are hashed using BCrypt to ensure security.

---

## Developed by
**Hanin**  
