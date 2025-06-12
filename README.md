# DevTrack - Project & Task Management System

A modern, full-stack task management application built with **Blazor Server** and **.NET 8**. DevTrack provides a clean, dark-themed interface for managing projects, tracking tasks with a Kanban board, and monitoring time spent on work.

## 🚀 Features

### ✅ Core Functionality
- **Project Management**: Create, edit, and delete projects with descriptions and due dates
- **Kanban Board**: Drag-and-drop-style task management with To Do, In Progress, and Done columns
- **Task Management**: Full CRUD operations with priorities, due dates, and tags
- **Time Tracking**: Built-in timer with manual time logging and history
- **Analytics Dashboard**: Visual insights into productivity and project progress
- **Search & Filtering**: Find tasks by status, priority, tags, and text search

### 🎨 User Experience
- **Modern Dark Theme**: Beautiful, eye-friendly dark interface with light mode toggle
- **Responsive Design**: Works seamlessly on desktop, tablet, and mobile devices
- **Real-time Updates**: Instant UI updates when modifying tasks and projects
- **Loading States**: Smooth loading indicators throughout the application
- **Error Handling**: User-friendly error messages and validation

### 🔐 Authentication & Security
- **ASP.NET Core Identity**: Secure user authentication and authorization
- **User Isolation**: Each user's data is completely separated and private
- **Session Management**: Secure login/logout with proper session handling

## 🛠️ Technology Stack

### Backend
- **.NET 8** - Latest version of the .NET framework
- **Blazor Server** - Server-side rendering with SignalR real-time updates
- **Entity Framework Core 8** - Modern ORM for database operations
- **ASP.NET Core Identity** - Built-in authentication and authorization
- **SQLite** - Lightweight, file-based database (easily swappable)

### Frontend
- **Blazor Razor Components** - Component-based UI with C#
- **Bootstrap 5** - Responsive CSS framework
- **Font Awesome** - Beautiful icons throughout the application
- **Inter Font** - Modern, readable typography
- **Custom CSS Variables** - Seamless dark/light theme switching

### Architecture
- **Component-Based Design** - Reusable, maintainable Blazor components
- **Repository Pattern** - Data access through Entity Framework DbContext
- **Separation of Concerns** - Clear separation between UI, business logic, and data
- **Modern C# Features** - Uses latest C# language features and patterns

## 📦 Getting Started

