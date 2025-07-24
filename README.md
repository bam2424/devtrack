# DevTrack - Modern Project Management System
Full-stack task management with Kanban boards, time tracking, and analytics

A beautiful, dark-themed project management application built with **Blazor Server** and **.NET 8** that enables seamless project organization, task tracking, and productivity monitoring across teams and individuals.

##  Features

 **Project Management**: Complete CRUD operations with descriptions, due dates, and progress tracking  
 **Kanban Board**: Visual task management with To Do, In Progress, and Done columns  
 **Time Tracking**: Built-in timer with manual logging and comprehensive history  
 **Analytics Dashboard**: Visual insights into productivity and project progress  
 **Advanced Filtering**: Search by status, priority, tags, projects, and text content  
 **Modern Dark UI**: Beautiful, eye-friendly interface with premium dark theme  
 **Responsive Design**: Seamless experience across desktop, tablet, and mobile  
 **Secure Authentication**: ASP.NET Core Identity with user data isolation  

## Screenshots

### Main Dashboard - Project Overview & Quick Actions
![Dashboard Interface](docs/images/Dashboard%20Interface.png)  
*Clean dashboard featuring project cards with progress indicators, recent activity feed, and quick action buttons for creating projects and tasks.*

### Kanban Board - Visual Task Management
![Kanban Board](docs/images/Kanban%20Board.png)  
*Intuitive Kanban interface with three-column layout (To Do, In Progress, Done), task cards showing priority levels, due dates, and tags with smooth status transitions.*

### Analytics Dashboard - Productivity Insights
![Analytics Dashboard](docs/images/Analytics%20Dashboard.png)  
*Comprehensive analytics featuring task distribution charts, priority breakdowns, time tracking summaries, and project progress visualization with interactive elements. (photo zoomed out to show whole page)*

### Time Tracking - Built-in Timer & History
![Time Tracking](docs/images/Time%20Tracking.png)  
*Professional time tracking interface with active timer display, manual time logging, detailed history views, and productivity statistics.*

## 🚀 Getting Started

### How to Use
1. **Register Account**: Create your secure user account using Google sign-in or continue without an account
2. **Create Project**: Set up your first project with description and due date
3. **Add Tasks**: Use the Kanban board to create and organize tasks with priorities and tags
4. **Track Time**: Start the built-in timer or log time manually for accurate tracking
5. **Monitor Progress**: View analytics dashboard with charts and insights on your productivity
6. **Manage Projects**: Switch between projects, filter tasks, and track completion status

## 🔧 Technical Specifications

### Core Features
| Feature | Status | Description |
|---------|--------|-------------|
| ✅ **Project Management** | Fully Working | Complete CRUD with progress tracking |
| ✅ **Kanban Board** | Fully Working | Visual task management with status columns |
| ✅ **Time Tracking** | Fully Working | Built-in timer with manual logging |
| ✅ **Analytics** | Fully Working | Charts and productivity insights |
| ✅ **Search & Filter** | Fully Working | Advanced filtering by multiple criteria |
| ✅ **Authentication** | Fully Working | Secure user accounts with data isolation |
| ✅ **OAuth Sign-in** | Fully Working | Ability to login with google account securely |

## For Developers

### Requirements
- **.NET 8 SDK** - Latest framework version
- **Visual Studio 2022** (v17.8+) or VS Code
- **Git** - Version control

### Quick Setup
```bash
git clone https://github.com/bam2424/devtrack.git
cd devtrack
dotnet restore
dotnet ef database update
dotnet run
```

### Project Structure
```
DevTrack/
├── 📁 Data/                # Database context & configurations
├── 📁 Models/              # Entity models (Project, Task, TimeLog)
├── 📁 Pages/               # Razor pages & components
├── 📁 Shared/              # Shared components & layouts
├── 📁 wwwroot/             # Static files & custom CSS
├── 📁 Areas/Identity/      # Authentication pages
├── 📁 Migrations/          # EF Core database migrations
└── 📄 Program.cs           # Application startup
```

### Technology Stack

**Backend**
- **.NET 8** - Latest framework with modern C# features
- **Blazor Server** - Server-side rendering with real-time updates
- **Entity Framework Core 8** - Modern ORM with SQLite database
- **ASP.NET Core Identity** - Secure authentication system

**Frontend**
- **Blazor Razor Components** - Component-based UI architecture
- **Bootstrap 5** - Responsive CSS framework
- **Font Awesome** - Professional icon library
- **Custom CSS Variables** - Premium dark theme system

## Database Schema

### Core Entities
```sql
Projects
├── Id (Guid) - Primary key
├── Title (string) - Project name
├── Description (string) - Project details
├── UserId (string) - Owner reference
├── DueDate (DateTime?) - Optional deadline
└── CreatedAt/UpdatedAt (DateTime) - Timestamps

Tasks
├── Id (Guid) - Primary key
├── Title (string) - Task name
├── Description (string) - Task details
├── Status (enum) - ToDo, InProgress, Done
├── Priority (enum) - Low, Medium, High
├── ProjectId (Guid) - Project reference
├── UserId (string) - Owner reference
├── Tags (string) - Comma-separated tags
├── DueDate (DateTime?) - Optional deadline
└── CreatedAt/UpdatedAt (DateTime) - Timestamps

TimeLogs
├── Id (Guid) - Primary key
├── TaskId (Guid) - Task reference
├── UserId (string) - Owner reference
├── StartTime (DateTime) - Session start
├── EndTime (DateTime?) - Session end
├── DurationMinutes (int) - Total time
└── Notes (string) - Work description
```

##  Authentication & Google Sign-In

### Multiple Login Options
DevTrack supports both traditional email/password authentication and Google OAuth integration for seamless user experience.

**Available Authentication Methods:**
- ✅ **Email & Password** - Traditional account registration (always available)
- 🔄 **Google Sign-In** - One-click authentication with Google accounts (configurable)

### Google Sign-In Integration
The Google OAuth integration provides users with a convenient single sign-on experience using their existing Google accounts.

**Features:**
- **Seamless Login** - Users can sign in with their Google account in one click
- **Profile Integration** - Automatically imports user profile information and email
- **Secure Authentication** - Uses Google's OAuth 2.0 security standards
- **Login Logging** - Tracks Google authentication events for analytics

### Security Implementation
- OAuth credentials are environment-based (never stored in source code)
- Conditional OAuth registration prevents startup errors when credentials are unavailable
- User data isolation ensures secure multi-user experience
- Session management follows ASP.NET Core Identity best practices


## 👨‍💻 Author

**Brandon** - Full Stack Developer  
🌐 Portfolio: https://brandonmattingly.vercel.app/           
🐙 GitHub: [@bam2424](https://github.com/bam2424)
