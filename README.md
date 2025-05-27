# FitRoutine🏋️‍♀️

Welcome to **FitRoutine**, your ultimate solution for managing and tracking fitness activities. FitRoutine is a web application designed to streamline activity registration, instructor management, and session scheduling for a healthier lifestyle.

## 📋 Overview

FitRoutine is built with .NET Core 8 and follows the MVC architecture. It provides a seamless experience for users to register, schedule sessions, and manage their fitness journey. Admins can oversee activities, trainers, and sessions to ensure everything runs efficiently.

Whether you're an individual looking to organize your workouts or an admin managing multiple users and activities, FitRoutine provides a user-friendly interface and powerful features to meet your needs.

## 🚀 Features

- **Activity Management**: Add, edit, and remove fitness activities.
- **Instructor Management**: Manage instructor profiles and specialties.
- **Session Scheduling**: Schedule sessions between users and instructors.
- **User Registration**: Allow users to register, log in, and manage their sessions.
- **Progress Tracking**: Monitor and review user progress over time.

## 📸 Screenshots

Here are some screenshots of the FitRoutine application:

![Image](https://github.com/user-attachments/assets/2bd5c1dd-5cd3-4578-b46f-3b79fe55c43b)
![Image](https://github.com/user-attachments/assets/7f43bcb5-aeb6-4129-b1d2-b4462b739479)


## 💻 Installation

To get started with FitRoutine, follow these steps:

1. **Clone the repository:**
    ```bash
    git clone https://github.com/AnthonyGzm/FitRoutineapp.git
    cd fitroutine
    ```

2. **Install dependencies:**
    Ensure you have [.NET Core 8 SDK](https://dotnet.microsoft.com/download) installed. Run:
    ```bash
    dotnet restore
    ```

3. **Update your database connection string:**
    Open `appsettings.json` and configure your database connection string.

4. **Apply migrations:**
    ```bash
    dotnet ef database update
    ```

5. **Run the application:**
    ```bash
    dotnet run
    ```

    Navigate to `http://localhost:5000` in your web browser to see the application in action.

## 📂 Project Structure

- **FitRoutine.Domain**: Contains domain entities and business logic.
- **FitRoutine.Infrastructure**: Handles data persistence and database operations.
- **FitRoutine.Application**: Provides use cases and application services.
- **FitRoutine.Web**: Contains MVC views and controllers.
- **FitRoutine.Api**: Provides API endpoints for external integrations.
- **FitRoutine.Ioc**: Manages dependency injection configuration.

## 🛠 Technologies

- **ASP.NET Core 8**: Framework for building modern web applications.
- **Entity Framework Core**: ORM for data access.
- **Bootstrap**: CSS framework for styling.
- **Font Awesome**: Icon library for modern UI.

## 📝 License

FitRoutine is open-source software licensed under the [MIT License](LICENSE).

## 🧩 By

Developed by Anthony Guzman.



