# DevTrack MVP Task Breakdown

## Phase 1: Project Setup & Foundation
**Goal: Get basic Blazor Server app running with database**

### 1.1 Project Scaffolding
- [x] Create new Blazor Server project with .NET 8
- [x] Set up solution structure with proper folder organization
- [x] Add required NuGet packages (EF Core, Identity, SQLite)
- [x] Configure appsettings.json for development
- [ ] Set up Git repository and initial commit

### 1.2 Database Setup
- [x] Create DbContext class with proper configuration
- [x] Define Project entity model
- [x] Define Task entity model with relationships
- [x] Create initial EF migration
- [x] Configure database connection string for SQLite
- [x] Test database creation and basic seeding

### 1.3 Authentication Setup
- [ ] Configure ASP.NET Identity services (use defaults)
- [ ] Create registration page component
- [ ] Create login page component  
- [ ] Create logout functionality
- [ ] Add authentication middleware to Program.cs
- [ ] Test user registration and login flow

## Phase 2: Core UI Components & Layout
**Goal: Build basic navigation and layout structure**

### 2.1 Layout & Navigation
- [x] Create main layout component (MainLayout.razor)
- [x] Build navigation sidebar with menu items
- [x] Create header component with user info and logout
- [x] Add responsive design considerations
- [ ] Create loading states and error boundaries
- [ ] Test navigation between pages

### 2.2 Dashboard Components
- [x] Create dashboard page to list user's projects
- [x] Build project card component for dashboard
- [ ] Add "Create New Project" button and form
- [ ] Create project creation form component
- [ ] Test project creation and display

## Phase 3: Project Management Core
**Goal: Basic CRUD operations for projects**

### 3.1 Project Services
- [ ] Create ProjectService for business logic
- [ ] Implement CreateProject method
- [ ] Implement GetUserProjects method  
- [ ] Implement UpdateProject method
- [ ] Implement DeleteProject method
- [ ] Add basic validation for projects
- [ ] Test all CRUD operations

### 3.2 Project UI
- [ ] Create project details page
- [ ] Build project edit form component
- [ ] Add project deletion confirmation dialog
- [ ] Test project management workflow

## Phase 4: Kanban Board MVP
**Goal: Basic task management with columns**

### 4.1 Task Models & Services
- [ ] Create TaskService for task operations
- [ ] Implement CreateTask method
- [ ] Implement GetTasksByProject method
- [ ] Implement UpdateTaskStatus method
- [ ] Implement UpdateTask method
- [ ] Implement DeleteTask method
- [ ] Add task validation logic

### 4.2 Kanban Board UI
- [ ] Create KanbanBoard component
- [ ] Build TaskColumn component (To Do, In Progress, Done)
- [ ] Create TaskCard component for individual tasks
- [ ] Build "Add Task" form component
- [ ] Create task detail modal/page
- [ ] Add task editing functionality
- [ ] Test task creation and status updates

### 4.3 Task Properties
- [ ] Add task title and description fields
- [ ] Implement task priority levels (Low, Medium, High)
- [ ] Add due date functionality
- [ ] Create simple tag system for tasks (comma-separated)
- [ ] Add task completion tracking
- [ ] Test all task properties

## Phase 5: Basic Time Tracking
**Goal: Simple time logging for tasks**

### 5.1 Time Tracking Models
- [ ] Create TimeLog entity model
- [ ] Add relationship between TimeLog and Task
- [ ] Create time tracking service
- [ ] Implement start/stop timer logic
- [ ] Add time calculation methods
- [ ] Create EF migration for time tracking

### 5.2 Time Tracking UI
- [ ] Add timer button to task cards
- [ ] Create active timer indicator
- [ ] Build simple time log display
- [ ] Create basic time summary view
- [ ] Test timer functionality

## Phase 6: MVP Polish & Testing
**Goal: Make the app presentable for portfolio**

### 6.1 Basic Polish
- [ ] Add basic error handling and user-friendly messages
- [ ] Add loading states for operations
- [ ] Implement basic authorization checks
- [ ] Handle common edge cases
- [ ] Test main user workflows

### 6.2 Final Touches
- [ ] Add basic task filtering by tags
- [ ] Add simple task search functionality
- [ ] Add responsive styling improvements
- [ ] Create a simple README with screenshots
- [ ] Test the complete user flow end-to-end
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