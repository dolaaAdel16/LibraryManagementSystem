# 📚 Library Management System

A console-based **Library Management System** built with **C# and .NET 8**.

This project was created to practice core Object-Oriented Programming concepts through a practical library-management scenario involving books, members, borrowing records, searching, and overdue tracking.

---

## 🛠 Tech Stack

![C#](https://img.shields.io/badge/C%23-512BD4?style=flat-square&logo=csharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET%208-512BD4?style=flat-square&logo=dotnet&logoColor=white)

- C#
- .NET 8
- Console Application

---

## 🚀 Implemented Features

### 📖 Book Management

The system supports:

- Adding books
- Tracking book availability
- Searching books by:
  - Title
  - Author
  - Genre
- Displaying available books

Each book contains:

- ID
- Title
- Author
- Publication Year
- Genre
- Availability Status
- Added Date

---

### 👤 Member Management

The system supports two member types:

#### Regular Member

- Maximum borrowing limit: **5 books**
- Loan period: **14 days**

#### Premium Member

- Maximum borrowing limit: **10 books**
- Loan period: **30 days**

Members store:

- ID
- Name
- Email
- Join Date
- Borrowed Books

---

## 🔄 Borrowing System

The application contains business logic for:

- Borrowing books
- Returning books
- Checking book availability
- Checking member borrowing limits
- Creating borrowing records
- Updating book availability
- Updating the member's borrowed-book collection

---

## 📜 Borrowing History

Each borrowing operation creates a `BorrowRecord` containing:

- Record ID
- Book
- Member
- Borrow Date
- Return Date

The system can display a member's borrowing history and indicate whether a borrowed book has been returned.

---

## ⏰ Late Return Tracking

The system calculates whether a borrowing record is overdue based on the member's allowed loan period.

It can also calculate:

```text
Days Overdue

and generate a late-return report showing:

Member name
Book title
Borrow date
Number of overdue days
🔎 Search Functionality

Books and members support search functionality.

Books can be searched by:

Title
Author
Genre

Members can be searched by:

Name
Email

This demonstrates a shared searchable behavior across different domain objects.

🧠 OOP Concepts Applied
Abstraction

The project uses an abstract base class:

LibraryItem

which provides common properties such as:

ID
Title
Added Date

and defines an abstract:

GetInfo()

method.

Inheritance

Book inherits from:

LibraryItem

and:

PremiumMember

inherits from:

Member
Polymorphism

The PremiumMember class overrides:

MaxBorrowLimit
LoanDays
GetInfo()

allowing different member types to have different borrowing behavior.

Encapsulation

Library operations such as:

Finding books
Finding members
Finding open borrowing records

are handled internally inside the Library service.

Interfaces

Searchable domain objects implement a common searchable behavior, allowing both books and members to support query matching.

🏗 Project Structure
LibraryManagementSystem
│
├── Models
│   ├── LibraryItem
│   ├── Book
│   ├── Member
│   ├── PremiumMember
│   └── BorrowRecord
│
├── Services
│   └── Library
│
├── Interfaces
│   └── Searchable behavior
│
└── Program.cs
🖥 Console Menu

The application currently contains the following menu structure:

===== Library System =====

1. Add Book
2. Register Member
3. Borrow Book
4. Return Book
5. Search Catalog
6. View Available Books
7. Member History
8. Late Return Report
0. Exit
🚧 Project Status

This project is currently a learning / practice project.

The core domain models and library business logic are implemented, while some console menu actions still need to be connected to the existing service methods.

🔮 Planned Improvements

Future improvements may include:

Complete console menu integration
Better input validation
Custom exception handling
Replace fixed-size arrays with collections
SQL Server persistence
Entity Framework Core
Repository Pattern
Unit Testing
Logging
Refactor into separate application layers
ASP.NET Core Web API version
📚 What I Practiced

Through this project, I practiced:

Object-Oriented Programming
Abstraction
Inheritance
Polymorphism
Encapsulation
Interfaces
Arrays
Nullable Reference Types
Exception Handling
Business Logic
Searching
Borrowing workflows
Date calculations
⚙️ Getting Started
Prerequisites

Make sure you have:

.NET 8 SDK
Visual Studio / Visual Studio Code / Rider
Git
Clone the Repository
git clone https://github.com/dolaaAdel16/LibraryManagementSystem.git

Navigate to the repository:

cd LibraryManagementSystem

Run the project:

dotnet run --project LibraryManagementSystem/LibraryManagementSystem.csproj
👨‍💻 Author

Ahmed Adel Hassan

Junior .NET Backend Developer
