# DevTrack MVP Task Breakdown

## Phase 1: Project Setup & Foundation
**Goal: Get basic Blazor Server app running with database**

### 1.1 Project Scaffolding
- [x] Create new Blazor Server project with .NET 8
- [x] Set up solution structure with proper folder organization
- [x] Add required NuGet packages (EF Core, Identity, SQLite)
- [x] Configure appsettings.json for development
- [x] Set up Git repository and initial commit

### 1.2 Database Setup
- [x] Create DbContext class with proper configuration
- [x] Define Project entity model
- [x] Define Task entity model with relationships
- [x] Create initial EF migration
- [x] Configure database connection string for SQLite
- [x] Test database creation and basic seeding

### 1.3 Authentication Setup
- [x] Configure ASP.NET Identity services (use defaults)
- [x] Create registration page component
- [x] Create login page component  
- [x] Create logout functionality
- [x] Add authentication middleware to Program.cs
- [x] Test user registration and login flow

## Phase 2: Core UI Components & Layout
**Goal: Build basic navigation and layout structure**

### 2.1 Layout & Navigation
- [x] Create main layout component (MainLayout.razor)
- [x] Build navigation sidebar with menu items
- [x] Create header component with user info and logout
- [x] Add responsive design considerations
- [x] Create loading states and error boundaries
- [x] Test navigation between pages

### 2.2 Dashboard Components
- [x] Create dashboard page to list user's projects
- [x] Build project card component for dashboard
- [x] Add "Create New Project" button and form
- [x] Create project creation form component
- [x] Test project creation and display

## Phase 3: Project Management Core
**Goal: Basic CRUD operations for projects**

### 3.1 Project Services
- [x] Create ProjectService for business logic (implemented in components)
- [x] Implement CreateProject method
- [x] Implement GetUserProjects method  
- [x] Implement UpdateProject method
- [x] Implement DeleteProject method
- [x] Add basic validation for projects
- [x] Test all CRUD operations

### 3.2 Project UI
- [x] Create project details page
- [x] Build project edit form component
- [x] Add project deletion confirmation dialog
- [x] Test project management workflow

## Phase 4: Kanban Board MVP
**Goal: Basic task management with columns**

### 4.1 Task Models & Services
- [x] Create TaskService for task operations (implemented in components)
- [x] Implement CreateTask method
- [x] Implement GetTasksByProject method
- [x] Implement UpdateTaskStatus method
- [x] Implement UpdateTask method
- [x] Implement DeleteTask method
- [x] Add task validation logic

### 4.2 Kanban Board UI
- [x] Create KanbanBoard component
- [x] Build TaskColumn component (To Do, In Progress, Done)
- [x] Create TaskCard component for individual tasks
- [x] Build "Add Task" form component
- [x] Create task detail modal/page
- [x] Add task editing functionality
- [x] Test task creation and status updates

### 4.3 Task Properties
- [x] Add task title and description fields
- [x] Implement task priority levels (Low, Medium, High)
- [x] Add due date functionality
- [x] Create simple tag system for tasks (comma-separated)
- [x] Add task completion tracking
- [x] Test all task properties

## Phase 5: Basic Time Tracking
**Goal: Simple time logging for tasks**

### 5.1 Time Tracking Models
- [x] Create TimeLog entity model
- [x] Add relationship between TimeLog and Task
- [x] Create time tracking service (implemented in components)
- [x] Implement start/stop timer logic
- [x] Add time calculation methods
- [x] Create EF migration for time tracking

### 5.2 Time Tracking UI
- [x] Add timer button to task cards
- [x] Create active timer indicator
- [x] Build simple time log display
- [x] Create basic time summary view
- [x] Test timer functionality

## Phase 6: MVP Polish & Testing
**Goal: Make the app presentable for portfolio**

### 6.1 Basic Polish
- [x] Add basic error handling and user-friendly messages
- [x] Add loading states for operations
- [x] Implement basic authorization checks
- [x] Handle common edge cases
- [x] Test main user workflows

### 6.2 Final Touches
- [x] Add basic task filtering by tags
- [x] Add simple task search functionality
- [x] Add responsive styling improvements
- [x] Create a simple README with screenshots
- [x] Test the complete user flow end-to-end
- [ ] Add sample data for demo purposes

## Future Enhancements (Post-MVP)
- [ ] SignalR real-time updates
- [ ] Drag-and-drop for tasks
- [ ] Advanced tag management (autocomplete, tag colors, tag categories)
- [ ] Advanced search and filtering (multiple criteria)
- [ ] CSV/PDF export functionality
- [ ] Advanced analytics dashboard
- [ ] Markdown notes support
- [ ] Team collaboration features
- [ ] Email notifications
- [ ] Advanced security hardening

---

## Development Notes

### MVP Success Criteria
1. Users can register and log in
2. Users can create and manage projects
3. Users can create tasks and move them between columns (To Do, In Progress, Done)
4. Users can track basic time on tasks
5. Clean, responsive UI that demonstrates modern web development skills
6. Portfolio-ready with good code structure and documentation

### Technology Stack Confirmed
- **Frontend**: Blazor Server Razor Components (.NET 8)
- **Backend**: ASP.NET Core (Blazor Server with EF Core services)
- **Database**: SQLite (development), MySQL (production)
- **Authentication**: ASP.NET Core Identity
- **ORM**: Entity Framework Core
- **Styling**: Bootstrap (default) + custom CSS

### Development Approach
- Start with Phase 1 and complete each phase fully before moving to next
- Each task should be completable in 30 minutes to 2 hours
- Focus on core functionality over edge cases
- Keep commits small and focused on individual tasks
- Prioritize working demo over perfect architecture
- Aim to complete MVP in 1-2 weeks of part-time work 