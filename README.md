# 

# Restaurant-CLI-App

🍽️ Restaurant CLI App – Built in Pure C#
Welcome to the Restaurant CLI App, a clean, modular, and object-oriented command-line interface application developed with pure C#. This project is designed as a learning journey to master C# architecture, design patterns, and separation of concerns using best practices—no shortcuts, no frameworks—just solid code.

📚 Purpose
This app is part of a hands-on training series where I work as an intern and this project as my learning ground. Every line is written with intention—to learn, to improve, and to build something maintainable and scalable.

🏗️ Architecture Overview
The project follows a clean architecture approach, separating responsibilities clearly across layers:

Host – The starting point of the application.

Application – Contains business logic (e.g., FoodService.cs).

Domain – Core entities like Food.cs, defining the model with persistence-relevant fields.

Contracts – Interfaces and DTOs (IFoodService, FoodDto.cs) that keep communication clean and structure predictable.

📦 Entity Design
We’re using a simple domain model:

public class Food
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsDeleted { get; set; }
}
And a lightweight Data Transfer Object (DTO):

public class FoodDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}

Why use a DTO?
The FoodDto keeps the API clean by exposing only what the caller needs—no internal flags like IsDeleted. It’s a good step toward scalable systems, even for small CLI apps.

🎯 Features (Planned)
Add new food items

List existing food items

Soft-delete items (IsDeleted = true)

Restore soft-deleted items

Simulated DB with in-memory collection

🛠️ Tech Stack
Language: C#

Project Type: Console App (CLI)

Architecture: Layered/Clean Architecture

No frameworks, no external libraries—pure C# only

🔍 Why This Project Matters
This is more than just a CLI app—it's an exercise in:

Writing clean, testable code

Understanding OOP deeply (Encapsulation, Inheritance, DTOs, Interfaces)

Building the kind of logic that’s easy to scale into real software

Thinking like a software architect, even on a small project.