### Prerequisites
- **.NET 8 SDK** - [Download here](https://dotnet.microsoft.com/download/dotnet/8.0)
- **Git** - For cloning the repository
- **Visual Studio 2022** or **VS Code** (recommended IDEs)

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/devtrack.git
   cd devtrack
   ```

2. **Restore packages**
   ```bash
   dotnet restore
   ```

3. **Create the database**
   ```bash
   dotnet ef database update
   ```

4. **Run the application**
   ```bash
   dotnet run
   ```

5. **Open your browser**
   Navigate to `https://localhost:5001` or `http://localhost:5000`

### First Time Setup
1. Click "Register" to create your account
2. Sign in with your new credentials
3. Create your first project from the Projects page
4. Add tasks using the Kanban board
5. Start tracking time on your tasks!

## 📱 Application Screenshots

### Dashboard
The main dashboard provides an overview of your projects with progress indicators and recent activity.

### Projects Page
Manage all your projects with creation, editing, and progress tracking capabilities.

### Kanban Board
Visual task management with three columns: To Do, In Progress, and Done. Click tasks to edit or use the arrow buttons to move between statuses.

### Time Tracking
Built-in timer functionality with manual time logging and detailed history views.

### Analytics
Comprehensive analytics showing task distribution, priority breakdown, and project progress.

### Settings
Customize your experience with theme selection and application preferences.

## 🏗️ Project Structure

```
DevTrack/
├── Data/                   # Database context and configurations
│   └── DevTrackDbContext.cs
├── Models/                 # Entity models
│   ├── Project.cs
│   ├── DevTask.cs
│   └── TimeLog.cs
├── Pages/                  # Razor pages and components
│   ├── Index.razor         # Dashboard
│   ├── Projects.razor      # Project management
│   ├── Tasks.razor         # Task list view
│   ├── Kanban.razor        # Kanban board
│   ├── Timer.razor         # Time tracking
│   ├── Analytics.razor     # Analytics dashboard
│   └── Settings.razor      # User settings
├── Shared/                 # Shared components
│   ├── MainLayout.razor    # Main application layout
│   └── NavMenu.razor       # Navigation sidebar
├── wwwroot/               # Static files
│   └── css/
│       └── devtrack.css    # Custom styling and themes
├── Areas/Identity/         # Authentication pages
├── Migrations/            # EF Core database migrations
└── Program.cs             # Application startup
```

## 💾 Database Schema

### Projects Table
- `Id` (Guid) - Primary key
- `Title` (string) - Project name
- `Description` (string) - Project description
- `UserId` (string) - Foreign key to user
- `DueDate` (DateTime?) - Optional due date
- `CreatedAt` / `UpdatedAt` (DateTime) - Timestamps

### Tasks Table
- `Id` (Guid) - Primary key
- `Title` (string) - Task name
- `Description` (string) - Task details
- `Status` (enum) - ToDo, InProgress, Done
- `Priority` (enum) - Low, Medium, High
- `ProjectId` (Guid) - Foreign key to project
- `UserId` (string) - Foreign key to user
- `Tags` (string) - Comma-separated tags
- `DueDate` (DateTime?) - Optional due date
- `IsCompleted` (bool) - Completion status
- `CreatedAt` / `UpdatedAt` (DateTime) - Timestamps

### TimeLogs Table
- `Id` (Guid) - Primary key
- `TaskId` (Guid) - Foreign key to task
- `UserId` (string) - Foreign key to user
- `Date` (DateTime) - Date of work
- `Hours` (double) - Time spent in hours
- `Description` (string) - Work description

## 🔧 Configuration

### Connection String
Update `appsettings.json` to change database configuration:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=devtrack.db"
  }
}
```

### Identity Settings
Authentication settings can be modified in `Program.cs`:
```csharp
builder.Services.AddDefaultIdentity<IdentityUser>(options => 
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    // ... other settings
})
```

## 🎯 Development Roadmap

### Completed Features ✅
- [x] Project CRUD operations
- [x] Task management with Kanban board
- [x] Time tracking with timer
- [x] Analytics dashboard
- [x] User authentication
- [x] Dark/Light theme support
- [x] Responsive design
- [x] Search and filtering

### Future Enhancements 🚀
- [ ] Drag-and-drop task reordering
- [ ] Team collaboration features
- [ ] File attachments for tasks
- [ ] Email notifications
- [ ] Advanced reporting
- [ ] Mobile app
- [ ] API endpoints
- [ ] Export functionality

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details.

## 👨‍💻 Author

**Brandon** - Full Stack Developer
- Portfolio: [Your Portfolio URL]
- LinkedIn: [Your LinkedIn Profile]
- GitHub: [Your GitHub Profile]

## 🙏 Acknowledgments

- Built with [Blazor Server](https://docs.microsoft.com/en-us/aspnet/core/blazor/)
- Icons by [Font Awesome](https://fontawesome.com/)
- Typography by [Inter Font](https://rsms.me/inter/)
- Inspiration from modern project management tools

---

### 🎯 Perfect for Portfolio Demonstrations

This project showcases:
- **Modern .NET Development** - Latest C# and .NET 8 features
- **Full-Stack Architecture** - Complete application with frontend, backend, and database
- **Clean Code Practices** - Well-organized, maintainable codebase
- **User Experience Focus** - Polished UI with attention to detail
- **Real-World Features** - Practical functionality that solves actual problems

Built as a demonstration of modern web development skills using Microsoft's latest technologies.